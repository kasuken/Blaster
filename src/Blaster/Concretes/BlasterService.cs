using Blaster.Abstracts;
using Blaster.Core;
using Blaster.Store;
using Microsoft.Extensions.Logging;

namespace Blaster.Concretes;

public sealed class BlasterService : IBlasterService
{
    public event EventHandler<BlasterNotification> NotificationReceived;

    private readonly IBlasterRepository _repository;
    private readonly ILogger _logger;

    public BlasterService(IBlasterRepository repository,
        ILoggerFactory loggerFactory)
    {
        _repository = repository;
        _logger = loggerFactory.CreateLogger(GetType()); 
    }

    public async Task UpdateStateAsync<TEntity>(IBlasterEvent @event) where TEntity : class, IEntity
    {
        try
        {
            await _repository.SaveAsync(@event);
            var entity = await _repository.GetByIdAsync<TEntity>(@event.ObservedId);
            OnNotificationReceived(new BlasterNotification(entity));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    private void OnNotificationReceived(BlasterNotification notification)
    {
        NotificationReceived?.Invoke(this, notification);
    }
}