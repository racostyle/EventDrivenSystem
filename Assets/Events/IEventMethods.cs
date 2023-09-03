namespace Logic.Events
{
    public interface IEventMethods
    {
        void StartEvent<T>(in T eventData) where T : struct, IEvent;
        void RegisterListener<T>(EventBusDelegate<T> eventDelegate) where T : struct, IEvent;
        void DeregisterListener<T>(EventBusDelegate<T> eventDelegate) where T : struct, IEvent;
    }
}


