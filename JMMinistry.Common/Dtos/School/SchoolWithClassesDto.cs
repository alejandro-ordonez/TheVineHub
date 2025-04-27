using JMMinistry.Common.Dtos.Class;

namespace JMMinistry.Common.Dtos.School
{
    public class SchoolWithClassesDto : SchoolDto
    {
        public ICollection<ClassDto> Classes { get; set; } = [];
    }
}
