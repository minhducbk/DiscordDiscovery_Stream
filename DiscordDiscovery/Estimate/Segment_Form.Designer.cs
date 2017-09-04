namespace DiscordDiscovery.Estimate
{
    partial class Segment_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_segment = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.val_begin_segment = new System.Windows.Forms.HScrollBar();
            this.val_finish_segment = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_show = new System.Windows.Forms.Button();
            this.txt_start_segment = new System.Windows.Forms.Label();
            this.txt_finish_segment = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_segment)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_segment
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_segment.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.White;
            legend2.BorderColor = System.Drawing.Color.White;
            legend2.InterlacedRowsColor = System.Drawing.Color.White;
            legend2.Name = "Legend1";
            this.chart_segment.Legends.Add(legend2);
            this.chart_segment.Location = new System.Drawing.Point(12, 12);
            this.chart_segment.Name = "chart_segment";
            series3.BorderColor = System.Drawing.Color.Red;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.IsXValueIndexed = true;
            series3.LabelBackColor = System.Drawing.Color.Red;
            series3.LabelBorderColor = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.MarkerBorderColor = System.Drawing.Color.White;
            series3.MarkerColor = System.Drawing.Color.Red;
            series3.Name = "Approximation";
            series4.BorderColor = System.Drawing.Color.Lime;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Lime;
            series4.LabelBackColor = System.Drawing.Color.Lime;
            series4.Legend = "Legend1";
            series4.MarkerColor = System.Drawing.Color.Lime;
            series4.Name = "Real";
            this.chart_segment.Series.Add(series3);
            this.chart_segment.Series.Add(series4);
            this.chart_segment.Size = new System.Drawing.Size(980, 275);
            this.chart_segment.TabIndex = 0;
            this.chart_segment.Text = "chart_segment";
            // 
            // val_begin_segment
            // 
            this.val_begin_segment.Location = new System.Drawing.Point(154, 308);
            this.val_begin_segment.Name = "val_begin_segment";
            this.val_begin_segment.Size = new System.Drawing.Size(148, 17);
            this.val_begin_segment.TabIndex = 2;
            this.val_begin_segment.Scroll += new System.Windows.Forms.ScrollEventHandler(this.val_begin_segment_Scroll);
            // 
            // val_finish_segment
            // 
            this.val_finish_segment.Location = new System.Drawing.Point(402, 308);
            this.val_finish_segment.Name = "val_finish_segment";
            this.val_finish_segment.Size = new System.Drawing.Size(149, 17);
            this.val_finish_segment.TabIndex = 3;
            this.val_finish_segment.Scroll += new System.Windows.Forms.ScrollEventHandler(this.val_finish_segment_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "First Segment:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(399, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Last Segment:\r\n";
            // 
            // btn_show
            // 
            this.btn_show.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show.Location = new System.Drawing.Point(665, 321);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(94, 27);
            this.btn_show.TabIndex = 6;
            this.btn_show.Text = "Show Chart";
            this.btn_show.UseVisualStyleBackColor = true;
            this.btn_show.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_start_segment
            // 
            this.txt_start_segment.AutoSize = true;
            this.txt_start_segment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_start_segment.Location = new System.Drawing.Point(287, 342);
            this.txt_start_segment.Name = "txt_start_segment";
            this.txt_start_segment.Size = new System.Drawing.Size(15, 16);
            this.txt_start_segment.TabIndex = 7;
            this.txt_start_segment.Text = "0";
            // 
            // txt_finish_segment
            // 
            this.txt_finish_segment.AutoSize = true;
            this.txt_finish_segment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_finish_segment.Location = new System.Drawing.Point(508, 342);
            this.txt_finish_segment.Name = "txt_finish_segment";
            this.txt_finish_segment.Size = new System.Drawing.Size(43, 16);
            this.txt_finish_segment.TabIndex = 8;
            this.txt_finish_segment.Text = "15000";
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.Location = new System.Drawing.Point(847, 321);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(83, 27);
            this.btn_exit.TabIndex = 9;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // Segment_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 380);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.txt_finish_segment);
            this.Controls.Add(this.txt_start_segment);
            this.Controls.Add(this.btn_show);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.val_finish_segment);
            this.Controls.Add(this.val_begin_segment);
            this.Controls.Add(this.chart_segment);
            this.Name = "Segment_Form";
            this.Text = "Segment Form";
            ((System.ComponentModel.ISupportInitialize)(this.chart_segment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_segment;
        private System.Windows.Forms.HScrollBar val_begin_segment;
        private System.Windows.Forms.HScrollBar val_finish_segment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.Label txt_start_segment;
        private System.Windows.Forms.Label txt_finish_segment;
        private System.Windows.Forms.Button btn_exit;
    }
}