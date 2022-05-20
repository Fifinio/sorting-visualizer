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

namespace sorting_visualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numOfElements = 0;
        public List<byte> list = new();
        SortEngine algorithm = null;
        LinearGradientBrush gradientBrush;
        public void ReDraw()
        {
            myCanvas.Children.Clear();
            foreach (int i in list)
            {
                int numOfElements = (int)slValue.Value;
                double elementMargin = 2.5;
                double elementWidth = (myCanvas.Width - elementMargin * numOfElements) / numOfElements;

                Rectangle rect = new Rectangle();
                rect.Width = elementWidth;
                rect.Height = i;
                // fill rect with gradient
                rect.Fill = gradientBrush;
                rect.Margin = new Thickness(elementMargin, 0, 0, 0);
                myCanvas.Children.Add(rect);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new Point(0, 0);
            gradientBrush.EndPoint = new Point(0, 1);
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Violet, 0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.IndianRed, 1));
            ReDraw();
        }

        private SortEngine getAlgorithm(string name)
        {
            // if algorithm is set return the instance else create new instance
            if (algorithm != null)
            {
                return algorithm;
            }
            else
            {
                switch (name)
                {
                    case "Bubble Sort":
                        algorithm = new BubbleSort(list);
                        break;
                    case "Insertion Sort":
                        algorithm = new InsertionSort(list);
                        break;
                    default:
                        return null;
                }
            }
            return algorithm;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            numOfElements = (int)slValue.Value;
            list = new List<byte>();
            for (int i = 0; i < numOfElements; i++)
            {
                list.Add((byte)new Random().Next(0, 255));
            }
            if (numOfElements > 5)
            {
                ReDraw();
            }
        }

        private async void SortButton_Click(object sender, RoutedEventArgs e)
        {
            string algorithmString = (string)algorithmComboBox.Text;
            algorithm = getAlgorithm(algorithmString);

            if (algorithm == null)
            {
                MessageBox.Show("Please select an algorithm");
                return;
            }
            // for each element that is in Controls.Children make it disabled
            foreach (UIElement element in Controls.Children)
            {
                element.IsEnabled = false;
            }

            while (algorithm.IsSorted() == false)
            {
                algorithm.NextStep();
                await Task.Delay(1);
                ReDraw();
            }

            algorithm = null;
            foreach (UIElement element in Controls.Children)
            {
                element.IsEnabled = true;
            }
        }

    }
}

