using MediatR;
using Microsoft.EntityFrameworkCore;
using NotelyCore.Persistence;
using NotelyCore.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace NotelyCore.Application.Notes.Queries
{
    public class GetNoteByIdQuery : IRequest<Note>
    {
        public int NoteId { get; }

        public GetNoteByIdQuery(int noteId)
        {
            NoteId = noteId;
        }
    }

    public class GetNoteByIdQueryHandler : IRequestHandler<GetNoteByIdQuery, Note>
    {
        private readonly NotelyCoreDbContext dbContext;

        public GetNoteByIdQueryHandler(NotelyCoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Note> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Notes.SingleOrDefaultAsync(n => n.NoteId == request.NoteId);
        }
    }
}
