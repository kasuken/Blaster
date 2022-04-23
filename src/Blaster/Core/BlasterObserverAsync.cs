using Blaster.Abstracts;

namespace Blaster.Core;

public abstract class BlasterObserverAsync<TEvent> : IBlasterObserverAsync<TEvent> where TEvent : class, IBlasterEvent
{
    public abstract Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default);

    #region Dispose
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~BlasterObserverAsync()
    {
        Dispose(false);
    }
    #endregion
}