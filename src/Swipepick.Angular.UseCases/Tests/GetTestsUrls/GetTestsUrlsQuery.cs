using MediatR;

namespace Swipepick.Angular.UseCases.Tests.GetTestsUrls;

public class GetTestsUrlsQuery : IRequest<IEnumerable<string>>
{
    public string UserEmail { get; set; }
}
