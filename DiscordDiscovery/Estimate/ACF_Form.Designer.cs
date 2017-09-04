namespace DiscordDiscovery.Estimate
{
    partial class ACF_Form
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
            this.chart_ACF = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txt_max_period = new System.Windows.Forms.Label();
            this.txt_min_period = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.val_max_period = new System.Windows.Forms.HScrollBar();
            this.val_min_period = new System.Windows.Forms.HScrollBar();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_show = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_estimated_period = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_ACF)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_ACF
            // 
            chartArea1.AxisX.Title = "Period";
            chartArea1.AxisY.Title = "ACC";
            chartArea1.Name = "ChartArea1";
            this.chart_ACF.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_ACF.Legends.Add(legend1);
            this.chart_ACF.Location = new System.Drawing.Point(23, 12);
            this.chart_ACF.Name = "chart_ACF";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "ACC";
            this.chart_ACF.Series.Add(series1);
            this.chart_ACF.Size = new System.Drawing.Size(893, 289);
            this.chart_ACF.TabIndex = 0;
            this.chart_ACF.Text = "chart1";
            // 
            // txt_max_period
            // 
            this.txt_max_period.AutoSize = true;
            this.txt_max_period.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_max_period.Location = new System.Drawing.Point(454, 352);
            this.txt_max_period.Name = "txt_max_period";
            this.txt_max_period.Size = new System.Drawing.Size(43, 16);
            this.txt_max_period.TabIndex = 14;
            this.txt_max_period.Text = "15000";
            // 
            // txt_min_period
            // 
            this.txt_min_period.AutoSize = true;
            this.txt_min_period.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_min_period.Location = new System.Drawing.Point(233, 352);
            this.txt_min_period.Name = "txt_min_period";
            this.txt_min_period.Size = new System.Drawing.Size(15, 16);
            this.txt_min_period.TabIndex = 13;
            this.txt_min_period.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(355, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Max Period:\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Min Period:";
            // 
            // val_max_period
            // 
            this.val_max_period.Location = new System.Drawing.Point(348, 320);
            this.val_max_period.Name = "val_max_period";
            this.val_max_period.Size = new System.Drawing.Size(149, 17);
            this.val_max_period.TabIndex = 10;
            this.val_max_period.Scroll += new System.Windows.Forms.ScrollEventHandler(this.val_max_period_Scroll);
            // 
            // val_min_period
            // 
            this.val_min_period.Location = new System.Drawing.Point(100, 320);
            this.val_min_period.Name = "val_min_period";
            this.val_min_period.Size = new System.Drawing.Size(148, 17);
            this.val_min_period.TabIndex = 9;
            this.val_min_period.Scroll += new System.Windows.Forms.ScrollEventHandler(this.val_min_period_Scroll);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.Location = new System.Drawing.Point(791, 347);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(94, 27);
            this.btn_exit.TabIndex = 16;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click_1);
            // 
            // btn_show
            // 
            this.btn_show.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show.Location = new System.Drawing.Point(791, 314);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(94, 27);
            this.btn_show.TabIndex = 15;
            this.btn_show.Text = "Estimate";
            this.btn_show.UseVisualStyleBackColor = true;
            this.btn_show.Click += new System.EventHandler(this.btn_show_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(548, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Estimated Period:";
            // 
            // txt_estimated_period
            // 
            this.txt_estimated_period.AutoSize = true;
            this.txt_estimated_period.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_estimated_period.Location = new System.Drawing.Point(668, 337);
            this.txt_estimated_period.Name = "txt_estimated_period";
            this.txt_estimated_period.Size = new System.Drawing.Size(15, 16);
            this.txt_estimated_period.TabIndex = 18;
            this.txt_estimated_period.Text = "1";
            // 
            // ACF_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 386);
            this.Controls.Add(this.txt_estimated_period);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_show);
            this.Controls.Add(this.txt_max_period);
            this.Controls.Add(this.txt_min_period);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.val_max_period);
            this.Controls.Add(this.val_min_period);
            this.Controls.Add(this.chart_ACF);
            this.Name = "ACF_Form";
            this.Text = "ACF_Form";
            ((System.ComponentModel.ISupportInitialize)(this.chart_ACF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_ACF;
        private System.Windows.Forms.Label txt_max_period;
        private System.Windows.Forms.Label txt_min_period;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar val_max_period;
        private System.Windows.Forms.HScrollBar val_min_period;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txt_estimated_period;
    }
}