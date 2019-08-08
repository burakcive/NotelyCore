using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotelyCore.Application.Notes.Commands;
using NotelyCore.Application.Notes.Queries;
using NotelyCore.Domain;
using NotelyCore.Domain.Identity;

namespace NotelyCore.Web.Pages.Notely
{

    public class EditModel : BasePageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        public EditModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public Note Note { get; set; }


        public async Task OnGet(int? noteId)
        {
            if (noteId.HasValue)
            {
                Note = await Mediator.Send(new GetNoteByIdQuery(noteId.Value));
            }
            else
            {
                Note = new Note();
                TempData["IsAddMode"] = true;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            var signedInUser = await userManager.GetUserAsync(HttpContext.User);

            await Mediator.Send(new UpsertNoteCommand
            {
                Body = Note.Body,
                Subject = Note.Subject,
                NoteId = Note.NoteId,
                Priorty = Note.Priority,
                User = signedInUser
            });

            return RedirectToPage("../Index");
        }


    }
}