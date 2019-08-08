using MediatR;
using Microsoft.EntityFrameworkCore;
using NotelyCore.Persistence;
using NotelyCore.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;
using NotelyCore.Domain.Identity;

namespace NotelyCore.Application.Links.Commands
{
    public class UpsertLinkCommand : IRequest
    {
        public int LinkId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int LevelOfImportance { get; set; }

        public bool IsAddMode => LinkId == 0;

        public ApplicationUser User { get; set; }
    }

    public class UpsertLinkCommandHandler : IRequestHandler<UpsertLinkCommand, Unit>
    {
        private readonly NotelyCoreDbContext dbContext;

        public UpsertLinkCommandHandler(NotelyCoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpsertLinkCommand request, CancellationToken cancellationToken)
        {

            var linkToUpsert = request.IsAddMode ?
                new Link():
                await dbContext.Links.SingleOrDefaultAsync(n => n.LinkId == request.LinkId);

            if (linkToUpsert == null)
            {
                throw new Exception(nameof(linkToUpsert) + " not found");
            }

            linkToUpsert.Url = request.Url;
            linkToUpsert.Description = request.Description;
            linkToUpsert.LevelOfImportance = request.LevelOfImportance;

            if (request.IsAddMode)
            {
                linkToUpsert.User = request.User;
                dbContext.Links.Add(linkToUpsert);
            }

            await dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
