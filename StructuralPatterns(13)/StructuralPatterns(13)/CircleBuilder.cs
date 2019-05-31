using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace StructuralPatterns_13_
{
    public abstract class CircleBuilder
    {
        public Ellipse Circle { get; private set; }
        public void CreateCircle()
        {
            Circle = new Ellipse();
        }
        public abstract void SetBorderThickness();
        public abstract void SetBorderColor();
        public abstract void SetFillColor();
        public abstract void SetSize();
        public abstract Ellipse Clone();
    }
    public class CustomizableFigure
    {
        public Ellipse GetCircle(CircleBuilder circleBuilder)
        {
            circleBuilder.CreateCircle();
            circleBuilder.SetBorderColor();
            circleBuilder.SetFillColor();
            circleBuilder.SetBorderThickness();
            circleBuilder.SetSize();
            return circleBuilder.Circle;
        }
    }
    public class DefaultCircleBuilder : CircleBuilder
    {
        public int Thickness { get; set; } 
        public Brush FillColor { get; set; }
        public Brush BorderColor { get; set; }
        public int Width { get; set; }
        public int Height { get; set; } 
        public override void SetBorderColor()
        {
            this.Circle.Stroke = BorderColor;
        }

        public override void SetFillColor()
        {
            this.Circle.Fill = FillColor;
        }

        public override void SetBorderThickness()
        {
            this.Circle.StrokeThickness = Thickness;
        }

        public override void SetSize()
        {
            this.Circle.Height = Height;
            this.Circle.Width = Width;
        }

        public override Ellipse Clone()
        {
            return new Ellipse
            {
                Stroke = BorderColor,
                Fill = FillColor,
                StrokeThickness = Thickness,
                Height = Height,
                Width = Width
            };
        }
    }
}
