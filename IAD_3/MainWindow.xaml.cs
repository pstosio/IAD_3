using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IAD_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Experiments.Experiment1 exp1 = new Experiments.Experiment1(4);

            this.LoadScatterChartData(exp1.points, exp1.clusters);
        }

        private void LoadScatterChartData(List<Point> points, List<Point> clusters)
        {
            ObservableCollection<KeyValuePair<double, double>> points_oc1 = new ObservableCollection<KeyValuePair<double, double>>();
            ObservableCollection<KeyValuePair<double, double>> points_oc2 = new ObservableCollection<KeyValuePair<double, double>>();
            ObservableCollection<KeyValuePair<double, double>> points_oc3 = new ObservableCollection<KeyValuePair<double, double>>();
            ObservableCollection<KeyValuePair<double, double>> points_oc4 = new ObservableCollection<KeyValuePair<double, double>>();
            ObservableCollection<KeyValuePair<double, double>> clusters_oc = new ObservableCollection<KeyValuePair<double, double>>();

            foreach (Point point in points)
            {
               switch(point.Group)
                {
                    case 1:
                        points_oc1.Add(new KeyValuePair<double, double>(point.X, point.Y));
                        break;

                    case 2:
                        points_oc2.Add(new KeyValuePair<double, double>(point.X, point.Y));
                        break;

                    case 3:
                        points_oc3.Add(new KeyValuePair<double, double>(point.X, point.Y));
                        break;

                    case 4:
                        points_oc4.Add(new KeyValuePair<double, double>(point.X, point.Y));
                        break;
                }
                
            }

            foreach(Point point in clusters)
            {
                clusters_oc.Add(new KeyValuePair<double, double>(point.X, point.Y));
            }


            ScatterSeries sc = new ScatterSeries();
            

            ((ScatterSeries)Voronoi.Series[0]).ItemsSource = points_oc1;
            ((ScatterSeries)Voronoi.Series[1]).ItemsSource = points_oc2;
            ((ScatterSeries)Voronoi.Series[2]).ItemsSource = points_oc3;
            ((ScatterSeries)Voronoi.Series[3]).ItemsSource = points_oc4;
            ((ScatterSeries)Voronoi.Series[4]).ItemsSource = clusters_oc;


        }
    }
}
