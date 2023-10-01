using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_WindowControlByMouseScroll
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public double Scale = 1.0;

        public MainWindow()
        {
            InitializeComponent();
            DrawBody(SnackRun, 300, 300);


            SnackRun.PreviewMouseWheel += CanvasWindowScrollByMouseWheel;
        }
        private void CanvasWindowScrollByMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;

            //計算縮放比例
            double dx = e.Delta > 0 ? 0.1 : -0.1;
            Scale += dx;

            //限制縮放範圍
            if (Scale < 0.1) Scale = 0.1;
            if (Scale > 2.0) Scale = 2.0;

            ScrollViewer.LayoutTransform = new ScaleTransform(Scale, Scale);
        }

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
