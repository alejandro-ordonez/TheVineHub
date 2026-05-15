using SurrealDb.Net.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JMMinistry.Domain.Users
{
    public class BasicUserInfo: Record
    {
        [Column(name: "full_name")]
        public string FullName { get; set; } = string.Empty;
        
        [Column(name: "gender")]
        public string Gender { get; set; } = string.Empty;

        [Column(name: "phone")]
        public string Phone { get; set; } = string.Empty;

        [Column(name: "photo_path")]
        public string? PhotoPath { get; set; }
    }
}
