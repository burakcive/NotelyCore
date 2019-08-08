using MediatR;
using Microsoft.EntityFrameworkCore;
using NotelyCore.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NotelyCore.Domain.Identity;
using NotelyCore.Application.Links.Models;

namespace NotelyCore.Application.Links.Queries
{
    public class GetLinksQuery : IRequest<LinksViewModel>
    {
        public ApplicationUser User { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; } = 10;
    }

    public class GetLinksQueryHandler : IRequestHandler<GetLinksQuery, LinksViewModel>
    {
        private readonly NotelyCoreDbContext dbContext;

        public GetLinksQueryHandler(NotelyCoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<LinksViewModel> Handle(GetLinksQuery request, CancellationToken cancellationToken)
        {
            var returnModel = new LinksViewModel
            {
                TotalLinks = await dbContext.Links.CountAsync(n => n.User == request.User),
                Links = await dbContext.Links
                .Where(n => n.User == request.User)
                .Skip((request.CurrentPage - 1) * request.PageSize)
                .Take(request.PageSize)
                .OrderByDescending(n => n.LevelOfImportance)
                .ToListAsync()
            };

            return returnModel;
        }
    }
}
