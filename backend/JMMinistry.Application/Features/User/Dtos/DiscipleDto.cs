using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using SurrealDb.Net.Models;

namespace JMMinistry.Application.Features.User.Dtos
{
    public class DiscipleDto : BasicUserInfoDto
    {
        [Column("member_since")]
        public DateTime MemberSince { get; set; }
        [Column("cell_id")]
        public RecordId? CellId { get; set; }
        [Column("disciple_step")]
        public string? DiscipleStep { get; set; }
    }
}
