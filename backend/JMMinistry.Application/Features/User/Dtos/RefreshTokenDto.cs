using System.ComponentModel.DataAnnotations.Schema;
namespace JMMinistry.Application.Features.User.Dtos
{
    public class RefreshTokenDto
    {
        [Column("id")]
        public string Id { get; set; } = string.Empty;
    }
}