using MediatR;
using Microsoft.EntityFrameworkCore;
using NotelyCore.Persistence;
using NotelyCore.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NotelyCore.Domain.Identity;

namespace Notely.Application.Links.Queries
{
    public class GetLinksQuery : IRequest<List<Link>>
    {
        public ApplicationUser User { get; set; }
    }

    public class GetLinksQueryHandler : IRequestHandler<GetLinksQuery, List<Link>>
    {
        private readonly NotelyCoreDbContext dbContext;

        public GetLinksQueryHandler(NotelyCoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Link>> Handle(GetLinksQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Links
                .Where(n=> n.User == request.User)
                .OrderByDescending(n=>n.LevelOfImportance)
                .ToListAsync();
        }
    }
}
