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

namespace CustomToolTip
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        Canvas myCanvas;


        public UserControl1(Canvas canvas)
        {
            InitializeComponent();
            myCanvas = canvas;
            box.IsEnabled = false;
            Canvas.SetZIndex(this, 1);
            box.Opacity = 1;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            myCanvas.Children.Remove(this);
        }
        internal Image getXbutton()
        {
            return xbttn;
        }
        private void Memo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.disableTextBox();          
        }
        private void disableTextBox()
        {
            box.IsEnabled = false;
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
        private void Mouse_MouseLeave(object sender, MouseEventArgs e)
        {
            disableTextBox();
        }
        void Window_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            e.ManipulationContainer = this;
            e.Handled = true;
            Console.WriteLine("starting...");
        }

        public void setText(string p)
        {box.Text = p;
        }
    }
}