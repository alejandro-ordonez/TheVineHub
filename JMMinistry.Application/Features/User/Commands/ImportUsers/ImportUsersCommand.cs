using MediatR;
using Microsoft.AspNetCore.Http;

namespace JMMinistry.Application.Features.User.Commands.ImportUsers
{
    public class ImportUsersCommand : IRequest<string>
    {
        public IFormFile? File { get; set; }
    }
}
