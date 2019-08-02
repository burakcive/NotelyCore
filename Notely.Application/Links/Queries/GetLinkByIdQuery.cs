using MediatR;
using NotelyCore.Domain;
using NotelyCore.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Notely.Application.Links.Queries
{
    public class GetLinkByIdQuery : IRequest<Link>
    {
        public int LinkId { get; set; }
    }

    public class GetLinkByIdQueryHandler : IRequestHandler<GetLinkByIdQuery, Link>
    {
        private readonly NotelyCoreDbContext dbContext;

        public GetLinkByIdQueryHandler(NotelyCoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Link> Handle(GetLinkByIdQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Links.SingleOrDefaultAsync(l => l.LinkId == request.LinkId);
        }
    }
}
