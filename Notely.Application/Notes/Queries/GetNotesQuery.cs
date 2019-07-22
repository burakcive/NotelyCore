using MediatR;
using Microsoft.EntityFrameworkCore;
using Notely.Persistence;
using NotelyCore.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notely.Application.Notes.Queries
{
    public class GetNotesQuery : IRequest<List<Note>>
    {
      
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
            return await dbContext.Notes.OrderBy(n=>n.Priority).ToListAsync();
        }
    }
}
