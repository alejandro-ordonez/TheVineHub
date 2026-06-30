using JMMinistry.Application.Common;
using JMMinistry.Application.Features.User.Enums;
using JMMinistry.Application.Extensions;
using Mediator;
using SurrealDb.Net;
using System.Globalization;
using System.Linq;

namespace JMMinistry.Application.Features.User.Commands.ImportUsers
{
    public class ImportUsersHandler(ISurrealDbSession session) : ICommandHandler<ImportUsersCommand, string>
    {
        public async ValueTask<string> Handle(ImportUsersCommand request, CancellationToken cancellationToken)
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

            for (var lineNumber = 0; lineNumber < lines.Count; lineNumber++)
            {
                var fields = lines[lineNumber].Split(',');

                // Simplified extraction for the refactor
                var name = fields[CsvOrdinals.Name.GetHashCode()].Trim();
                var lastName = fields[CsvOrdinals.LastName.GetHashCode()].Trim();
                var document = fields[CsvOrdinals.Document.GetHashCode()].Trim();
                var email = fields[CsvOrdinals.Email.GetHashCode()].Trim();
                var gender = fields[CsvOrdinals.Gender.GetHashCode()].Trim();
                var maritalStatus = fields[CsvOrdinals.MaritalStatus.GetHashCode()].Trim();

                if (string.IsNullOrEmpty(document)) continue;

                var result = await session.Query(@$"
                    CREATE type::record('user', {document}) SET
                        name = {name.ToCapitalCase()},
                        last_name = {lastName.ToCapitalCase()},
                        email = {email},
                        password = crypto::argon2::generate({$"User.{document}"}),
                        gender = {gender},
                        marital_status = {maritalStatus};
                ", cancellationToken);

                counter++;
            }

            reader.Close();

            return $"{counter} Users were imported";
        }

        private static readonly string[] DateFormats = { "d/M/yyyy", "dd/MM/yyyy" };
    }
}
