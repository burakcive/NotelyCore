using MediatR;
using Microsoft.EntityFrameworkCore;
using NotelyCore.Persistence;
using NotelyCore.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NotelyCore.Domain.Identity;
using Notely.Application.Notes.Models;

namespace Notely.Application.Notes.Queries
{
    public class GetNotesQuery : IRequest<NotesViewModel>
    {
        public ApplicationUser User { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; } = 10;
    }

    public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, NotesViewModel>
    {
        private readonly NotelyCoreDbContext dbContext;

        public GetNotesQueryHandler(NotelyCoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<NotesViewModel> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            var returnModel = new NotesViewModel
            {
                TotalNotes = await dbContext.Notes.CountAsync(n => n.User == request.User),
                Notes = await dbContext.Notes
                .Where(n => n.User == request.User)
                .OrderByDescending(n => n.Priority)
                .ThenByDescending(n => n.CreatedOn)
                .Skip((request.CurrentPage -1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync()
            };

            return returnModel;
        }
    }
}
