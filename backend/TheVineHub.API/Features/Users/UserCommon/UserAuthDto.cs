using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.Users
{
    public class UserAuthDto
    {
        [Column("id")]
        public RecordId? Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("last_name")]
        public string LastName { get; set; } = string.Empty;
        [Column("email")]
        public string Email { get; set; } = string.Empty;
        [Column("roles")]
        public List<string> Roles { get; set; } = [];
        [JsonPropertyName("guiding_steps")]
        [Column("guiding_steps")]
        public List<string> GuidingSteps { get; set; } = [];
    }
}
