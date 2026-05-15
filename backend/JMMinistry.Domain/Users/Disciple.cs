using SurrealDb.Net.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JMMinistry.Domain.Users
{
    public class Disciple : BasicUserInfo
    {
        [Column(name: "member_since")]
        public DateTime MemberSince { get; set; }

        [Column(name: "disciple_step")]
        public string DiscipleStep { get; set; } = string.Empty;

        [Column(name: "cell_id")]
        public RecordId? CellId { get; set; }
    }
}
