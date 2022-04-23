using Blaster.Abstracts;

namespace Blaster.Core;

public abstract class BlasterEvent : IBlasterEvent
{
    public Guid ObservedId { get; }

    protected BlasterEvent(Guid observedId)
    {
        ObservedId = observedId;
    }
}