using System.Runtime.Serialization;

namespace Blaster.Helpers;

public class HandlerForBlasterEventNotFoundException : Exception
{
    public HandlerForBlasterEventNotFoundException()
    { }

    public HandlerForBlasterEventNotFoundException(string message)
        : base(message)
    { }

    public HandlerForBlasterEventNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    { }

    public HandlerForBlasterEventNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    { }
}