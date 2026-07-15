using System.ComponentModel.DataAnnotations.Schema;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.Users
{
    public class LeaderInfoDto
    {
        [Column("id")]
        public RecordId? Id { get; set; }

        [Column("photo_path")]
        public string? PhotoPath { get; set; }

        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;
    }
}
