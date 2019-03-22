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
    public enum SetShape { Rectangle, Ellipse }
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
            string shape;
            if (((bool)rbRec.IsChecked) == true)
            {
                DrawingHelper.set = SetShape.Rectangle;
                shape = "Rectangle";
            }
            else if (((bool)rbEli.IsChecked) == true)
            {
                DrawingHelper.set = SetShape.Ellipse;
                shape = "Elipse";
            }

            int[] rectangleSpecs = new int[4];
            getCordinates(rectangleSpecs);
            DrawingHelper DH = new DrawingHelper(canvas, rectangleSpecs[0], rectangleSpecs[1], rectangleSpecs[2], rectangleSpecs[3], b, shape);
        }

        private void getCordinates(int[] rectangleSpecs)
        {
            try
            {
                string line = txtInput.Text;
                for (int i = 0; i < 3; i++)
                {

                    int.TryParse(line.Substring(0, line.IndexOf(',')), out rectangleSpecs[i]);
                    line = line.Substring(line.IndexOf(',') + 1);
                }
                int.TryParse(line, out rectangleSpecs[3]);
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    class DrawingHelper
    {
        public static SetShape set = new SetShape();
        private Canvas c = new Canvas();

        private Rectangle r = new Rectangle();
        private Ellipse e = new Ellipse();


        public DrawingHelper(Canvas C, double X, double Y, 
            double W, double H, Brush colour, string Shape)
        {
            if (set == SetShape.Rectangle)
            {
                r.Height = H;
                r.Width = W;

                Canvas.SetTop(r, Y);
                Canvas.SetLeft(r, X);

                r.Fill = colour;

                C.Children.Add(r);
            
            }
            else if(set == SetShape.Ellipse)
            {
                e.Height = H;
                e.Width = W;

                Canvas.SetTop(e, Y);
                Canvas.SetLeft(e, X);

                e.Fill = colour;

                C.Children.Add(e);

            }
        }
    }
}
