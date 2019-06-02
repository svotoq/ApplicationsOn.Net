namespace BehavioralPatterns_15_
{
    public class MyObject
    {
        private ObjectState state;
        public MyObject()
        {
            State = new StandingState();
        }
        public ObjectState State
        {
            get => state;
            set
            {
                state = value;
                System.Console.WriteLine("State: " + state.GetType().Name);
            }
        }
        public void ChangeState()
        {
            state.HandleInput(this);
        }
    }
}