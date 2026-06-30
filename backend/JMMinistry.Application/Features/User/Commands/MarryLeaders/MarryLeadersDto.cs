using System.ComponentModel.DataAnnotations.Schema;
namespace JMMinistry.Application.Features.User.Commands.MarryLeaders
{
    public class MarryLeadersDto
    {
        [Column("person_id")]
        public required string PersonId { get; set; }
        [Column("spouse_id")]
        public required string SpouseId { get; set; }
    }
}
