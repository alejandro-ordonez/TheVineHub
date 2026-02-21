using Mediator;
using Microsoft.AspNetCore.Http;

namespace JMMinistry.Application.Features.User.Commands.ImportUsers
{
    public class ImportUsersCommand : ICommand<string>
    {
        public IFormFile? File { get; set; }
    }
}
