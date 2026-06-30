using JMMinistry.API.Extensions;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNote;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNoteEntry;
using JMMinistry.Application.Features.Discipleship.Queries.GetDiscipleshipNoteById;
using JMMinistry.Application.Features.Discipleship.Queries.GetDiscipleshipNotes;
using JMMinistry.Application.Features.Discipleship.Queries.GetNoteEntries;
using JMMinistry.Application.Features.Discipleship.Dtos;
using JMMinistry.Application.Features.Discipleship.Enums;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JMMinistry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DiscipleshipController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{discipleId}/notes")]
        public async Task<ActionResult<IList<DiscipleshipNoteDto>>> GetNotes(string discipleId)
        {
            var requestorId = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            var result = await mediator.Send(new GetDiscipleshipNotesQuery
            {
                RequestorId = requestorId,
                DiscipleId = discipleId
            });

            return Ok(result);
        }

        [HttpPost("{discipleId}/notes")]
        public async Task<ActionResult<DiscipleshipNoteDto>> CreateNote(string discipleId, [FromBody] CreateDiscipleshipNoteDto dto)
        {
            var requestorId = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            var result = await mediator.Send(new CreateNoteCommand
            {
                RequestorId = requestorId,
                DiscipleId = discipleId,
                Title = dto.Title,
                Description = dto.Description,
                Categories = dto.Categories
            });

            return Ok(result);
        }

        [HttpGet("{discipleId}/notes/{noteId}")]
        public async Task<ActionResult<DiscipleshipNoteDto>> GetNoteById(string discipleId, string noteId)
        {
            var requestorId = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            var result = await mediator.Send(new GetDiscipleshipNoteByIdQuery
            {
                RequestorId = requestorId,
                DiscipleId = discipleId,
                NoteId = noteId
            });

            return Ok(result);
        }

        [HttpGet("{discipleId}/notes/{noteId}/entries")]
        public async Task<ActionResult<IList<DiscipleshipNoteEntryDto>>> GetNoteEntries(string discipleId, string noteId)
        {
            var requestorId = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            var result = await mediator.Send(new GetNoteEntriesQuery
            {
                RequestorId = requestorId,
                DiscipleId = discipleId,
                NoteId = noteId
            });

            return Ok(result);
        }

        [HttpPost("{discipleId}/notes/{noteId}/entries")]
        public async Task<ActionResult<DiscipleshipNoteEntryDto>> CreateNoteEntry(string discipleId, string noteId, [FromBody] CreateDiscipleshipNoteEntryDto dto)
        {
            var requestorId = HttpContext.GetDocumentClaim() ?? throw new MissingInTokenException();

            var result = await mediator.Send(new CreateNoteEntryCommand
            {
                RequestorId = requestorId,
                DiscipleId = discipleId,
                NoteId = noteId,
                Content = dto.Content,
                Date = dto.Date
            });

            return Ok(result);
        }
    }
}
