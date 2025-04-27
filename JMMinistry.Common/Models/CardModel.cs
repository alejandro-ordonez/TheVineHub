using FluentValidation;

namespace JMMinistry.Common.Models
{
    public class CardModel
    {
        public int? Id { get; set; } = default;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class CardModelValidator<T> : BaseValidator<CardModel> where T : IConvertible
    {
        public CardModelValidator()
        {
            RuleFor(card => card.Name)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(card => card.Description)
                .NotEmpty()
                .MinimumLength(5);
        }
    }
}
