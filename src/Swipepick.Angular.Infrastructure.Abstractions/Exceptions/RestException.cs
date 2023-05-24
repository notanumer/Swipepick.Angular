using System.Net;

namespace Swipepick.Angular.Infrastructure.Abstractions.Exceptions;

public abstract class RestException : Exception
{
    public abstract HttpStatusCode Code { get; }

    public RestException(string message, Exception inner = null) : base(message, inner)
    {
        
    }
}
