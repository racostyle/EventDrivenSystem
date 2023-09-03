using System;
using UnityEngine;

namespace Logic.Events
{
    public class EventDefinitions 
    {
        public struct StartTestEvent : IEvent
        {
            public string Text;
            public Vector3 Position;
        }
    }
}
