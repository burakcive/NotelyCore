using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notely.Application.Notes.Commands;
using Notely.Application.Notes.Queries;
using NotelyCore.Domain;
using NotelyCore.Domain.Identity;

namespace NotelyCore.Web.Pages.Notely
{

    public class EditModel : BasePageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        [BindProperty(SupportsGet = true)]
        public Note Note { get; set; }

        public EditModel(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
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
            var signedInUser = await signInManager.UserManager.GetUserAsync(HttpContext.User);

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