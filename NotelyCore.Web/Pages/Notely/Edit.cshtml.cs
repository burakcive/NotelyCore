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

            await Mediator.Send(new UpsertNoteCommand
            {
                Body = Note.Body,
                Subject = Note.Subject,
                NoteId = Note.NoteId,
                Priorty = Note.Priority
            });

            return RedirectToPage("../Index");
        }

       
    }
}