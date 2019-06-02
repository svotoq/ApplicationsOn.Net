using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns_14_
{
    public interface ITransport
    {
        void Drive();
    }
    public class Car : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Car is driving on the road");
        }
    }
    public class Player
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    public interface IAnimal
    {
        void Move();
    }
    public class Horse : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Horse is running in the forest");
        }
    }
    public class HorseToTransport : ITransport
    {
        private Horse horse;
        public HorseToTransport(Horse _horse)
        {
            horse = _horse;
        }
        public void Drive()
        {
            horse.Move();
        }
    }
}
