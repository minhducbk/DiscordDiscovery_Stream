namespace DiscordDiscovery
{
    partial class Statistical_Form
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart_position_discord = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_distance = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_time = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_position_discord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_distance)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_position_discord
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_position_discord.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_position_discord.Legends.Add(legend1);
            this.chart_position_discord.Location = new System.Drawing.Point(24, 12);
            this.chart_position_discord.Name = "chart_position_discord";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "position";
            this.chart_position_discord.Series.Add(series1);
            this.chart_position_discord.Size = new System.Drawing.Size(996, 221);
            this.chart_position_discord.TabIndex = 39;
            this.chart_position_discord.Text = "Chart";
            title1.DockedToChartArea = "ChartArea1";
            title1.DockingOffset = 85;
            title1.Name = "Chart";
            title1.Text = "Vị trí của chuỗi con bất đồng";
            this.chart_position_discord.Titles.Add(title1);
            // 
            // chart_distance
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_distance.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_distance.Legends.Add(legend2);
            this.chart_distance.Location = new System.Drawing.Point(24, 239);
            this.chart_distance.Name = "chart_distance";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "distance";
            this.chart_distance.Series.Add(series2);
            this.chart_distance.Size = new System.Drawing.Size(996, 244);
            this.chart_distance.TabIndex = 40;
            this.chart_distance.Text = "Chart";
            title2.DockedToChartArea = "ChartArea1";
            title2.DockingOffset = 89;
            title2.Name = "Chart";
            title2.Text = "Khoảng cách đến khớp không tầm thường của chuỗi con bất đồng";
            this.chart_distance.Titles.Add(title2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(397, 486);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 41;
            this.label1.Text = "Thời gian thực thi:";
            // 
            // txt_time
            // 
            this.txt_time.AutoSize = true;
            this.txt_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_time.Location = new System.Drawing.Point(580, 486);
            this.txt_time.Name = "txt_time";
            this.txt_time.Size = new System.Drawing.Size(25, 16);
            this.txt_time.TabIndex = 42;
            this.txt_time.Text = "0 s";
            // 
            // Statistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 511);
            this.Controls.Add(this.txt_time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart_distance);
            this.Controls.Add(this.chart_position_discord);
            this.Name = "Statistical";
            this.Text = "Statistical";
            ((System.ComponentModel.ISupportInitialize)(this.chart_position_discord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_distance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_position_discord;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_distance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt_time;
    }
}