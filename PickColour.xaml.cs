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
using System.Windows.Shapes;

namespace _312551Drawing
{
    /// <summary>
    /// Interaction logic for PickColour.xaml
    /// </summary>
    public partial class PickColour : Window
    {
        public PickColour()
        {
            InitializeComponent();
            for (int r = 0; r < 256; r += 33)
            {
                Button b = new Button();
                b.Background = new SolidColorBrush(Color.FromRgb((byte)r, 0, 0));
                b.Content = " ";
                b.Click += btnPickColor_Click;
                stackPanel.Children.Add(b);
            }
        }

        private void btnPickColor_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.b = ((Button)sender).Background;
            DialogResult = true;
        }
    }
}

