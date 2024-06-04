using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Commands.ImportUsers
{
    public class ImportUsersCommand : IRequest
    {
        public IFormFile? File { get; set; }
    }
}
