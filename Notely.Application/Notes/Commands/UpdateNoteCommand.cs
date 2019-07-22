using MediatR;
using Microsoft.EntityFrameworkCore;
using Notely.Persistence;
using NotelyCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notely.Application.Notes.Commands
{
    public class UpdateNoteCommand : IRequest
    {
        public int NoteId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }

    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Unit>
    {
        private readonly NotelyCoreDbContext dbContext;

        public UpdateNoteCommandHandler(NotelyCoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

     
        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var noteToUpdate = await dbContext.Notes.SingleOrDefaultAsync(n => n.NoteId == request.NoteId);

            if (noteToUpdate == null)
            {
                throw new Exception(nameof(noteToUpdate) + " not found");
            }

            noteToUpdate.Subject = request.Subject;
            noteToUpdate.Body = request.Body;

            await dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
