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
    public partial class Segment_Form : Form
    {
        List<double> data;
        MinHeap<SegmentNode> segment_heap;
        public Segment_Form(List<double> data, MinHeap<SegmentNode> segment_heap)
        {
            InitializeComponent();
            this.data = data;
            this.segment_heap = segment_heap;
            draw_chart(0, segment_heap.get_all_element().Count - 1);
            val_begin_segment.Maximum = segment_heap.get_all_element().Count + 8;
            val_begin_segment.Minimum = 0;
            val_finish_segment.Maximum = segment_heap.get_all_element().Count + 8;
            val_finish_segment.Minimum = 0;
            val_finish_segment.Value = segment_heap.get_all_element().Count - 1;
            txt_finish_segment.Text = val_finish_segment.Value.ToString();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int begin_segment = val_begin_segment.Value;
            int finish_segment = val_finish_segment.Value;
            if (begin_segment <= finish_segment)
                draw_chart(begin_segment, finish_segment);
            else
                MessageBox.Show("Please not that select value of begin segment greater than value of finish segment!");
        }


        public void draw_chart(int begin_segment, int finish_segment)
        {
            chart_segment.ChartAreas[0].AxisY.Maximum = data.Max() * 1.3;
            chart_segment.ChartAreas[0].AxisY.Minimum = data.Min() / 1.3;
            chart_segment.Series["Approximation"].Points.Clear();
            chart_segment.Series["Real"].Points.Clear();
            List<SegmentNode> list_segment = segment_heap.get_all_element();
            for (int i = begin_segment; i <= finish_segment; i++)
            {
                draw_segment(data.GetRange(list_segment[i].getIndex(), list_segment[i].getLength()));
            }
        }

        public void draw_segment(List<double> segment)
        {
            double paraA = BottomUp.getParaA(segment);
            double paraB = BottomUp.getParaB(segment);
            foreach (double val in segment)
            {
                int curr_index;
                chart_segment.Series["Real"].Points.AddY(val);
                curr_index = chart_segment.Series["Real"].Points.Count - 1;
                chart_segment.Series["Real"].Points[curr_index].Color = Color.Lime;

                chart_segment.Series["Approximation"].Points.AddY((paraA * val + paraB));
                curr_index = chart_segment.Series["Approximation"].Points.Count - 1;
                chart_segment.Series["Approximation"].Points[curr_index].Color = Color.Red;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void val_begin_segment_Scroll(object sender, ScrollEventArgs e)
        {
            txt_start_segment.Text = val_begin_segment.Value.ToString();
        }

        private void val_finish_segment_Scroll(object sender, ScrollEventArgs e)
        {
            txt_finish_segment.Text = val_finish_segment.Value.ToString();
        }

    }
}
