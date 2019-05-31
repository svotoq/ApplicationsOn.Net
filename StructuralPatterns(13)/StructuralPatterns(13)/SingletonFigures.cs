using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns_13_
{
    public class SingletonFigures
    {
        private static SingletonFigures figures = new SingletonFigures();
        public ObservableCollection<Figure> Figures { get; }
        private SingletonFigures()
        {
            Figures = new ObservableCollection<Figure>
            {
                new Figure(new Circle()),
                //new Figure(new ThinBlackYellowCircle()),
                //new Figure(new ThickBlackGreenRectangle()),
                //new Figure(new ThinRedYellowRectangle())
            };
        }
        public static SingletonFigures GetSingletonFigures()
        {
            if(figures == null)
            {
                figures = new SingletonFigures();
            }
            return figures;
        }
    }
}
