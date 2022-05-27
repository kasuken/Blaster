namespace Blaster.Abstracts;

public interface IBlasterObserverAsync
{
}

public interface IBlasterObserverAsync<in TEvent> : IDisposable, IBlasterObserverAsync where TEvent : class, IBlasterEvent
{
    Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default);
}