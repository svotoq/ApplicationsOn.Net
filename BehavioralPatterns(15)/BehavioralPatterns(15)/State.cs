using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns_15_
{
    public enum PlayerState
    {
        Standing,
        Walking,
        Running,
    }

    public interface ObjectState
    {
        void HandleInput(MyObject hero);
    }

    public class StandingState : ObjectState
    {
        public void HandleInput(MyObject hero)
        {
            hero.State = new WalkingState();
        }
    }

    public class WalkingState : ObjectState
    {
        public void HandleInput(MyObject hero)
        {
            hero.State = new StandingState();
        }
    }
}
