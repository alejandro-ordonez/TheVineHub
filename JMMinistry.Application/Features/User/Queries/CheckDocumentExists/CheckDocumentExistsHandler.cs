using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.User;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.User.Queries.CheckDocumentExists
{
    public class CheckDocumentExistsHandler(IJmDbContext dbContext)
        : IQueryHandler<CheckDocumentExistsQuery, DocumentCheckResultDto>
    {
        public async ValueTask<DocumentCheckResultDto> Handle(CheckDocumentExistsQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.PersonalInfo
                .FirstOrDefaultAsync(u => u.Id == request.Document, cancellationToken);

            if (user is null)
            {
                return new DocumentCheckResultDto { Exists = false };
            }

            return new DocumentCheckResultDto
            {
                Exists = true,
                HasCell = user.CellId is not null,
                Name = user.Name,
                LastName = user.LastName
            };
        }
    }
}
