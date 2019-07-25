using MediatR;
using Microsoft.EntityFrameworkCore;
using NotelyCore.Persistence;
using NotelyCore.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NotelyCore.Domain.Identity;

namespace Notely.Application.Notes.Queries
{
    public class GetNotesQuery : IRequest<List<Note>>
    {
        public NotelyUser User { get; set; }
    }

    public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, List<Note>>
    {
        private readonly NotelyCoreDbContext dbContext;

        public GetNotesQueryHandler(NotelyCoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Note>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Notes
                .Where(n=> n.User == request.User)
                .OrderByDescending(n=>n.Priority)
                .ThenByDescending(n=> n.CreatedOn)
                .ToListAsync();
        }
    }
}
