using JMMinistry.Application.Services;
using JMMinistry.Common;
using JMMinistry.Common.Dtos.User.Enums;
using JMMinistry.Domain;
using JMMinistry.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Features.User.Commands.ImportUsers
{
    public class ImportUsersHandler(UserManager<PersonalInfo> userManager, ILogger<ImportUsersHandler> logger) : IRequestHandler<ImportUsersCommand, string>
    {
        public async Task<string> Handle(ImportUsersCommand request, CancellationToken cancellationToken)
        {
            if (request.File == null)
                throw new ArgumentNullException(nameof(request), "The file cannot be empty");

            using var reader = new StreamReader(request.File.OpenReadStream());
            var lines = new List<string>();

            // Skip first line - Header
            await reader.ReadLineAsync();

            while (reader.Peek() >= 0)
            {
                var line = await reader.ReadLineAsync(cancellationToken);
                if (string.IsNullOrEmpty(line))
                    continue;

                lines.Add(line);

            }

            var rejectedLines = new List<string>();

            for (var lineNumber = 0; lineNumber < lines.Count; lineNumber++)
            {
                var fields = lines[lineNumber].Split(',');
                var faulty = false;
                var wrongFields = new List<string>();

                faulty |= ValidateColumn(fields[0], out string name, nameof(name), wrongFields);
                faulty |= ValidateColumn(fields[1], out string lastName, nameof(lastName), wrongFields);
                faulty |= ValidateColumn(fields[4], out string document, nameof(document), wrongFields);


                if (faulty)
                {
                    rejectedLines.Add(GetLineError(lineNumber + 1, wrongFields));
                    continue;
                }

                var gender = fields[2].Trim();
                var birthday = fields[5].Trim();
                var phone = fields[6].Trim();
                var email = fields[7].Trim();



                var person = new PersonalInfo
                {
                    Id = document,
                    Name = name.ToCapitalCase(),
                    LastName = lastName.ToCapitalCase(),
                    Gender = string.IsNullOrEmpty(gender) ? null : GetGender(gender),
                    Birthday = string.IsNullOrEmpty(birthday) ? null : DateOnly.Parse(birthday),
                    Phone = string.IsNullOrEmpty(phone) ? null : phone,
                    Email = string.IsNullOrEmpty(email) ? null : email,
                    UserName = $"{name.ToLower().Split(' ')[0]}.{lastName.ToLower().Split(' ')[0]}",
                    MinistryStatus = Domain.Enums.MinistryStatus.InACell
                };

                
                var result = await userManager.CreateAsync(person, document);

                if(!result.Succeeded)
                    logger.LogError("There was an error creating the users, errors {errors}", string.Join("\n\n", result.Errors));
            }

            reader.Close();

            return "Ok";
        }

        private static Domain.Enums.Gender? GetGender(string value) => value switch
        {
            "H" => Domain.Enums.Gender.Male,
            "M" => Domain.Enums.Gender.Female,
            _ => null
        };

        private static bool ValidateColumn(string value, out string output, string columnName, IList<string> wrongFields)
        {
            var trimmedValue = value.Trim();
            var faulty = string.IsNullOrEmpty(trimmedValue);

            if (faulty)
            {
                wrongFields.Add($"column: {columnName}");
                output = string.Empty;
                return faulty;
            }

            output = trimmedValue;

            return false;
        }

        private static string GetLineError(int lineNumber, IList<string> errors)
            => $"The line {lineNumber}, has the following errors: [{string.Join(", ", errors)}]";
    }
}
