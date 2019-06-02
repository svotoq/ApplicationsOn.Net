using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns_14_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tAdapter");
            Player Player = new Player();
            Car Car = new Car();
            Player.Travel(Car);
            Horse Horse = new Horse();
            HorseToTransport HorseTransport = new HorseToTransport(Horse);
            Player.Travel(HorseTransport);

            Console.WriteLine("\n\t\tDecorator");
            Text text = new DefaultText();
            Console.WriteLine(text.Name);
            text = new TextWithBorder(text);
            Console.WriteLine(text.Name);
            text = new BlueText(text);
            Console.WriteLine(text.Name);
            text = new ShadedText(text);
            Console.WriteLine(text.Name);

            Console.WriteLine("\n\t\tComposite");
            IComponent BelarussianMap = new Map("Карта Беларуси");
            IComponent GorkiMap = new Map("Карта Горок");
            IComponent MinskMap = new Map("Карта Минска");
            IComponent BSTUMap = new Map("Карта университета БГТУ");
            MinskMap.Add(BSTUMap);
            BelarussianMap.Add(GorkiMap);
            BelarussianMap.Add(MinskMap);
            BelarussianMap.Print();
        }
    }
   
}
