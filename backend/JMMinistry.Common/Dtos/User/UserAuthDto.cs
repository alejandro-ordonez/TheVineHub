using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JMMinistry.Common.Dtos.User
{
    public class UserAuthDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("last_name")]
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = [];
        [JsonPropertyName("guiding_steps")]
        public List<string> GuidingSteps { get; set; } = [];
    }
}
