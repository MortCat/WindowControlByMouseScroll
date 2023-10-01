using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Project_WindowControlByMouseScroll
{
    class Board
    {
        private Rectangle Body;
        private const int unit = 100;
        private static List<Rectangle> SnakeSegment = new List<Rectangle>();
        public void DrawBody(Canvas canvas, int X, int Y)
        {
            Body = new Rectangle
            {
                Width = unit,
                Height = unit,
                Fill = Brushes.Gold,
                Stroke = Brushes.Black,
                StrokeThickness = 0.5
            };
            SnakeSegment.Add(Body);
            Canvas.SetLeft(Body, X);
            Canvas.SetTop(Body, Y);
            canvas.Children.Add(Body);
        }
    }
}
