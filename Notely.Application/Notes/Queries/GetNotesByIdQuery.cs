using MediatR;
using Notely.Persistence;
using NotelyCore.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Notely.Application.Notes.Queries
{
    public class GetNoteByIdQuery : IRequest<Note>
    {
        public int NoteId { get; }

        public GetNoteByIdQuery(int noteId)
        {
            NoteId = noteId;
        }
    }

    public class GetNotesByIdQueryHandler : IRequestHandler<GetNoteByIdQuery, Note>
    {
        private readonly IRepository<Note> repository;

        public GetNotesByIdQueryHandler(IRepository<Note> repository)
        {
            this.repository = repository;
        }
        public Task<Note> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.GetById(request.NoteId));
        }
    }
}
