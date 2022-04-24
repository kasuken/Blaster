using Blaster.Abstracts;

namespace Blaster.Core;

public class BlasterNotification : EventArgs
{
    public readonly IEntity Entity;

    public BlasterNotification(IEntity entity)
    {
        Entity = entity;
    }
}