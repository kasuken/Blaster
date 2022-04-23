using System.Globalization;
using Blaster.Abstracts;

namespace Blaster.Helpers;

internal static class ExtensionMethods
{
    public static string FormatWith(this string format, params object[] args)
    {
        return string.Format(CultureInfo.InvariantCulture, format ?? string.Empty, args);
    }

    public static void ThrowObserverNotFound(this IEntity entity, object eventMessage)
    {
        string exceptionMessage =
            "Entity of type '{0}' raised an event of type '{1}' but not handler could be found to handle the message."
                .FormatWith(entity.GetType().Name, eventMessage.GetType().Name);

        throw new HandlerForBlasterEventNotFoundException(exceptionMessage);
    }
}