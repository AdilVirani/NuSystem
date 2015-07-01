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

namespace WorkTopExample
{
    /// <summary>
    /// Interaction logic for Picture.xaml
    /// </summary

    public partial class Picture : UserControl
    {
        Canvas myCanvas; 

        public Picture(Canvas canavs)
        {
            InitializeComponent();
            myCanvas = canavs;
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            myCanvas.Children.Remove(this);
        }

        internal void setPicture(Uri uri)
        {
            var bitmap = new BitmapImage(uri);
            picture.Source = bitmap;
        }
       

    }
    
}
