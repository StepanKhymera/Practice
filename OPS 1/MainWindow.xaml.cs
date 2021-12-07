using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Practic.Sorts;
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
using System.Diagnostics;
using System.IO;

namespace Practic
{

    public partial class MainWindow : Window
    {
        List<Sort> algs = new List<Sort>();
        List<double> labels = new List<double>()
        {
             0,
             0.25,
             0.5,
             0.75,
             1,
             2,
             3,
             5,
             10,
             15,
             20,
             30,
             50,
             100,
             500,
             1000,
             3000,
             5000,
             10000,
             20000,
             40000,
             60000,
             120000,
             180000
        };
        List<int> sizes = new List<int>() { 100, 500, 1000, 5000, 10000, 20000, 30000, 50000 };
        public MainWindow()
        {
            InitializeComponent();
           
            algs.Add(new Shell());
            algs.Add(new Select());
            algs.Add(new Quick());
            algs.Add(new Merge());
            algs.Add(new Count());
            algs.Add(new Heap());
            algs.Add(new Bucket());

            List<string> string_labels = new List<string>();

            for(int i = 0; i < labels.Count; ++i)
            {
                if(labels[i] >= 1000)
                {
                    string_labels.Add((labels[i]/1000).ToString() + " s");

                } else
                {
                    string_labels.Add(labels[i].ToString() + " ms");
                }
            }
            Chart.AxisY.Last().Labels = string_labels;
            Chart.AxisX.Last().Labels = new List<string>();

            Chart.Series = new SeriesCollection
            {
                
                new LineSeries
                {
                    Title = "Shell",
                    Fill = Brushes.Transparent,
                     
                    LineSmoothness = 0,
                    Stroke = Brushes.Green
                },
                new LineSeries
                {
                    LineSmoothness = 0,
                    Title = "Select",
                    Fill = Brushes.Transparent,
                    Stroke = Brushes.Blue
                    

                },
                new LineSeries
                {
                    LineSmoothness = 0,
                    Title = "Quick",
                    Fill = Brushes.Transparent,
                     
                    Stroke = Brushes.Black
                },
                new LineSeries
                {
                    LineSmoothness = 0,
                    Title = "Merge",
                    Fill = Brushes.Transparent,
                     
                    Stroke = Brushes.Yellow
                },
                new LineSeries
                {
                    LineSmoothness = 0,
                    Title = "Count",
                    Fill = Brushes.Transparent,
                     
                    Stroke = Brushes.Red
                },
                new LineSeries
                {
                    LineSmoothness = 0,
                    Title = "Heap",
                    Fill = Brushes.Transparent,
                     
                    Stroke = Brushes.Coral
                },
                new LineSeries
                {
                    LineSmoothness = 0,
                    Title = "Bucket",
                    Fill = Brushes.Transparent,
                     
                    Stroke = Brushes.Cyan
                }



            };

            Chart.Series[0].Values = new ChartValues<ObservablePoint>();
            Chart.Series[1].Values = new ChartValues<ObservablePoint>();
            Chart.Series[2].Values = new ChartValues<ObservablePoint>();
            Chart.Series[3].Values = new ChartValues<ObservablePoint>();
            Chart.Series[4].Values = new ChartValues<ObservablePoint>();
            Chart.Series[5].Values = new ChartValues<ObservablePoint>();
            Chart.Series[6].Values = new ChartValues<ObservablePoint>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Chart.Series[0].Values.Clear();
            Chart.Series[1].Values.Clear();
            Chart.Series[2].Values.Clear();
            Chart.Series[3].Values.Clear();
            Chart.Series[4].Values.Clear();
            Chart.Series[5].Values.Clear();
            Chart.Series[6].Values.Clear();
            Chart.AxisX.Last().Labels.Clear();
            Random r = new Random((int)System.DateTime.Now.Ticks);

            int bound;
            
            int size;
            List<List<int>> data = new List<List<int>>();
            for(int i = 0; i < sizes.Count; ++i)
            {
                size = sizes[i];
                List<int> l = new List<int>(size);
                switch (Data_Type.SelectedIndex)
                {
                    default:
                    case 0:
                        {
                            bound = size/2;
                            break;
                        }
                    case 2:
                        {
                            bound = size* 100;
                            break;
                        }
                    case 1:
                        {
                            bound = size/ 10;
                            break;
                        }
                }
                for (int j = 0; j < size; ++j)
                {
                    l.Add(r.Next(-bound, bound));
                }
                data.Add(l);
                Chart.AxisX.Last().Labels.Add(size.ToString());
            }

            for (int j = 0; j < 7; ++j)
            {
                algs[j].sort(new List<int>(data[0]));
            }
            double time;
            List<string> time_results = new List<string>();
            string row;
            for (int j = 0; j < 7; ++j)
            {
                row = "";
                for (int d = 0; d < data.Count; ++d ) {                   
                    time = algs[j].sort(new List<int>(data[d]));
                    row += ($"{time}\t");
                    Chart.Series[j].Values.Add(new ObservablePoint
                    {
                        X = d,    
                        Y = Scale(time)                         
                    });
                }
                time_results.Add(row);
            }
            File.WriteAllLines($"results_{Data_Type.SelectedIndex}_{(int)System.DateTime.Now.Ticks}.txt", time_results.ToArray());
        }

        private double Scale(double time)
        {
            int upper_point = labels.FindIndex(l => l > time);
            if (upper_point <= 1) return time;

            return (time - labels[upper_point - 1]) / (labels[upper_point] - labels[upper_point - 1]) + upper_point-1;
        }
        

    }
}


