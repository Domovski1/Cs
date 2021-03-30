using Chart.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;


namespace Chart
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ChartStructure> chartList = new List<ChartStructure>();
        public MainWindow()
        {
            InitializeComponent();
            FillData();

            MainChart.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Default"));
            MainChart.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("Seria"));

            MainChart.Series["Seria"].ChartArea = "Default";
            MainChart.Series["Seria"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 0; i < chartList.Count; i++)
            {
                MainChart.Series["Seria"].Points.AddXY(chartList[i].Date, chartList[i].Point);
            }
        }

        void FillData()
        {
            string Path = Environment.CurrentDirectory + @"\" + "data.txt";
            var file = File.ReadAllLines(Path);
            foreach (var item in file)
            {
                var separator = item.Split(',');
                chartList.Add(new ChartStructure
                {
                    Date = Convert.ToDateTime(separator[0]),
                    Point = Convert.ToInt32(separator[1])
                });
            }

            
        }
    }
}
