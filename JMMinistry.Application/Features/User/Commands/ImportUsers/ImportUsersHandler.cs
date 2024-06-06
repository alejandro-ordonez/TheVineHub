using JMMinistry.Common.Dtos.User.Enums;
using JMMinistry.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Commands.ImportUsers
{
    public class ImportUsersHandler : IRequestHandler<ImportUsersCommand, string>
    {
        public async Task<string> Handle(ImportUsersCommand request, CancellationToken cancellationToken)
        {
            if(request.File == null)
                throw new ArgumentNullException(nameof(request.File), "The file cannot be empty");

            using var reader = new StreamReader(request.File.OpenReadStream());
            var lines = new List<string>();

            // Skip first line - Header
            await reader.ReadToEndAsync(cancellationToken);

            while (reader.Peek() >= 0) 
                lines.Add(await reader.ReadToEndAsync(cancellationToken));

            var rejectedLines = new List<string>();

            for(var lineNumber = 0; lineNumber < lines.Count; lineNumber++)
            {
                var fields = lines[lineNumber].Split(',');

                if (fields.Length != 5)
                    rejectedLines.Add($"The line {lineNumber+1} is not well formatted");

                var person = new PersonalInfo
                {
                    Document = fields[0].Trim(),
                    Name = fields[1].Trim(),
                    LastName = fields[2].Trim(),

                };
            }

            return "Ok";
        }

        private static PersonalInfo BuildUser(string[] fields, ImportUserType importUserType)
        {
            var person = new PersonalInfo();

            throw new NotImplementedException();
        }
    }
}
