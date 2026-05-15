using SurrealDb.Net.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JMMinistry.Domain.Users
{
    public class RefreshToken : Record
    {
        [Column(name: "expires_at")]
        public DateTime ExpiresAt { get; set; } = DateTime.Now;

        [Column(name: "revoked")]
        public bool Revoked { get; set; }

        [Column(name: "token")]
        public string Token { get; set; } = string.Empty;

        [Column(name: "user")]
        public RecordIdOf<string>? User { get; set; }
    }
}
