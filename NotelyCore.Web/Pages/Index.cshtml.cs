using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notely.Application.Notes.Commands;
using Notely.Application.Notes.Queries;
using NotelyCore.Domain;
using NotelyCore.Domain.Identity;

namespace NotelyCore.Web.Pages
{
    public class IndexModel : BasePageModel
    {
        private readonly SignInManager<NotelyUser> signInManager;

        public IndexModel(SignInManager<NotelyUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public IEnumerable<Note> Notes { get; set; }

        public async Task OnGet()
        {
            var signedInUser = await signInManager.UserManager.GetUserAsync(HttpContext.User);
            Notes = await Mediator.Send(
                new GetNotesQuery
                {
                    User = signedInUser
                }
            );
        }

        public async Task<IActionResult> OnPostNoteItemDelete(int noteId)
        {
            await Mediator.Send(new DeleteNoteCommand { NoteId = noteId });

            return new JsonResult(new { succeeded = true });
        }
    }
}
