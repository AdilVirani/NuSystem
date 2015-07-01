using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace WorkTopExample
{
    class LinkLine : UIElement
    {
        UIElement start;
        UIElement end;
        Line line;

        public LinkLine()
        {
            line = new Line();
            start = new UIElement();
            end = new UIElement();

            line.Stroke = System.Windows.Media.Brushes.Black;
            line.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            line.StrokeThickness = 10;
            line.HorizontalAlignment = HorizontalAlignment.Left;
            line.VerticalAlignment = VerticalAlignment.Center;

        }

        internal void addToCanvas(Canvas canvas)
        {
            canvas.Children.Add(line);
        }
        internal void setStarting(Point point)
        {
            line.X1 = point.X;
            line.Y1 = point.Y;
        }
        internal void setLine(Point point)
        {
            line.X1 = point.X;
            line.Y1 = point.Y;
            line.X2 = point.X;
            line.Y2 = point.Y;
        }
        internal Line getLine()
        {
            return line;
        }
        internal Boolean checkIfStart(UIElement el)
        {
            if(el == start)
            {
                return true;
            }
            return false;
        }
        internal void addElements(UIElement elA, UIElement elB)
        {
            start = elA;
            end = elB;
            Console.WriteLine("start:" + elA);
        }
    }
}
