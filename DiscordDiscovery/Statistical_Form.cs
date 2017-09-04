using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordDiscovery
{
    public partial class Statistical_Form : Form
    {
        public Statistical_Form(List<double> result_loc, List<double> result_dist, double time)
        {
            InitializeComponent();
            updateChartLoc(result_loc);
            updateChartDist(result_dist);
            this.txt_time.Text = (time / 1000).ToString() + " s";
            this.Show();
        }

        private void updateChartLoc(List<double> result_loc)
        {
            chart_position_discord.ChartAreas[0].AxisY.Maximum = result_loc.Max() * 1.3;
            chart_position_discord.ChartAreas[0].AxisY.Minimum = result_loc.Min() / 1.3;
            chart_position_discord.Series["position"].Points.Clear();
            for (int i = 0; i < result_loc.Count; i++)
            {
                chart_position_discord.Series["position"].Points.AddY(result_loc[i]);
            }
        }

        private void updateChartDist(List<double> result_dist)
        {
            chart_distance.ChartAreas[0].AxisY.Maximum = result_dist.Max() * 1.3;
            chart_distance.ChartAreas[0].AxisY.Minimum = result_dist.Min() / 1.3;
            chart_distance.Series["distance"].Points.Clear();
            for (int i = 0; i < result_dist.Count; i++)
            {
                chart_distance.Series["distance"].Points.AddY(result_dist[i]);
            }
        }
    }
}
