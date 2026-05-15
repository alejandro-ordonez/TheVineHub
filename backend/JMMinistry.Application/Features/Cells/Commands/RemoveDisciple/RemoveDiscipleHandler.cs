using JMMinistry.Common.Dtos.User;
using JMMinistry.Application.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.Cells.Commands.RemoveDisciple
{
    public class RemoveDiscipleHandler(ISurrealDbSession session) : ICommandHandler<RemoveDiscipleCommand, IList<DiscipleDto>>
    {
        public async ValueTask<IList<DiscipleDto>> Handle(RemoveDiscipleCommand request, CancellationToken cancellationToken)
        {
            var cellId = request.CellId.StartsWith("cell:") ? request.CellId : $"cell:{request.CellId}";
            var userId = request.Document.StartsWith("user:") ? request.Document : $"user:{request.Document}";

            var result = await session.Query(@$"
                BEGIN TRANSACTION;
                
                -- Verify relationship exists
                LET $relation = (SELECT * FROM disciple_in WHERE in = type::thing('user', {userId}) AND out = type::thing('cell', {cellId}));
                
                IF array::len($relation) == 0 THEN
                    THROW 'This person does not belong to the given cell';
                END;

                -- Delete relationship
                DELETE disciple_in WHERE in = type::thing('user', {userId}) AND out = type::thing('cell', {cellId});
                
                COMMIT TRANSACTION;
                
                -- Return updated disciples list
                RETURN (SELECT in.* FROM disciple_in WHERE out = type::thing('cell', {cellId}));
            ", cancellationToken);

            var disciples = result.GetValue<List<DiscipleDto>>(0);

            return disciples ?? new List<DiscipleDto>();
        }
    }
}
