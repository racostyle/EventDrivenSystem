using System;
using System.Collections.Generic;

namespace Logic.Events
{
    internal class ExampleClass
    {
        #region [EVENTS]
        void RegisterEvent()
        {
            EventManager.Instance.Subscribe<EventDefinitions.StartTestEvent>(OnStartTestEvent);
        }

        private void OnStartTestEvent(EventDefinitions.StartTestEvent args)
        {
            string text = args.Text;
            UnityEngine.Vector3 position = args.Position;
        }

        void RunEvent()
        {
            EventManager.Instance.Invoke(new EventDefinitions.StartTestEvent
            {
                Text = "text", 
                Position = UnityEngine.Vector3.up
            });
        }

        void DeregisterEvent()
        {
            EventManager.Instance.Unsubscribe<EventDefinitions.StartTestEvent>(OnStartTestEvent);
        }
        #endregion [EVENTS]

        #region [DELEGATES]
        void RegisterDelegate()
        {
            EventManager.Instance.GetBoolDelegate = CustomDelegateFunction;
            //EventManager.Instance.GetBoolDelegate = (i) => i > 5;          
        }

        public bool CustomDelegateFunction(int i)
        {
            return i > 5;
        }

        void UseDelegate()
        {
            EventManager.Instance.GetBoolDelegate(5);
        }
        #endregion [DELEGATES]
    }
}
