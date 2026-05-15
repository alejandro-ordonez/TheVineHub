using SurrealDb.Net.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JMMinistry.Domain.Users
{
    public class AuthUserInfo: Record
    {
        [Column(name: "full_name")]
        public string Name { get; set; } = string.Empty;

        [Column(name: "roles")]
        public IList<string> Roles { get; set; } = [];

        [Column(name: "guiding_steps")]
        public IList<string> GuidingSteps { get; set; } = [];
    }
}
