namespace Logic.Events
{
    public abstract class AEventDelegates
    {
        public delegate bool GetBool(int i);
        public GetBool GetBoolDelegate;
    }
}


