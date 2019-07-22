using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Notely.Application.Notes.Queries;
using NotelyCore.Domain;

namespace NotelyCore.Web.Pages
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(IMediator mediator) : base(mediator)
        {

        }
        public IEnumerable<Note> Notes { get; set; }

        public async Task OnGet()
        {
            //Notes = noteRepository.GetAll();
            Notes = await Mediator.Send(new GetNotesQuery());
        }
    }
}
