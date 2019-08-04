using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notely.Application.Notes.Commands;
using Notely.Application.Notes.Models;
using Notely.Application.Notes.Queries;
using NotelyCore.Domain;
using NotelyCore.Domain.Identity;

namespace NotelyCore.Web.Pages
{
    public class IndexModel : BasePageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public NotesViewModel NotesViewModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; } 
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));


        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;


        public async Task OnGet()
        {
            var signedInUser = await userManager.GetUserAsync(HttpContext.User);
            NotesViewModel = await Mediator.Send(
                new GetNotesQuery
                {
                    User = signedInUser,
                    CurrentPage = CurrentPage,
                    PageSize = PageSize
                }
            );

            Count = NotesViewModel.TotalNotes;
        }

        public async Task<IActionResult> OnPostNoteItemDelete(int noteId)
        {
            await Mediator.Send(new DeleteNoteCommand { NoteId = noteId });

            return new JsonResult(new { succeeded = true });
        }
    }
}
