using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns_14_
{
    public interface IComponent
    {
        string Title { get; set; }
        void Print();
        void Add(IComponent component);
        IComponent Find(string title);
    }
    public class Map : IComponent
    {
        private readonly List<IComponent> _map = new List<IComponent>();
        public string Title { get; set; }
        public Map(string _title)
        {
            Title = _title;
        }
        public void Add(IComponent component)
        {
            _map.Add(component);
        }
        public void Print()
        {
            Console.WriteLine(Title);
            if (_map.Count > 0)
            {
                Console.WriteLine("\tВ нее входят:");
                foreach (var component in _map)
                {
                    component.Print();
                }
            }
        }

        public IComponent Find(string title)
        {
            return _map.Where(c => c.Title == title).SingleOrDefault();
        }
    }
}
