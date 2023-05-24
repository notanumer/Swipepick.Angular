using MediatR;

namespace Swipepick.Angular.UseCases.Tests.GetTestsUrls;

public class GetTestsUrlsQuery : IRequest<IEnumerable<string>>
{
    required public string UserEmail { get; set; }
}
