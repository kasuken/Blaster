namespace Blaster.Abstracts;

public interface IRouteEvents
{
    void Register<T>(Action<T> handler);
    void Register(IEntity aggregate);
    void Dispatch(object eventMessage);
}