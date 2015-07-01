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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using RadialMenuDemo.Utils;
using System.Windows.Controls.Primitives;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using CustomToolTip;
using RadialMenu;
using RadialMenuDemo;
using System.Drawing;
using WpfControlLibrary2;
using System.Collections;


namespace WorkTopExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        const double ScaleRate = 1.1;
        private bool _isOpen = false;
        Boolean validStart = false;
        Boolean validEnd = false;
        Line lastLine;

        //For Scroll
        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
 
            if (e.Delta > 0)
            {
                st.ScaleX *= ScaleRate;
                st.ScaleY *= ScaleRate;
            }
            else
            {
                st.ScaleX /= ScaleRate;
                st.ScaleY /= ScaleRate;
            }
        } 

        //For Radial Menu Open
        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            set
            {
                _isOpen = value;
                RaisePropertyChanged();
            }
        }

        //For Radial Menu Close
        public ICommand CloseRadialMenu
        {
            get
            {
                return new RelayCommand(() => IsOpen = false);
            }
        }

        //For Radial Menu Open
        public ICommand OpenRadialMenu
        {
            get
            {
                return new RelayCommand(() => IsOpen = true);
            }
        }

        //Finished Adding Command      
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        //Button 1 Adds Note
        public ICommand Test1
        {

            get
            {
                return new RelayCommand(() => AddToolTip());
            }
        }

        //Button 2 Adds InkCanvas
        public ICommand Test2
        {
            get
            {
                return new RelayCommand(() => AddInk());
            }
        }

        //Button 3 Adds Calculator
        public ICommand Test3
        {
            get
            {
                return new RelayCommand(() => AddCalc());
            }
        }

        //Button 4 Removes all Nodes NOT DONE YET
        public ICommand Test4
        {
            get
            {
                return new RelayCommand(() => System.Diagnostics.Debug.WriteLine("4"));
            }
        }

        //Button 5 NOT DONE YET
        public ICommand Test5
        {
            get
            {
                return new RelayCommand(() => System.Diagnostics.Debug.WriteLine("5"));
            }
        }

        //Button 6 Adds a Picture from save file
        public ICommand Test6
        {
            get
            {
                return new RelayCommand(() => System.Diagnostics.Debug.WriteLine("6"));
            }
        }

        //Command to open Radial Menu
        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenRadialMenu.Execute(null);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Function that adds a note and within the funciton contains methods for connecting lines  (Method called in ICommand 1)
        void AddToolTip()
        {
            UserControl1 y = new UserControl1(MyCanvas);
            MyCanvas.Children.Add(y);
            Matrix m = new Matrix();
            m.Translate(300, 300);
            y.RenderTransform = new MatrixTransform(m);
            y.Drop += y_Drop;
            y.MouseDown += y_MouseDown;
            y.MouseEnter += y_MouseEnter;
            y.MouseLeave += y_MouseLeave;
         //   y.setText((String)e.Data.GetData(DataFormats.Text));
        }
        void y_MouseLeave(object sender, MouseEventArgs e)
        {
            validEnd = false;
        }
        void y_MouseEnter(object sender, MouseEventArgs e)
        {
            validEnd = true;
        }
        void y_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Line line = new Line();
            line.Stroke = Brushes.AntiqueWhite;
            line.StrokeThickness = 10;
            Point point= e.GetPosition(this);
            line.X1 = point.X;
            line.Y1 = point.Y;
            line.X2 = point.X;
            line.Y2 = point.Y;
            validStart = true;
            MyCanvas.Children.Add(line);
            lastLine = line;
            Console.WriteLine("line made");
        }
        void y_Drop(object sender, DragEventArgs e)
        {
            (sender as UserControl1).setText((String)e.Data.GetData(DataFormats.Text));
        }

        //Function that adds a ink note and within the function contains methods for connecting lines as well (Method called in ICommand 2)
        void AddInk()
        {
            UserControl2 x = new UserControl2(MyCanvas);
            MyCanvas.Children.Add(x);
            Matrix n = new Matrix();
            n.Translate(300, 300);
            x.RenderTransform = new MatrixTransform(n);
            x.MouseDown += x_MouseDown;
            x.MouseEnter += x_MouseEnter;
            x.MouseLeave += x_MouseLeave;;
            Canvas.SetZIndex(x, 1);

        }
        void x_MouseLeave(object sender, MouseEventArgs e)
        {
            validEnd = false;
        }
        void x_MouseEnter(object sender, MouseEventArgs e)
        {
            validEnd = true;
        }
        void x_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Line line = new Line();
            line.Stroke = Brushes.AntiqueWhite;
            line.StrokeThickness = 10;
            Point point = e.GetPosition(this);
            line.X1 = point.X;
            line.Y1 = point.Y;
            line.X2 = point.X;
            line.Y2 = point.Y;
            validStart = true;
            MyCanvas.Children.Add(line);
            lastLine = line;

        }
        //Function that adds a calculator *****Stil working on***** (Method called in ICommand 3)
        void AddCalc()
        {
            Calculator z = new Calculator(MyCanvas);
            MyCanvas.Children.Add(z);
            Matrix n = new Matrix();
            n.Translate(300, 300);
        }

        //Manipulation
        private void Window_ManipulationStarting(object sender, System.Windows.Input.ManipulationStartingEventArgs e)
        {
            e.ManipulationContainer = this;
            e.Handled = true;
        }

        //This is the method used in Button number 6 to allow users to pick pictures from there computer within allow lines to form and manipulation
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter =
                "Image Files (*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                

            if ((bool)dialog.ShowDialog())
            {
                Picture pic = new Picture(MyCanvas);
                pic.setPicture(new Uri(dialog.FileName));
                Canvas.SetLeft(pic, 0);
                Canvas.SetTop(pic, 0);
                MyCanvas.Children.Add(pic);
                pic.MouseDown += pic_MouseDown;
                pic.MouseEnter += pic_MouseEnter;
                pic.MouseLeave += pic_MouseLeave;
                Canvas.SetZIndex(pic, 1);
            }
        }
        void pic_MouseLeave(object sender, MouseEventArgs e)
        {
            validEnd = false;
        }
        void pic_MouseEnter(object sender, MouseEventArgs e)
        {
            validEnd = true;
        }
        void pic_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Line line = new Line();
            line.Stroke = Brushes.AntiqueWhite;
            line.StrokeThickness = 10;
            Point point = e.GetPosition(this);
            line.X1 = point.X;
            line.Y1 = point.Y;
            line.X2 = point.X;
            line.Y2 = point.Y;
            validStart = true;
            MyCanvas.Children.Add(line);
            lastLine = line;

        }
        
        //Rectangle Movement (everyone has this) allows nodes to move, essentially 
        void Window_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {

            // Get the Rectangle and its RenderTransform matrix.
            UIElement rectToMove = e.OriginalSource as UIElement;
            Matrix rectsMatrix = ((MatrixTransform)rectToMove.RenderTransform).Matrix;

            // Rotate the Rectangle.
            rectsMatrix.RotateAt(e.DeltaManipulation.Rotation,
                                 e.ManipulationOrigin.X,
                                 e.ManipulationOrigin.Y);

            // Resize the Rectangle.  Keep it square 
            // so use only the X value of Scale.
            rectsMatrix.ScaleAt(e.DeltaManipulation.Scale.X,
                                e.DeltaManipulation.Scale.X,
                                e.ManipulationOrigin.X,
                                e.ManipulationOrigin.Y);

            // Move the Rectangle.
            rectsMatrix.Translate(e.DeltaManipulation.Translation.X,
                                  e.DeltaManipulation.Translation.Y);

            // Apply the changes to the Rectangle.
            rectToMove.RenderTransform = new MatrixTransform(rectsMatrix);

            Rect containingRect =
                new Rect(((FrameworkElement)e.ManipulationContainer).RenderSize);

            Rect shapeBounds =
                rectToMove.RenderTransform.TransformBounds(
                    new Rect(rectToMove.RenderSize));

            // Check if the rectangle is completely in the window.
            // If it is not and intertia is occuring, stop the manipulation.
            if (e.IsInertial && !containingRect.Contains(shapeBounds))
            {
                e.Complete();
            }


            e.Handled = true;
        }
        void Window_InertiaStarting(object sender, ManipulationInertiaStartingEventArgs e)
        {

            // Decrease the velocity of the Rectangle's movement by 
            // 10 inches per second every second.
            // (10 inches * 96 pixels per inch / 1000ms^2)
            e.TranslationBehavior.DesiredDeceleration = 10.0 * 96.0 / (1000.0 * 1000.0);

            // Decrease the velocity of the Rectangle's resizing by 
            // 0.1 inches per second every second.
            // (0.1 inches * 96 pixels per inch / (1000ms^2)
            e.ExpansionBehavior.DesiredDeceleration = 0.1 * 96 / (1000.0 * 1000.0);

            // Decrease the velocity of the Rectangle's rotation rate by 
            // 2 rotations per second every second.
            // (2 * 360 degrees / (1000ms^2)
            e.RotationBehavior.DesiredDeceleration = 720 / (1000.0 * 1000.0);

            e.Handled = true;
        }
        
        //For the lines, incase the mouse is not on top of a node, then the line will delete.
        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(this);

            if (validStart)
            {
                lastLine.X2 = point.X;
                lastLine.Y2 = point.Y;
            }
        }
        private void MyCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (validStart && validEnd)
            {
                validStart = false;
            }
            else
            {
                MyCanvas.Children.Remove(lastLine);
            }
        }
    }
}
