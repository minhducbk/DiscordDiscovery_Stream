using DiscordDiscovery.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordDiscovery.Estimate
{
    public partial class ACF_Form : Form
    {
        List<double> norm_data;
        Main_Form parent_form;
        public ACF_Form(Main_Form parent_form, List<double> norm_data, int min_period, int max_period)
        {
            InitializeComponent();
            this.parent_form = parent_form;
            this.norm_data = norm_data;
            val_max_period.Minimum = min_period;
            val_min_period.Minimum = min_period;
            val_max_period.Maximum = this.norm_data.Count - 1 + 9;
            val_min_period.Maximum = this.norm_data.Count - 1 + 9;
            val_min_period.Value = min_period;
            txt_min_period.Text = val_min_period.Value.ToString();
            val_max_period.Value = max_period;
            txt_max_period.Text = val_max_period.Value.ToString();
            chart_ACF.ChartAreas[0].AxisX.IsStartedFromZero = false;
            this.Show();
            acf();
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            acf();
        }
        private async void acf()
        {
            if (val_min_period.Value > val_max_period.Value)
                MessageBox.Show("Please not that select min period greater than max period!");
            int period = await estimate_acf_task(val_min_period.Value, val_max_period.Value);
            txt_estimated_period.Text = period.ToString();
        }

        private Task<int> estimate_acf_task(int min_period, int max_period)
        {
            return Task.Run(() => estimate_period_ACF(norm_data, min_period, max_period));
        }

        private void update_ACFChart(List<Tuple<int, double>> acf_points, int max_index)
        {
            chart_ACF.Series["ACC"].Points.Clear();


            for (int i = 0; i < acf_points.Count; i++)
            {
                chart_ACF.Series["ACC"].Points.AddXY(acf_points[i].Item1, acf_points[i].Item2);

                if (i == max_index) //&& max_index > 0
                {
                    chart_ACF.Series["ACC"].Points[i].Color = Color.Red;
                }
            }

        }
        //Estimating period with Autocorrelation function
        private int estimate_period_ACF(List<double> norm_data, int min_period, int max_period)
        {
            int period = norm_data.Count;
            int data_length = norm_data.Count;
            int max_index = -1;
            double curr_acc = 0, max_acc = -Constants.INFINITE;

            List<Tuple<int, double>> acc_list = new List<Tuple<int, double>>();
            for (int k = min_period; k <= max_period; k++)
            {
                if (data_length - k > 0)
                {
                    curr_acc = autocorrelation_coefficient(norm_data.GetRange(0, data_length - k), norm_data.GetRange(k, data_length - k));
                    acc_list.Add(new Tuple<int, double>(k, curr_acc));

                    if (curr_acc > max_acc)
                    {
                        max_acc = curr_acc;
                        period = k;
                        max_index = k - min_period;
                    }
                }
            }

            //update chart:
            try
            {
                // call update_ACFChart to update GUI:
                this.Invoke((MethodInvoker)delegate { update_ACFChart(acc_list, max_index); });
            }
            catch
            { }

            parent_form.setPeriod(period);


            return period;
        }

        private double autocorrelation_coefficient(List<double> data1, List<double> data2)
        {
            if (data1.Count != data2.Count)
                throw new System.InvalidOperationException("Autocorrelation just has been calculated by two list of same length.");
            double mean1 = MathFuncs.CalcMean(data1);
            double mean2 = MathFuncs.CalcMean(data2);
            double std1 = MathFuncs.CalcStd(data1, mean1);
            double std2 = MathFuncs.CalcStd(data2, mean2);
            double result = 0;
            for (int i = 0; i < data1.Count; i++)
            {
                result += (data1[i] - mean1) * (data2[i] - mean2);
            }
            return result / (data1.Count * std1 * std2);
        }

        private void val_min_period_Scroll(object sender, ScrollEventArgs e)
        {
            txt_min_period.Text = val_min_period.Value.ToString();

        }

        private void val_max_period_Scroll(object sender, ScrollEventArgs e)
        {
            txt_max_period.Text = val_max_period.Value.ToString();

        }

        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
