using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns_15_
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            KeyBoard allReleased = new KeyBoard();
            StandingCommand standing = new StandingCommand(player);
            allReleased.SetCommad(standing);
            WalkCommad walk = new WalkCommad(player);
            KeyBoard W = new KeyBoard();
            W.SetCommad(walk);
            KeyBoard ShiftW = new KeyBoard();
            RunningCommand running = new RunningCommand(player);
            ShiftW.SetCommad(running);

            W.ButtonPressed();
            ShiftW.ButtonPressed();
            allReleased.ButtonPressed();

            Console.WriteLine("\n\t\tStates");
            MyObject hero = new MyObject();
            hero.ChangeState();
            hero.ChangeState();

            Console.WriteLine("\n\t\tMemento");
            var memento = hero.State;
            hero.ChangeState();
            hero.State = memento;
        }
    }

}
