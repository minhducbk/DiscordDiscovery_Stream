using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DiscordDiscovery
{
    public partial class Statistical_Form : Form
    {
        public Statistical_Form(string algorithm, string data_name, List<double> result_loc, List<double> result_dist, double time)
        {
            InitializeComponent();
            this.Text = "Statistical_" + algorithm + "_" + data_name;
            if (algorithm == "Sanchez_Online")
            {
                chart_position_discord.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                chart_distance.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            }
            else
            {
                chart_position_discord.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart_distance.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }
            updateChartLoc(result_loc);
            updateChartDist(result_dist);
            DesktopLocation = new Point(100, 100);
            this.txt_time.Text = (time / 1000).ToString() + " s";
            this.Show();
        }

        private void updateChartLoc(List<double> result_loc)
        {
            chart_position_discord.Series["position"].Points.Clear();
            if (result_loc.Where(x => x >= 0).Count() == 0)
            {
                chart_position_discord.ChartAreas[0].AxisY.Maximum = 2;
                chart_position_discord.ChartAreas[0].AxisY.Minimum = 0;
                chart_position_discord.Series["position"].Points.Add(-1);

            }
            else
            {
                chart_position_discord.ChartAreas[0].AxisY.Maximum = result_loc.Max() * 1.5;
                chart_position_discord.ChartAreas[0].AxisY.Minimum = result_loc.Min() / 1.6;
            }

            for (int i = 0; i < result_loc.Count; i++)
            {
                if (i > 0)
                    chart_position_discord.Series["position"].Points.AddXY(i, result_loc[i]);
            }
        }

        private void updateChartDist(List<double> result_dist)
        {
            chart_distance.Series["distance"].Points.Clear();
            if (result_dist.Where(x => x >= 0).Count() == 0)
            {
                chart_distance.ChartAreas[0].AxisY.Maximum = 2;
                chart_distance.ChartAreas[0].AxisY.Minimum = 0;
                chart_distance.Series["distance"].Points.Add(-1);
            }
            else
            {
                chart_distance.ChartAreas[0].AxisY.Maximum = result_dist.Max() * 1.5;
                chart_distance.ChartAreas[0].AxisY.Minimum = result_dist.Min() / 1.6;
            }
            for (int i = 0; i < result_dist.Count; i++)
            {
                if (i > 0)
                    chart_distance.Series["distance"].Points.AddXY(i, result_dist[i]);
            }
        }
    }
}
