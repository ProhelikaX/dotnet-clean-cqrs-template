using MediatR;

namespace CleanCQRS.Web.Pages;

public class IndexModel : BasePageModel
{
    public IndexModel(ILogger<IndexModel> logger, IMediator mediator) : base(mediator)
    {
    }
}