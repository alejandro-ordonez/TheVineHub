using JMMinistry.Application.Extensions;
using JMMinistry.Common;
using JMMinistry.Common.Dtos.User.Enums;
using JMMinistry.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace JMMinistry.Application.Features.User.Commands.ImportUsers
{
    public class ImportUsersHandler(UserManager<PersonalInfo> userManager) : IRequestHandler<ImportUsersCommand, string>
    {
        public async Task<string> Handle(ImportUsersCommand request, CancellationToken cancellationToken)
        {
            if (request.File == null)
                throw new ArgumentNullException(nameof(request), "The file cannot be empty");

            using var reader = new StreamReader(request.File.OpenReadStream());
            var lines = new List<string>();

            // Skip first line - Header
            await reader.ReadLineAsync(cancellationToken);
            var counter = 0;

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

                faulty |= fields.ExtractAndValidate(CsvOrdinals.Name, out string name, wrongFields);
                faulty |= fields.ExtractAndValidate(CsvOrdinals.LastName, out string lastName, wrongFields);
                faulty |= fields.ExtractAndValidate(CsvOrdinals.Document, out string document, wrongFields);

                if (faulty)
                {
                    rejectedLines.Add(GetLineError(lineNumber + 1, wrongFields));
                    continue;
                }

                var birthdayString = fields.Extract(CsvOrdinals.Birthday);
                var phone = fields.Extract(CsvOrdinals.Phone);
                var neighborhood = fields.Extract(CsvOrdinals.Neighborhood);
                var locality = fields.Extract(CsvOrdinals.Locality);
                var email = fields.Extract(CsvOrdinals.Email);
                var maritalStatus = fields.Extract(CsvOrdinals.MaritalStatus);
                var educationalLevel = fields.Extract(CsvOrdinals.EducationalLevel);
                var profession = fields.Extract(CsvOrdinals.Profession);
                var occupation = fields.Extract(CsvOrdinals.Occupation);
                var gender = fields.Extract(CsvOrdinals.Gender);


                var nameSanitized = BuildPartialUserName(name);
                var lastNameSanitized = BuildPartialUserName(lastName);
                var userName = $"{nameSanitized}.{lastNameSanitized}";

                var person = new PersonalInfo
                {
                    Id = document,
                    Name = name.ToCapitalCase(),
                    LastName = lastName.ToCapitalCase(),
                    UserName = userName,
                    Birthday = string.IsNullOrEmpty(birthdayString) ? null : DateOnly.ParseExact(birthdayString, DateFormats, CultureInfo.InvariantCulture),
                    Phone = phone,
                    Email = email,
                    Locality = locality,
                    Neighborhood = neighborhood,
                    EducationalLevel = Enum.Parse<EducationalLevel>(educationalLevel!),
                    MaritalStatus = Enum.Parse<MaritalStatus>(maritalStatus!),
                    MinistryStatus = MinistryStatus.Unknown,
                    Gender = Enum.Parse<Gender>(gender!)
                };

                var password = $"User.{person.Id}";
                var result = await userManager.CreateAsync(person, password);
                result.ThrowOnError();

                result = await userManager.AddToRoleAsync(person, Roles.Regular.ToString());
                result.ThrowOnError();

                counter++;
            }

            reader.Close();

            return $"{counter} Users were imported";
        }

        private static string GetLineError(int lineNumber, IList<string> errors)
            => $"The line {lineNumber}, has the following errors: [{string.Join(", ", errors)}]";

        private static readonly string[] DateFormats = { "d/M/yyyy", "dd/MM/yyyy" };

        private static string BuildPartialUserName(string input)
        {
            var parts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return parts.Length switch
            {
                2 => $"{parts[0].ToLower().Sanitize()}{parts[1][0].ToString().ToLower().Sanitize()}",
                _ => $"{parts[0].ToLower().Sanitize()}"
            };
        }
    }
}
