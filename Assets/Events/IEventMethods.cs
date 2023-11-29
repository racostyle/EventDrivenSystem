namespace Logic.Events
{
    public interface IEventMethods
    {
        void Invoke<T>(in T eventData) where T : struct, IEvent;
        void Subscribe<T>(EventBusDelegate<T> eventDelegate) where T : struct, IEvent;
        void Unsubscribe<T>(EventBusDelegate<T> eventDelegate) where T : struct, IEvent;
    }
}


