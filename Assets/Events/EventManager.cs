using System.Collections;
using System.Collections.Generic;
using System;

namespace Logic.Events
{
    public class EventManager : AEventDelegates, IEventMethods
    {

        private static EventManager _instance;
        public static EventManager Instance => _instance;

        private EventBus _eventBus;

        public EventManager(EventBus eventBus)
        {
            if (_instance == null)
            {
                _instance = this;
                _eventBus = eventBus;
            }
        }
       
        public void Subscribe<T>(EventBusDelegate<T> eventDelegate) where T : struct, IEvent
        {
            _eventBus.Subscribe<T>(eventDelegate);
        }
        public void Unsubscribe<T>(EventBusDelegate<T> eventDelegate) where T : struct, IEvent
        {
            _eventBus.Unsubscribe<T>(eventDelegate);
        }

        public void Invoke<T>(in T eventData) where T : struct, IEvent
        {
            _eventBus.Invoke<T>(eventData);
        }
    }
}
