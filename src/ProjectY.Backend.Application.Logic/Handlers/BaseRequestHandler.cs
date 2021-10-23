using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ProjectY.Backend.Application.Logic.Handlers
{
    /// <summary>
    /// Базовый класс-обработчик запросов in TRequest / out TResponse.
    /// </summary>
    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// Конструктор базового класса-обработчика запросов in TRequest / out TResponse.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        protected BaseRequestHandler(IMapper mapper, ILogger<BaseRequestHandler<TRequest, TResponse>> logger)
        {
            Mapper = mapper;
            Logger = logger;
        }

        /// <summary>
        /// Экземпляр логгера производного класса.
        /// </summary>
        protected ILogger<BaseRequestHandler<TRequest, TResponse>> Logger { get; }

        /// <summary>
        /// Экземпляр маппера.
        /// </summary>
        protected IMapper Mapper { get; }

        /// <inheritdoc />
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                Logger.LogInformation("Обработка запроса {@Request}", request);
                
                return await Execute(request, cancellationToken);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Ошибка при обработке запроса {@Request}", request);
                throw; // todo: шо тровим?
            }
        }
        
        /// <summary>
        /// Выполнить обработку запроса.
        /// </summary>
        /// <param name="request">Запрос на обработку</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Результат выполнения обработки запроса</returns>
        protected abstract Task<TResponse> Execute(TRequest request, CancellationToken cancellationToken = default);
    }
}
