using System.Collections;
using Blaster.Abstracts;

namespace Blaster.Core;

public abstract class EntityBase : IEntity, IEquatable<IEntity>
{
    private readonly ICollection<object> _uncommittedEvents = new LinkedList<object>();

    private IRouteEvents _registeredRoutes;

    public Guid Id { get; }

    protected EntityBase()
        : this(null)
    { }

    protected EntityBase(IRouteEvents handler)
    {
        if (handler == null)
        {
            return;
        }

        RegisteredRoutes = handler;
        RegisteredRoutes.Register(this);
    }

    protected IRouteEvents RegisteredRoutes
    {
        get => _registeredRoutes ??= new ConventionEventRouter(true, this);
        set => _registeredRoutes = value ?? throw new InvalidOperationException("Entity must have an event router to function");
    }

    public void ApplyEvent(object @event)
    {
        RegisteredRoutes.Dispatch(@event);
    }

    public ICollection GetUncommittedEvents() => (ICollection)_uncommittedEvents;

    public void ClearUncommittedEvents() => _uncommittedEvents.Clear();

    public bool Equals(IEntity? other) => null != other && other.Id == Id;

    public override int GetHashCode() => Id.GetHashCode();

    public override bool Equals(object obj) => Equals(obj as IEntity);
}