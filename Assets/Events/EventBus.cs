using System;
using System.Collections.Generic;

namespace Logic.Events
{
    public delegate void EventBusDelegate<T>(T gameEvent) where T : struct, IEvent;
    public class EventBus : IEventMethods
    {      
        private Dictionary<Type, Delegate> eventRegistry;

        public EventBus()
        {
            eventRegistry = new Dictionary<Type, Delegate>();
        }

        #region [REGISTER METHODS]
        public void Subscribe<T>(EventBusDelegate<T> eventDelegate) where T : struct, IEvent
        {
            var t = typeof(T);
            if (eventRegistry.TryGetValue(t, out Delegate d))
            {
                eventRegistry[t] = Delegate.Combine(d, eventDelegate);
            }
            else
            {
                eventRegistry.Add(t, eventDelegate);
            }
        }

        public void Unsubscribe<T>(EventBusDelegate<T> eventDelegate) where T : struct, IEvent
        {
            var t = typeof(T);
            if (eventRegistry.TryGetValue(t, out Delegate d))
            {
                Delegate currentDelegate = Delegate.Remove(d, eventDelegate);

                if (currentDelegate == null)
                {
                    eventRegistry.Remove(t);
                }
                else
                {
                    eventRegistry[t] = currentDelegate;
                }
            }
        }
        #endregion

        #region [START METHOD]
        public void Invoke<T>(in T eventData) where T : struct, IEvent
        {
            if (eventRegistry.TryGetValue(typeof(T), out Delegate d))
            {
                EventBusDelegate<T> actionDelegate = d as EventBusDelegate<T>;
                actionDelegate?.Invoke(eventData);
            }
        }
        #endregion
    }
}


