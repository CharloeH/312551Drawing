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

namespace _312551Drawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Brush b;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetColour_Click(object sender, RoutedEventArgs e)
        {
            PickColour p = new PickColour();
            p.ShowDialog();
        }

        private void BtnDraw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter("txtSpecs.txt");
                sw.WriteLine(txtInput.Text);
                sw.Flush();
                sw.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DrawingHelper DH = new DrawingHelper(canvas, 10, 10, 100, 100, b, "Rectangle");
        }
    }
    class DrawingHelper
    {
        private Canvas c = new Canvas();
        private Rectangle r = new Rectangle();

        public DrawingHelper(Canvas C, double X, double Y, 
            double W, double H, Brush colour, string Shape)
        {
            r.Height = H;
            r.Width = W;

            Canvas.SetTop(r, Y);
            Canvas.SetLeft(r, X);

            r.Fill = colour;

            C.Children.Add(r);
        }
    }
}
