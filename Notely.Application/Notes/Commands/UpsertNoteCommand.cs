﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Notely.Persistence;
using NotelyCore.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notely.Application.Notes.Commands
{
    public class UpsertNoteCommand : IRequest
    {
        public int NoteId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public PriortyType Priorty { get; set; }

        public bool IsAddMode => NoteId == 0;
    }

    public class UpsertNoteCommandHandler : IRequestHandler<UpsertNoteCommand, Unit>
    {
        private readonly NotelyCoreDbContext dbContext;

        public UpsertNoteCommandHandler(NotelyCoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpsertNoteCommand request, CancellationToken cancellationToken)
        {

            var noteToUpsert = request.IsAddMode ?
                new Note():
                await dbContext.Notes.SingleOrDefaultAsync(n => n.NoteId == request.NoteId);

            if (noteToUpsert == null)
            {
                throw new Exception(nameof(noteToUpsert) + " not found");
            }

            noteToUpsert.Subject = request.Subject;
            noteToUpsert.Body = request.Body;
            noteToUpsert.Priority = request.Priorty;

            if (request.IsAddMode)
            {
                noteToUpsert.CreatedOn = DateTime.UtcNow;
                dbContext.Notes.Add(noteToUpsert);
            }

            await dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
