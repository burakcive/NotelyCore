using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotelyCore.Application.Links.Commands;
using NotelyCore.Application.Links.Models;
using NotelyCore.Application.Links.Queries;
using NotelyCore.Domain.Identity;

namespace NotelyCore.Web.Pages.Links
{
    public class IndexModel : BasePageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public LinksViewModel LinksViewModel { get; set; }

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
            LinksViewModel = await Mediator.Send(
                new GetLinksQuery
                {
                    User = signedInUser,
                    CurrentPage = CurrentPage,
                    PageSize = PageSize
                }
            );

            Count = LinksViewModel.TotalLinks;
        }

        public async Task<IActionResult> OnPostAddLink(string url, string description)
        {
            var signedInUser = await userManager.GetUserAsync(HttpContext.User);

            await Mediator.Send(new UpsertLinkCommand
            {
                Description = description,
                Url = url,
                User = signedInUser
            });

            return new JsonResult(new { succeeded = true });
        }

        public async Task<IActionResult> OnPostLinkItemDelete(int linkId)
        {
            await Mediator.Send(new DeleteLinkCommand { LinkId = linkId });

            return new JsonResult(new { succeeded = true });
        }
    }
}