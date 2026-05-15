using JMMinistry.Domain.Users;
using SurrealDb.Net.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JMMinistry.Domain.Cells
{
    public class Cell: Record
    {
        [Column(name: "name")]
        public string Name { get; set; } = string.Empty;

        [Column(name: "description")]
        public string Description { get; set; } = string.Empty;

        [Column(name: "day")]
        public string Day { get; set; } = string.Empty;

        [Column("main_cell")]
        public bool MainCell { get; set; }

        [Column(name: "opening_date")]
        public DateTime OpeningDate { get; set; }

        [Column(name: "address")]
        public string Address { get; set; } = string.Empty;

        [Column(name: "level")]
        public int Level { get; set; } = 1;

        [Column(name: "member_count")]
        public int MemberCount { get; set; }

        [Column(name: "leaders")]
        public IEnumerable<LeaderInfo> Leaders { get; set; } = [];
    }
}
