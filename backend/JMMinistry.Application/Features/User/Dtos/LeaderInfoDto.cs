using System.ComponentModel.DataAnnotations.Schema;
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JMMinistry.Application.Features.User.Dtos;

public class LeaderInfoDto
{
    [Column("id")]
    public string? Id { get; set; } = string.Empty;
    [Column("photo_url")]
    public string? PhotoUrl { get; set; } = string.Empty;
    [Column("full_name")]
    public string FullName { get; set; } = string.Empty;
}
