using Blaster.Core;

namespace BlasterConsumer.Shared.Events;

public class BookSelected : BlasterEvent
{
    public readonly Guid BookId;
    public readonly string Title;

    public BookSelected(Guid observedId, string title) : base(observedId)
    {
        BookId = observedId;
        Title = title;
    }
}