using JMMinistry.Common.Dtos.User.Enums;

namespace JMMinistry.Common.Dtos.User
{
    public class PartialUserInfoDto
    {
        public string Document { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = string.Empty;
        public MinistryStatus? MinistryStatus { get; set; }
        public Gender Gender { get; set; }
        public string? Photo { get; set; }
        public int? CellId { get; set; }
    }
}
