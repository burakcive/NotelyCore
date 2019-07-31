using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notely.Application.Links.Commands;
using Notely.Application.Links.Queries;
using NotelyCore.Domain;
using NotelyCore.Domain.Identity;

namespace NotelyCore.Web.Pages.Links
{
    [Authorize]
    public class IndexModel : BasePageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public IndexModel(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IEnumerable<Link> Links { get; set; }

        public async Task OnGet()
        {
            var signedInUser = await signInManager.UserManager.GetUserAsync(HttpContext.User);
            Links = await Mediator.Send(
                new GetLinksQuery
                {
                    User = signedInUser
                }
            );
        }

        public async Task<IActionResult> OnPostAddLink(string url, string description)
        {
            var signedInUser = await signInManager.UserManager.GetUserAsync(HttpContext.User);

            await Mediator.Send(new UpsertLinkCommand {
                Description = description,
                Url = url,
                User = signedInUser
            });

            return new JsonResult(new { succeeded = true });
        }
    }
}