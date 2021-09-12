using FluentValidation;
using ProjectY.Shared.Contracts.ShoesController;

namespace ProjectY.Backend.Web.Api.Validators
{
    /// <summary>
    /// Валидатор для контракта на создание обуви.
    /// </summary>
    public class CreateShoesContractValidator : AbstractValidator<CreateShoesContract>
    {
        /// <summary>
        /// Конструктор валидатора для контракта на создание обуви.
        /// </summary>
        public CreateShoesContractValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Необходимо заполнить наименование модели");

            RuleFor(p => p.Color)
                .NotEmpty()
                .WithMessage("Необходимо выбрать цвет модели");
        }
    }
}
