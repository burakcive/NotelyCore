using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notely.Application.Notes.Commands;
using Notely.Application.Notes.Queries;
using NotelyCore.Domain;

namespace NotelyCore.Web.Pages.Notely
{
    public class EditModel : BasePageModel
    {
        [BindProperty(SupportsGet = true)]
        public Note Note { get; set; }

        public EditModel()
        {

        }
        public async Task OnGet(int noteId)
        {
            Note = await Mediator.Send(new GetNoteByIdQuery(noteId));
        }

        public async Task<IActionResult> OnPost()
        {
            await Mediator.Send(new UpdateNoteCommand
            {
                Body = Note.Body,
                Subject = Note.Subject,
                NoteId = Note.NoteId
            });

            return RedirectToPage("../Index");
        }
    }
}