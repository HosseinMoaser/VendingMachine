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

namespace VendingMachine.App.Components
{
    /// <summary>
    /// Interaction logic for Spinner.xaml
    /// </summary>
    public partial class Spinner : UserControl
    {
        public Spinner()
        {
            InitializeComponent();
            SizeChanged += Spinner_SizeChanged;
            Refresh();
        }
        private void Spinner_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Transform.CenterX = ActualWidth / 2;
            Transform.CenterY = ActualHeight / 2;
            Refresh();
        }
        #region Dependency Properties
        #region BallBrush
        public static DependencyProperty BallBrushProperty = DependencyProperty.Register(nameof(BallBrush), typeof(Brush), typeof(Spinner), new UIPropertyMetadata(Brushes.Blue, PropertyChangedCallback));
        public Brush BallBrush
        {
            get { return (Brush)GetValue(BallBrushProperty); }
            set { SetValue(BallBrushProperty, value); }
        }
        #endregion
        #region Balls
        public static DependencyProperty BallsProperty = DependencyProperty.Register(nameof(Balls), typeof(int), typeof(Spinner), new UIPropertyMetadata(8, PropertyChangedCallback, CoerceBallsValue));
        public int Balls
        {
            get { return (int)GetValue(BallsProperty); }
            set { SetValue(BallsProperty, value); }
        }
        private static object CoerceBallsValue(DependencyObject d, object baseValue)
        {
            var spinner = (Spinner)d;
            int value = Convert.ToInt32(baseValue);
            value = Math.Max(1, value);
            value = Math.Min(100, value);
            return value;
        }
        #endregion
        #region BallSize
        public static DependencyProperty BallSizeProperty = DependencyProperty.Register(nameof(BallSize), typeof(double), typeof(Spinner), new UIPropertyMetadata(20d, PropertyChangedCallback, CoerceBallSizeValue));
        public double BallSize
        {
            get { return (double)GetValue(BallSizeProperty); }
            set { SetValue(BallSizeProperty, value); }
        }
        private static object CoerceBallSizeValue(DependencyObject d, object baseValue)
        {
            var spinner = (Spinner)d;
            double value = Convert.ToDouble(baseValue);
            value = Math.Max(1, value);
            value = Math.Min(100, value);
            return value;
        }
        #endregion
        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var spinner = (Spinner)d;
            spinner.Refresh();
        }
        #endregion
        private void Refresh()
        {
            int n = Balls;
            double size = BallSize;
            canvas.Children.Clear();
            double x = ActualWidth / 2;
            double y = ActualHeight / 2;
            double r = Math.Min(x, y) - size / 2;
            double doubleN = Convert.ToDouble(n);
            for (int i = 1; i <= n; i++)
            {
                double doubleI = Convert.ToDouble(i);
                double x1 = x + Math.Cos(doubleI / doubleN * 2d * Math.PI) * r - size / 2;
                double y1 = y + Math.Sin(doubleI / doubleN * 2d * Math.PI) * r - size / 2;
                var e = new Ellipse
                {
                    Fill = BallBrush,
                    Opacity = doubleI / doubleN,
                    Height = size,
                    Width = size
                };
                Canvas.SetLeft(e, x1);
                Canvas.SetTop(e, y1);
                canvas.Children.Add(e);
            };
        }

    }
}
