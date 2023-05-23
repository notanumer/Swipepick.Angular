using System.Net;

namespace Swipepick.Angular.Infrastructure.Abstractions.Exceptions;

public class TestNotFoundException : RestException
{
    public TestNotFoundException(string message, Exception inner = null) : base(message, inner)
    {
    }

    public override HttpStatusCode Code => HttpStatusCode.NotFound;
}
