using System.ComponentModel.DataAnnotations.Schema;
namespace TheVineHub.API.Features.Users
{
    public class RefreshTokenDto
    {
        [Column("id")]
        public string Id { get; set; } = string.Empty;
    }
}