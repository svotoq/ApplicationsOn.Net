using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            human chel = new human();
            chel.Srubit(new DerevoCreate { Height = 10 });
            chel.Srubit(new KarlikCreate { Width = 50 });
            chel.Srubit(new KarlikCreate { Width = 5 });
            chel.Srubit(new DerevoCreate { Height = 10 });

        }
    }
    abstract class Tree
    {
        public string Name { get; set; }
        public Tree(string _name)
        {
            Name = _name;
        }
    }
    abstract class CreateTree
    {
        public abstract Tree CreateConcreteTree();
    }
    class Derevo : Tree
    {
        public int Height { get; set; }
        public Derevo(int _height) : base("Derevo")
        {
            Height = _height;
        }
        public void AddToPlace()
        {
            Console.WriteLine("Added");
        }
    }
    class Karlik : Tree
    {
        public int Width { get; set; }
        public Karlik(int _width) : base("Karlik")
        {
            Width = _width;
        }
    }
    class DerevoCreate : CreateTree
    {
        public int Height { get; set; }
        public override Tree CreateConcreteTree()
        {
            return new Derevo(Height);
        }
    }
    class KarlikCreate : CreateTree
    {
        public int Width { get; set; }
        public override Tree CreateConcreteTree()
        {
            return new Karlik(Width);
        }
    }
}
