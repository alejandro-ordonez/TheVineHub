using SurrealDb.Net.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JMMinistry.Domain.Users;

public class LeaderInfo : Record
{
    [Column(name: "full_name")]
    public string FullName { get; set; } = string.Empty;

    [Column(name: "photo_path")]
    public string? PhotoPath { get; set; }
}
