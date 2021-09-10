using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Moq;
using ProjectY.Backend.Web.Api.Exceptions;
using ProjectY.Backend.Web.Api.Filters;
using Xunit;

namespace ProjectY.Backend.Tests.UnitTests
{
    public class ValidationFilterTests
    {
        private readonly ValidationFilter _sut = new();

        [Fact(DisplayName = "[TS-001] Проверка метода OnActionExecutionAsync. Метод должен оставлять значение " +
                            "атрибута объекта контекста Result равным null при валидном состоянии модели данных")]
        public async void OnActionExecutionAsync_WithValidModelState_NullResult()
        {
            // Arrange
            var (actionExecutingContext, actionExecutedContext) = GetActionContexts();

            // Act
            await _sut.OnActionExecutionAsync(actionExecutingContext, () => Task.FromResult(actionExecutedContext));

            // Assert
            Assert.Null(actionExecutingContext.Result);
        }

        [Fact(DisplayName = "[TS-002] Проверка метода OnActionExecutionAsync. Метод должен присваивать " +
                            "BadRequestObjectResult атрибуту объекта контекста Result при невалидном состоянии " +
                            "модели данных")]
        public async void OnActionExecutionAsync_WithInValidModelState_BadRequestObjectResult()
        {
            // Arrange
            var (actionExecutingContext, actionExecutedContext) = GetActionContexts();
            const string expectedExceptionName = "Ошибка валидации";
            const int expectedErrorsCount = 1;
            actionExecutingContext.ModelState.AddModelError("name", "invalid");

            // Act
            Task Act()
            {
                return _sut.OnActionExecutionAsync(actionExecutingContext,
                    () => Task.FromResult(actionExecutedContext));
            }

            // Assert
            var actualException = await Assert.ThrowsAsync<ContractValidationException>(Act);
            Assert.Equal(expectedExceptionName, actualException.Name);
            Assert.Equal(expectedErrorsCount, actualException.Errors.Count);
        }

        private static Tuple<ActionExecutingContext, ActionExecutedContext> GetActionContexts()
        {
            var modelState = new ModelStateDictionary();
            var httpContextMock = new DefaultHttpContext();
            var actionContext = new ActionContext(
                httpContextMock,
                Mock.Of<RouteData>(),
                Mock.Of<ActionDescriptor>(),
                modelState
            );
            var actionExecutingContext = new ActionExecutingContext(
                actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                Mock.Of<Controller>()
            );
            var context = new ActionExecutedContext(actionContext, new List<IFilterMetadata>(), Mock.Of<Controller>());
            return new Tuple<ActionExecutingContext, ActionExecutedContext>(actionExecutingContext, context);
        }
    }
}
