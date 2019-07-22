using MediatR;
using Notely.Persistence;
using NotelyCore.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Notely.Application.Notes.Queries
{
    public class GetNotesQuery : IRequest<IEnumerable<Note>>
    {

    }

    public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, IEnumerable<Note>>
    {
        private readonly IRepository<Note> repository;

        public GetNotesQueryHandler(IRepository<Note> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<Note>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.GetAll());
        }
    }
}
