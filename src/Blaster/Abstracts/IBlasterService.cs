using Blaster.Core;

namespace Blaster.Abstracts;

public interface IBlasterService
{
    event EventHandler<BlasterNotification> NotificationReceived;
    Task UpdateStateAsync<TEntity>(IBlasterEvent @event) where TEntity : class, IEntity;
}