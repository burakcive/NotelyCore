using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notely.Application.Links.Commands;
using Notely.Application.Links.Queries;
using NotelyCore.Domain;
using NotelyCore.Domain.Identity;

namespace NotelyCore.Web.Pages.Links
{
    public class EditModel : BasePageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        public EditModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public Link Link { get; set; }

 

        public async Task OnGet(int? linkId)
        {
            if (linkId.HasValue)
            {
                Link = await Mediator.Send(new GetLinkByIdQuery { LinkId = linkId.Value });
            }
            else
            {
                Link = new Link();
                TempData["IsAddMode"] = true;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            var signedInUser = await userManager.GetUserAsync(HttpContext.User);

            await Mediator.Send(new UpsertLinkCommand
            {
                LinkId = Link.LinkId,
                Description = Link.Description,
                LevelOfImportance = Link.LevelOfImportance,
                Url = Link.Url,
                User = signedInUser
            });

            return RedirectToPage("./Index");
        }
    }
}