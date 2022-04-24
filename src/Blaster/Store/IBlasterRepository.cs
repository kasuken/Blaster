using Blaster.Abstracts;

namespace Blaster.Store;

public interface IBlasterRepository : IDisposable
{
    Task<TEntity> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IEntity;
    Task<TEntity> GetByIdAsync<TEntity>(Guid id, int version) where TEntity : class, IEntity;

    Task SaveAsync(IBlasterEvent @event);

    //Task UpdateStateAsync(IBlasterEvent @event);
}