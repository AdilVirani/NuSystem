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

namespace WpfControlLibrary2
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        Canvas myCanvas;

        public UserControl2(Canvas canvas)
        {
            InitializeComponent();
            myCanvas = canvas;
            box.IsEnabled = true;
            
            box.Opacity = 1;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            myCanvas.Children.Remove(this);
        }
        private void Memo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.disableInkCanvas();
        }

        private void disableInkCanvas()
        {
            box.IsEnabled = true;
        }

        private void edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Boolean b = box.IsEnabled;
            box.IsEnabled = !b;
            

        }
        private void box_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("MouseDown");
        }


    }
}
