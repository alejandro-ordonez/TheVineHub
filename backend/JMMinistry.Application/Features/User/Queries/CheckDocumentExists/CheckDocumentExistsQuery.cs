using JMMinistry.Common.Dtos.User;
using Mediator;

namespace JMMinistry.Application.Features.User.Queries.CheckDocumentExists
{
    public class CheckDocumentExistsQuery : IQuery<DocumentCheckResultDto>
    {
        public string Document { get; set; } = string.Empty;
    }
}
