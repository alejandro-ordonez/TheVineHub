using System.ComponentModel.DataAnnotations.Schema;
﻿using Mediator;
using Microsoft.AspNetCore.Http;

namespace JMMinistry.Application.Features.User.Commands.ImportUsers
{
    public class ImportUsersCommand : ICommand<string>
    {
        [Column("file")]
        public IFormFile? File { get; set; }
    }
}
