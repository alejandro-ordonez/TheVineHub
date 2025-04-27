using JMMinistry.Common.Models;

namespace JMMinistry.Common.Dtos.School
{
    public class SchoolDto : CardModel
    {
    }

    public class SchoolDtoValidator : CardModelValidator<int>
    {
        public SchoolDtoValidator() : base()
        {
        }
    }
}
