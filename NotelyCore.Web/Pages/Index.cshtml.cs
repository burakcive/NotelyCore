using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notely.Application.Notes.Commands;
using Notely.Application.Notes.Queries;
using NotelyCore.Domain;

namespace NotelyCore.Web.Pages
{
    public class IndexModel : BasePageModel
    {
        public IndexModel()
        {

        }
        public IEnumerable<Note> Notes { get; set; }

        public async Task OnGet()
        {
            //Notes = noteRepository.GetAll();
            Notes = await Mediator.Send(new GetNotesQuery());
        }

        public async Task<IActionResult> OnPostNoteItemDelete(int noteId)
        {
            await Mediator.Send(new DeleteNoteCommand { NoteId = noteId });

            return new JsonResult(new {succeeded = true });
        }
    }
}
