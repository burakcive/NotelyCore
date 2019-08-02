using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly UserManager<ApplicationUser> userManager;

        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public IEnumerable<Note> Notes { get; set; }

        [BindProperty(SupportsGet = true)]
        public int NumberOfNotes { get; set; }

        public async Task OnGet()
        {
            var signedInUser = await userManager.GetUserAsync(HttpContext.User);
            Notes = await Mediator.Send(
                new GetNotesQuery
                {
                    User = signedInUser,
                    PageCount = 2
                }
            );

        }

        public async Task OnPost()
        {
            var signedInUser = await userManager.GetUserAsync(HttpContext.User);

            Notes = await Mediator.Send(
                new GetNotesQuery
                {
                    User = signedInUser,
                    PageCount = NumberOfNotes
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
