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
        private Rectangle Body;
        private const int unit = 100;
        private static List<Rectangle> SnakeSegment = new List<Rectangle>();
        private ScaleTransform scaleTransform = new ScaleTransform(1, 1);

        public MainWindow()
        {
            InitializeComponent();
            DrawBody(SnackRun, 300, 300);


            SnackRun.PreviewMouseWheel += CanvasWindowScrollByMouseWheel;

            SnackRun.RenderTransform = scaleTransform;
        }
        private void CanvasWindowScrollByMouseWheel(object sender, MouseWheelEventArgs e)
        {
            Point mousePosition = e.GetPosition(SnackRun);
            e.Handled = true;

            //計算縮放比例
            double dx = e.Delta > 0 ? 0.1 : -0.1;
            Scale += dx;

            ////限制縮放範圍
            if (Scale < 0.1) Scale = 0.1;
            if (Scale > 2.0) Scale = 2.0;


            

            ScrollViewer.LayoutTransform = new ScaleTransform(Scale, Scale);
            SnackRun.RenderTransform = ScrollViewer.LayoutTransform;
            SnackRun.RenderTransformOrigin = new Point(mousePosition.X / SnackRun.ActualWidth, mousePosition.Y / SnackRun.ActualHeight);
        }



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

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition(SnackRun);
            Console.WriteLine("=====" + mousePosition);
            Point scaledMousePosition = scaleTransform.Transform(mousePosition);
            Console.WriteLine("========" + scaledMousePosition);

            // 將滑鼠位置設定為Label的位置
            Canvas.SetLeft(mousePositionLabel, mousePosition.X);
            Canvas.SetTop(mousePositionLabel, mousePosition.Y);

            // 更新 UI 元素顯示滑鼠座標
            mousePositionLabel.Content = $"Position:({mousePosition.X}, {mousePosition.Y})";

            

        }

        // 實現畫面縮放的方法，這裡使用按鈕演示，你可以根據實際情況進行調整
        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            scaleTransform.ScaleX += 0.1;
            scaleTransform.ScaleY += 0.1;
        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            scaleTransform.ScaleX -= 0.1;
            scaleTransform.ScaleY -= 0.1;
        }
    }

}
