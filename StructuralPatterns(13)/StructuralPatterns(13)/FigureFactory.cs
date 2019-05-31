using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace StructuralPatterns_13_
{
    //Abstract objects
    public abstract class FigureColor
    {
        public abstract SolidColorBrush Color { get; }
    }
    public abstract class FigureBorder
    {
        public abstract int Thickness { get; }
    }
    public abstract class FigureBorderColor
    {
        public abstract SolidColorBrush Color { get; }
    }

    //Concrete objects
    public class BlackColor : FigureColor
    {
        public override SolidColorBrush Color => Brushes.Black;
    }
    public class RedColor : FigureColor
    {
        public override SolidColorBrush Color => Brushes.Red;
    }
    public class ThickBorder : FigureBorder
    {
        public override int Thickness => 10;
    }
    public class ThinBorder : FigureBorder
    {
        public override int Thickness => 1;
    }
    public class GreenBorderColor : FigureBorderColor
    {
        public override SolidColorBrush Color => Brushes.Green;

    }
    public class YellowBorderColor : FigureBorderColor
    {
        public override SolidColorBrush Color => Brushes.Yellow;

    }

    //Abstract factory
    public abstract class FigureFactory
    {
        public abstract string Name { get; }
        public abstract FigureColor GetFigureColor();
        public abstract FigureBorder GetFigureBorder();
        public abstract FigureBorderColor GetFigureBorderColor();
        public abstract Shape GetShape();
    }

    //Concrete factories
    public class ThickBlackGreenRectangle : FigureFactory
    {
        public override string Name => "Thick black-green rectangle";

        public override FigureBorder GetFigureBorder()
        {
            return new ThickBorder();
        }

        public override FigureBorderColor GetFigureBorderColor()
        {
            return new GreenBorderColor();
        }

        public override FigureColor GetFigureColor()
        {
            return new BlackColor();
        }
        public override Shape GetShape()
        {
            return new Rectangle {StrokeThickness = GetFigureBorder().Thickness, Fill = GetFigureColor().Color, Stroke = GetFigureBorderColor().Color };
        }
    }
    public class ThinRedYellowRectangle : FigureFactory
    {
        public override string Name => "Thin red-yellow rectangle";

        public override FigureBorder GetFigureBorder()
        {
            return new ThinBorder();
        }
        public override FigureBorderColor GetFigureBorderColor()
        {
            return new YellowBorderColor();
        }
        public override FigureColor GetFigureColor()
        {
            return new RedColor();
        }
        public override Shape GetShape()
        {
            return new Rectangle { StrokeThickness = GetFigureBorder().Thickness, Fill = GetFigureColor().Color, Stroke = GetFigureBorderColor().Color};
        }
    }
    public class ThickRedGreenCircle : FigureFactory
    {
        public override string Name => "Thick red-green circle";

        public override FigureBorder GetFigureBorder()
        {
            return new ThickBorder();
        }

        public override FigureColor GetFigureColor()
        {
            return new RedColor();
        }
        public override FigureBorderColor GetFigureBorderColor()
        {
            return new GreenBorderColor();
        }
        public override Shape GetShape()
        {
            return new Ellipse { StrokeThickness = GetFigureBorder().Thickness, Fill = GetFigureColor().Color, Stroke = GetFigureBorderColor().Color  };
        }
    }
    public class ThinBlackYellowCircle : FigureFactory
    {
        public override string Name => "Thin black-yellow circle";

        public override FigureBorder GetFigureBorder()
        {
            return new ThinBorder();
        }
        public override FigureBorderColor GetFigureBorderColor()
        {
            return new YellowBorderColor();
        }
        public override FigureColor GetFigureColor()
        {
            return new BlackColor();
        }
        public override Shape GetShape()
        {
            return new Ellipse { StrokeThickness = GetFigureBorder().Thickness, Fill = GetFigureColor().Color, Stroke = GetFigureBorderColor().Color };
        }
    }

    //Client
    public class Figure
    {
        public string Name { get; }
        private FigureFactory factory;
        public Figure(FigureFactory _factory)
        {
            factory = _factory;
            Name = _factory.Name;
        }
        public Shape GetShape()
        {
            Shape shape = factory.GetShape();
            return shape;
        }
    }
}
