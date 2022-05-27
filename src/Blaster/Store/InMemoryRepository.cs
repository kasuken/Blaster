using Blaster.Abstracts;
using Blaster.Core;

namespace Blaster.Store;

public class InMemoryRepository : IBlasterRepository
{
    public IEnumerable<BlasterEvent> Events { get; private set; } = Enumerable.Empty<BlasterEvent>();

    private static TAggregate ConstructAggregate<TAggregate>()
    {
        return (TAggregate)Activator.CreateInstance(typeof(TAggregate), true);
    }

    public async Task<TAggregate> GetByIdAsync<TAggregate>(Guid id) where TAggregate : class, IEntity
    {
        return await GetByIdAsync<TAggregate>(id, 0);
    }

    public Task<TAggregate> GetByIdAsync<TAggregate>(Guid id, int version) where TAggregate : class, IEntity
    {
        var aggregate = ConstructAggregate<TAggregate>();
        Events.ForEach(aggregate.ApplyEvent);
        return Task.FromResult(aggregate);
    }

    public Task SaveAsync(IBlasterEvent @event)
    {
        Events = Events.Concat(new List<BlasterEvent>
        {
            (BlasterEvent)@event
        });

        return Task.CompletedTask;
    }

    #region Dispose
    public void Dispose(bool disposing)
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

    ~InMemoryRepository()
    {
        Dispose(false);
    }
    #endregion
}

public static class Helpers
{
    public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
    {
        if (items == null)
            return;
        foreach (T obj in items)
            action(obj);
    }
}