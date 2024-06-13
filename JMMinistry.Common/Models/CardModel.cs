using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Common.Models
{
    public class CardModel<T> where T : IConvertible
    {
        public T? Id { get; set; } = default;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class CardModelValidator<T> : BaseValidator<CardModel<T>> where T : IConvertible
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
