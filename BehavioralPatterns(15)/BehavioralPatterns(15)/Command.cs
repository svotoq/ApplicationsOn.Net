using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns_15_
{
    public interface ICommand
    {
        void Execute();
    }
    public class WalkCommad : ICommand
    {
        private Player player;
        public WalkCommad(Player _player)
        {
            player = _player;
        }
        public void Execute()
        {
            player.State = PlayerState.Walking;
            player.Do();
        }
    }
    public class StandingCommand : ICommand
    {
        private Player player;
        public StandingCommand(Player _player)
        {
            player = _player;
        }
        public void Execute()
        {
            player.State = PlayerState.Standing;
            player.Do();
        }
    }
    public class RunningCommand : ICommand
    {
        private Player player;
        public RunningCommand(Player _player)
        {
            player = _player;
        }
        public void Execute()
        {
            player.State = PlayerState.Running;
            player.Do();
        }
    }

    public class Player
    {
        public PlayerState State { get; set; }
        public Player()
        {
            State = PlayerState.Standing;
        }
        public void Do()
        {
            if(State == PlayerState.Running)
            {
                Console.WriteLine("Персонаж бежит");
            }
            if(State == PlayerState.Standing)
            {
                Console.WriteLine("Персонаж стоит");
            }
            if(State == PlayerState.Walking)
            {
                Console.WriteLine("Персонаж идет");
            }
        }
    }
    public class KeyBoard
    {
        private ICommand command;
        public void SetCommad(ICommand _command)
        {
            command = _command;
        }
        public void ButtonPressed()
        {
            command.Execute();
        }
    }
}
