using MediatR;
using NotelyCore.Persistence;
using NotelyCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notely.Application.Notes.Commands
{
    public class DeleteNoteCommand : IRequest
    {
        public int NoteId { get; set; }
    }

    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
    {
        private readonly NotelyCoreDbContext dbContext;

        public DeleteNoteCommandHandler(NotelyCoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            dbContext.Remove(new Note { NoteId = request.NoteId });
            await dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
