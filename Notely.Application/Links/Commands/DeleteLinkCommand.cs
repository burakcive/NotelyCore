using MediatR;
using NotelyCore.Persistence;
using NotelyCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notely.Application.Links.Commands
{
    public class DeleteLinkCommand : IRequest
    {
        public int LinkId { get; set; }
    }

    public class DeleteLinkCommandHandler : IRequestHandler<DeleteLinkCommand, Unit>
    {
        private readonly NotelyCoreDbContext dbContext;

        public DeleteLinkCommandHandler(NotelyCoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteLinkCommand request, CancellationToken cancellationToken)
        {
            dbContext.Remove(new Link { LinkId = request.LinkId });
            await dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
