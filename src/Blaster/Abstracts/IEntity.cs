using System.Collections;

namespace Blaster.Abstracts;

public interface IEntity
{
    Guid Id { get; }

    void ApplyEvent(object @event);
    ICollection GetUncommittedEvents();
    void ClearUncommittedEvents();
}