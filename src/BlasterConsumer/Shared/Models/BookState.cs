using Blaster.Core;
using BlasterConsumer.Shared.Events;

namespace BlasterConsumer.Shared.Models;

public class SelectedBook : EntityBase
{
    public Guid BookId { get; private set; } = Guid.Empty;
    public string Title { get; private set; } = string.Empty;

    protected SelectedBook()
    { }

    private void Apply(BookSelected @event)
    {
        Id = @event.BookId;

        BookId = @event.BookId;
        Title = @event.Title;
    }
}