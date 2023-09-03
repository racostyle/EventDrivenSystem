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
       
        public void RegisterListener<T>(EventBusDelegate<T> eventDelegate) where T : struct, IEvent
        {
            _eventBus.RegisterListener<T>(eventDelegate);
        }
        public void DeregisterListener<T>(EventBusDelegate<T> eventDelegate) where T : struct, IEvent
        {
            _eventBus.DeregisterListener<T>(eventDelegate);
        }

        public void StartEvent<T>(in T eventData) where T : struct, IEvent
        {
            _eventBus.StartEvent<T>(eventData);
        }
    }
}
