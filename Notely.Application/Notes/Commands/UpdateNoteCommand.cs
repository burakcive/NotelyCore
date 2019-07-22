using MediatR;
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
        private readonly IRepository<Note> repository;

        public UpdateNoteCommandHandler(IRepository<Note> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            repository.Update(new Note {NoteId =request.NoteId, Body = request.Body, Subject = request.Subject });
            repository.Commit();

            return await Task.FromResult(Unit.Value);
        }
    }
}
