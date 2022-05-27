using System;
using System.Threading.Tasks;
using Blaster.Abstracts;
using Blaster.Concretes;
using Blaster.Core;
using Blaster.Store;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Blaster.Tests
{
    public class BlasterTest
    {
        private readonly IBlasterService _blaster;

        private BookState _book = default!;

        public BlasterTest()
        {
             var repository = new InMemoryRepository();
            _blaster = new BlasterService(repository, new NullLoggerFactory());

            _blaster.NotificationReceived += OnNotificationReceived;
        }

        private void OnNotificationReceived(object? sender, BlasterNotification notification)
        {
            _book = (BookState)notification.Entity;
        }

        [Fact]
        public async Task Can_Save_BlasterEvent()
        {
            var redBookId = Guid.NewGuid();
            var blueBookId = Guid.NewGuid();

            var bookSelected = new BookSelected(redBookId, "Red Book");
            await _blaster.UpdateStateAsync<BookState>(bookSelected);

            bookSelected = new BookSelected(blueBookId, "Blue Book");
            await _blaster.UpdateStateAsync<BookState>(bookSelected);

            Assert.Equal(blueBookId, _book.BookId);
        }
    }

    public class BookState : EntityBase
    {
        public Guid BookId { get; private set; } = Guid.Empty;
        public string Title { get; private set; } = string.Empty;

        protected BookState()
        {}

        private void Apply(BookSelected @event)
        {
            Id = @event.BookId;

            BookId = @event.BookId;
            Title = @event.Title;
        }
    }

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
}