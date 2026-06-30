using System.ComponentModel.DataAnnotations.Schema;
using JMMinistry.Application.Features.User.Dtos;
using JMMinistry.Application.Features.User.Commands.Authenticate;
using JMMinistry.Application.Features.User.Commands.CreateUser;
using JMMinistry.Application.Features.User.Commands.MarryLeaders;
using Mediator;

namespace JMMinistry.Application.Features.User.Queries.CheckDocumentExists
{
    public class CheckDocumentExistsQuery : IQuery<DocumentCheckResultDto>
    {
        [Column("document")]
        public string Document { get; set; } = string.Empty;
    }
}
