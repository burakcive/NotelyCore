using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NotelyCore.Web.Pages
{
    public class BasePageModel : PageModel
    {
        public BasePageModel(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }
    }
}
