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
    public abstract class FigureBorderThickness
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
    public class ThickBorder : FigureBorderThickness
    {
        public override int Thickness => 10;
    }
    public class ThinBorder : FigureBorderThickness
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
        public abstract FigureColor FigureColor { get; set; }
        public abstract FigureBorderThickness FigureBorderThickness { get; set; }
        public abstract FigureBorderColor FigureBorderColor { get; set; }
        public abstract Shape GetShape { get; }
    }

    //Concrete factories
    public class Circle : FigureFactory
    {
        public override FigureColor FigureColor { get; set; }
        public override FigureBorderThickness FigureBorderThickness { get; set; }
        public override FigureBorderColor FigureBorderColor { get; set; }
        public override Shape GetShape { get; }
    }
    public class Rectangle
    {

    }
    //Builder
    public abstract class CircleBuilder
    {
        public Circle Circle { get; private set; }
        public void CreateCircle()
        {
            Circle = new Circle();
        }
        public abstract void SetFigureColor();
        public abstract void SetFigureBorderThickness();
        public abstract void SetFigureBorderColor();
    }
    //Client
    public class Figure
    {
        public Circle Create(CircleBuilder circleBuilder)
        {
            circleBuilder.CreateCircle();
            circleBuilder.SetFigureBorderColor();
            circleBuilder.SetFigureBorderThickness();
            circleBuilder.SetFigureColor();
            return circleBuilder.Circle;
        }
    }

    public class ThickYellowRedCircle : CircleBuilder
    {
        public override void SetFigureBorderColor()
        {
            this.Circle.FigureBorderColor = new FigureBorderColor
        }

        public override void SetFigureBorderThickness()
        {
            throw new NotImplementedException();
        }

        public override void SetFigureColor()
        {
            throw new NotImplementedException();
        }
    }
}
