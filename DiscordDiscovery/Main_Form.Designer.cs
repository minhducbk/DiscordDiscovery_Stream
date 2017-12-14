namespace DiscordDiscovery
{
    partial class Main_Form
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
            this.btn_getW = new System.Windows.Forms.Button();
            this.txt_threshold = new System.Windows.Forms.TextBox();
            this.label_threshold = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_period_max = new System.Windows.Forms.TextBox();
            this.btn_Period = new System.Windows.Forms.Button();
            this.btn_stopStream = new System.Windows.Forms.Button();
            this.btn_STREAM = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combox_algorithm = new System.Windows.Forms.ComboBox();
            this.label_Algorithms = new System.Windows.Forms.Label();
            this.txt_buffer_length = new System.Windows.Forms.Label();
            this.txt_threshold_sim = new System.Windows.Forms.TextBox();
            this.txt_bufferLength = new System.Windows.Forms.TextBox();
            this.txt_threshold_std = new System.Windows.Forms.TextBox();
            this.txt_threshold_mean = new System.Windows.Forms.TextBox();
            this.txt_period = new System.Windows.Forms.TextBox();
            this.txt_WLength = new System.Windows.Forms.TextBox();
            this.txt_NLength = new System.Windows.Forms.TextBox();
            this.txt_stream_data = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.combox_filename = new System.Windows.Forms.ComboBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.txtMinEntry = new System.Windows.Forms.TextBox();
            this.txtMaxEntry = new System.Windows.Forms.TextBox();
            this.txtR = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_statistic = new System.Windows.Forms.Button();
            this.txt_data_to_calc_W = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chart_timeSeries = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Estimate_Period = new System.Windows.Forms.GroupBox();
            this.groupBox_status = new System.Windows.Forms.GroupBox();
            this.txt_speed = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_index_stream = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_timeSeries)).BeginInit();
            this.Estimate_Period.SuspendLayout();
            this.groupBox_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_getW
            // 
            this.btn_getW.Location = new System.Drawing.Point(178, 72);
            this.btn_getW.Name = "btn_getW";
            this.btn_getW.Size = new System.Drawing.Size(78, 23);
            this.btn_getW.TabIndex = 10;
            this.btn_getW.Text = "Get W";
            this.btn_getW.UseVisualStyleBackColor = true;
            this.btn_getW.Click += new System.EventHandler(this.btn_GetW_Click);
            // 
            // txt_threshold
            // 
            this.txt_threshold.Location = new System.Drawing.Point(92, 74);
            this.txt_threshold.Name = "txt_threshold";
            this.txt_threshold.Size = new System.Drawing.Size(80, 20);
            this.txt_threshold.TabIndex = 14;
            this.txt_threshold.Text = "0.005";
            // 
            // label_threshold
            // 
            this.label_threshold.AutoSize = true;
            this.label_threshold.Location = new System.Drawing.Point(9, 77);
            this.label_threshold.Name = "label_threshold";
            this.label_threshold.Size = new System.Drawing.Size(85, 13);
            this.label_threshold.TabIndex = 13;
            this.label_threshold.Text = "Threshold_Error:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Period_Max:";
            // 
            // txt_period_max
            // 
            this.txt_period_max.Location = new System.Drawing.Point(92, 44);
            this.txt_period_max.Name = "txt_period_max";
            this.txt_period_max.Size = new System.Drawing.Size(80, 20);
            this.txt_period_max.TabIndex = 34;
            // 
            // btn_Period
            // 
            this.btn_Period.Location = new System.Drawing.Point(178, 42);
            this.btn_Period.Name = "btn_Period";
            this.btn_Period.Size = new System.Drawing.Size(78, 23);
            this.btn_Period.TabIndex = 31;
            this.btn_Period.Text = "Get Period";
            this.btn_Period.UseVisualStyleBackColor = true;
            this.btn_Period.Click += new System.EventHandler(this.btnPeriod_Click);
            // 
            // btn_stopStream
            // 
            this.btn_stopStream.Location = new System.Drawing.Point(132, 408);
            this.btn_stopStream.Name = "btn_stopStream";
            this.btn_stopStream.Size = new System.Drawing.Size(59, 28);
            this.btn_stopStream.TabIndex = 23;
            this.btn_stopStream.Text = "Pause";
            this.btn_stopStream.UseVisualStyleBackColor = true;
            this.btn_stopStream.Click += new System.EventHandler(this.btn_stopStream_Click);
            // 
            // btn_STREAM
            // 
            this.btn_STREAM.Location = new System.Drawing.Point(61, 408);
            this.btn_STREAM.Name = "btn_STREAM";
            this.btn_STREAM.Size = new System.Drawing.Size(60, 28);
            this.btn_STREAM.TabIndex = 15;
            this.btn_STREAM.Text = "STREAM";
            this.btn_STREAM.UseVisualStyleBackColor = true;
            this.btn_STREAM.Click += new System.EventHandler(this.btn_Stream_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(11, 408);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(44, 28);
            this.btn_clear.TabIndex = 5;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combox_algorithm);
            this.groupBox1.Controls.Add(this.label_Algorithms);
            this.groupBox1.Controls.Add(this.txt_buffer_length);
            this.groupBox1.Controls.Add(this.txt_threshold_sim);
            this.groupBox1.Controls.Add(this.txt_bufferLength);
            this.groupBox1.Controls.Add(this.txt_threshold_std);
            this.groupBox1.Controls.Add(this.txt_threshold_mean);
            this.groupBox1.Controls.Add(this.txt_period);
            this.groupBox1.Controls.Add(this.txt_WLength);
            this.groupBox1.Controls.Add(this.txt_NLength);
            this.groupBox1.Controls.Add(this.txt_stream_data);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.combox_filename);
            this.groupBox1.Controls.Add(this.label68);
            this.groupBox1.Controls.Add(this.label69);
            this.groupBox1.Controls.Add(this.label70);
            this.groupBox1.Controls.Add(this.label71);
            this.groupBox1.Controls.Add(this.label72);
            this.groupBox1.Controls.Add(this.label73);
            this.groupBox1.Controls.Add(this.label74);
            this.groupBox1.Controls.Add(this.label75);
            this.groupBox1.Controls.Add(this.label76);
            this.groupBox1.Controls.Add(this.label77);
            this.groupBox1.Controls.Add(this.label78);
            this.groupBox1.Controls.Add(this.txtMinEntry);
            this.groupBox1.Controls.Add(this.txtMaxEntry);
            this.groupBox1.Controls.Add(this.txtR);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btn_statistic);
            this.groupBox1.Controls.Add(this.btn_stopStream);
            this.groupBox1.Controls.Add(this.btn_STREAM);
            this.groupBox1.Controls.Add(this.btn_clear);
            this.groupBox1.Location = new System.Drawing.Point(3, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 442);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stream";
            // 
            // combox_algorithm
            // 
            this.combox_algorithm.FormattingEnabled = true;
            this.combox_algorithm.Location = new System.Drawing.Point(105, 13);
            this.combox_algorithm.Name = "combox_algorithm";
            this.combox_algorithm.Size = new System.Drawing.Size(146, 21);
            this.combox_algorithm.TabIndex = 136;
            // 
            // label_Algorithms
            // 
            this.label_Algorithms.AutoSize = true;
            this.label_Algorithms.Location = new System.Drawing.Point(9, 16);
            this.label_Algorithms.Name = "label_Algorithms";
            this.label_Algorithms.Size = new System.Drawing.Size(55, 13);
            this.label_Algorithms.TabIndex = 135;
            this.label_Algorithms.Text = "Algorithms";
            // 
            // txt_buffer_length
            // 
            this.txt_buffer_length.AutoSize = true;
            this.txt_buffer_length.Location = new System.Drawing.Point(219, 188);
            this.txt_buffer_length.Name = "txt_buffer_length";
            this.txt_buffer_length.Size = new System.Drawing.Size(31, 13);
            this.txt_buffer_length.TabIndex = 134;
            this.txt_buffer_length.Text = "3750";
            // 
            // txt_threshold_sim
            // 
            this.txt_threshold_sim.Location = new System.Drawing.Point(103, 270);
            this.txt_threshold_sim.Name = "txt_threshold_sim";
            this.txt_threshold_sim.Size = new System.Drawing.Size(147, 20);
            this.txt_threshold_sim.TabIndex = 133;
            this.txt_threshold_sim.Text = "0.95";
            // 
            // txt_bufferLength
            // 
            this.txt_bufferLength.Location = new System.Drawing.Point(155, 185);
            this.txt_bufferLength.Name = "txt_bufferLength";
            this.txt_bufferLength.Size = new System.Drawing.Size(39, 20);
            this.txt_bufferLength.TabIndex = 119;
            this.txt_bufferLength.Text = "10";
            this.txt_bufferLength.TextChanged += new System.EventHandler(this.txt_bufferLength_TextChanged);
            // 
            // txt_threshold_std
            // 
            this.txt_threshold_std.Location = new System.Drawing.Point(104, 241);
            this.txt_threshold_std.Name = "txt_threshold_std";
            this.txt_threshold_std.Size = new System.Drawing.Size(147, 20);
            this.txt_threshold_std.TabIndex = 126;
            this.txt_threshold_std.Text = "0.01";
            // 
            // txt_threshold_mean
            // 
            this.txt_threshold_mean.Location = new System.Drawing.Point(103, 211);
            this.txt_threshold_mean.Name = "txt_threshold_mean";
            this.txt_threshold_mean.Size = new System.Drawing.Size(148, 20);
            this.txt_threshold_mean.TabIndex = 125;
            this.txt_threshold_mean.Text = "0.001";
            // 
            // txt_period
            // 
            this.txt_period.Location = new System.Drawing.Point(103, 156);
            this.txt_period.Name = "txt_period";
            this.txt_period.Size = new System.Drawing.Size(147, 20);
            this.txt_period.TabIndex = 129;
            this.txt_period.Text = "375";
            this.txt_period.TextChanged += new System.EventHandler(this.txt_period_TextChanged);
            // 
            // txt_WLength
            // 
            this.txt_WLength.Location = new System.Drawing.Point(104, 127);
            this.txt_WLength.Name = "txt_WLength";
            this.txt_WLength.Size = new System.Drawing.Size(146, 20);
            this.txt_WLength.TabIndex = 116;
            this.txt_WLength.Text = "4";
            // 
            // txt_NLength
            // 
            this.txt_NLength.Location = new System.Drawing.Point(105, 95);
            this.txt_NLength.Name = "txt_NLength";
            this.txt_NLength.Size = new System.Drawing.Size(146, 20);
            this.txt_NLength.TabIndex = 114;
            this.txt_NLength.Text = "40";
            // 
            // txt_stream_data
            // 
            this.txt_stream_data.Location = new System.Drawing.Point(105, 67);
            this.txt_stream_data.Name = "txt_stream_data";
            this.txt_stream_data.Size = new System.Drawing.Size(145, 20);
            this.txt_stream_data.TabIndex = 121;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(8, 273);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(80, 13);
            this.label27.TabIndex = 132;
            this.label27.Text = "Threshold_Sim:";
            // 
            // combox_filename
            // 
            this.combox_filename.FormattingEnabled = true;
            this.combox_filename.Location = new System.Drawing.Point(105, 40);
            this.combox_filename.Name = "combox_filename";
            this.combox_filename.Size = new System.Drawing.Size(146, 21);
            this.combox_filename.TabIndex = 118;
            this.combox_filename.SelectedIndexChanged += new System.EventHandler(this.combox_filename_SelectedIndexChanged);
            this.combox_filename.TextUpdate += new System.EventHandler(this.combox_filename_SelectedIndexChanged);
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(100, 188);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(37, 13);
            this.label68.TabIndex = 131;
            this.label68.Text = "Period";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(137, 188);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(12, 13);
            this.label69.TabIndex = 127;
            this.label69.Text = "x";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(8, 244);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(79, 13);
            this.label70.TabIndex = 124;
            this.label70.Text = "Threshold_Std:";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(200, 188);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(13, 13);
            this.label71.TabIndex = 130;
            this.label71.Text = "=";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(8, 214);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(90, 13);
            this.label72.TabIndex = 123;
            this.label72.Text = "Threshold_Mean:";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(8, 159);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(40, 13);
            this.label73.TabIndex = 128;
            this.label73.Text = "Period:";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(8, 188);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(77, 13);
            this.label74.TabIndex = 120;
            this.label74.Text = "Buffer_Length:";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(8, 43);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(60, 13);
            this.label75.TabIndex = 113;
            this.label75.Text = "File_Name:";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(8, 70);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(72, 13);
            this.label76.TabIndex = 122;
            this.label76.Text = "Stream_Data:";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(8, 130);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(60, 13);
            this.label77.TabIndex = 115;
            this.label77.Text = "W_Length:";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(8, 98);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(57, 13);
            this.label78.TabIndex = 117;
            this.label78.Text = "N_Length:";
            // 
            // txtMinEntry
            // 
            this.txtMinEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinEntry.Location = new System.Drawing.Point(103, 355);
            this.txtMinEntry.Name = "txtMinEntry";
            this.txtMinEntry.Size = new System.Drawing.Size(147, 20);
            this.txtMinEntry.TabIndex = 112;
            this.txtMinEntry.Text = "12";
            // 
            // txtMaxEntry
            // 
            this.txtMaxEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxEntry.Location = new System.Drawing.Point(102, 323);
            this.txtMaxEntry.Name = "txtMaxEntry";
            this.txtMaxEntry.Size = new System.Drawing.Size(148, 20);
            this.txtMaxEntry.TabIndex = 111;
            this.txtMaxEntry.Text = "25";
            // 
            // txtR
            // 
            this.txtR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtR.Location = new System.Drawing.Point(102, 296);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(148, 20);
            this.txtR.TabIndex = 110;
            this.txtR.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 109;
            this.label2.Text = "MinEntryPerNode:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 108;
            this.label6.Text = "MaxEntryPerNode:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 107;
            this.label8.Text = "R:";
            // 
            // btn_statistic
            // 
            this.btn_statistic.Location = new System.Drawing.Point(197, 408);
            this.btn_statistic.Name = "btn_statistic";
            this.btn_statistic.Size = new System.Drawing.Size(54, 28);
            this.btn_statistic.TabIndex = 39;
            this.btn_statistic.Text = "Statistic";
            this.btn_statistic.UseVisualStyleBackColor = true;
            this.btn_statistic.Click += new System.EventHandler(this.btn_statistic_Click);
            // 
            // txt_data_to_calc_W
            // 
            this.txt_data_to_calc_W.Location = new System.Drawing.Point(92, 15);
            this.txt_data_to_calc_W.Name = "txt_data_to_calc_W";
            this.txt_data_to_calc_W.Size = new System.Drawing.Size(164, 20);
            this.txt_data_to_calc_W.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Estimate_Data:";
            // 
            // chart_timeSeries
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_timeSeries.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_timeSeries.Legends.Add(legend1);
            this.chart_timeSeries.Location = new System.Drawing.Point(282, 12);
            this.chart_timeSeries.Name = "chart_timeSeries";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "data";
            this.chart_timeSeries.Series.Add(series1);
            this.chart_timeSeries.Size = new System.Drawing.Size(940, 497);
            this.chart_timeSeries.TabIndex = 38;
            this.chart_timeSeries.Text = "Chart";
            title1.DockedToChartArea = "ChartArea1";
            title1.DockingOffset = -6;
            title1.Name = "Chart";
            title1.Text = "Chart";
            this.chart_timeSeries.Titles.Add(title1);
            // 
            // Estimate_Period
            // 
            this.Estimate_Period.Controls.Add(this.label10);
            this.Estimate_Period.Controls.Add(this.txt_period_max);
            this.Estimate_Period.Controls.Add(this.btn_getW);
            this.Estimate_Period.Controls.Add(this.txt_threshold);
            this.Estimate_Period.Controls.Add(this.txt_data_to_calc_W);
            this.Estimate_Period.Controls.Add(this.label_threshold);
            this.Estimate_Period.Controls.Add(this.label3);
            this.Estimate_Period.Controls.Add(this.btn_Period);
            this.Estimate_Period.Location = new System.Drawing.Point(3, 1);
            this.Estimate_Period.Name = "Estimate_Period";
            this.Estimate_Period.Size = new System.Drawing.Size(267, 103);
            this.Estimate_Period.TabIndex = 39;
            this.Estimate_Period.TabStop = false;
            this.Estimate_Period.Text = "Estimate";
            // 
            // groupBox_status
            // 
            this.groupBox_status.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_status.Controls.Add(this.txt_speed);
            this.groupBox_status.Controls.Add(this.label9);
            this.groupBox_status.Controls.Add(this.label11);
            this.groupBox_status.Controls.Add(this.txt_index_stream);
            this.groupBox_status.Controls.Add(this.label1);
            this.groupBox_status.Controls.Add(this.label4);
            this.groupBox_status.ForeColor = System.Drawing.Color.Black;
            this.groupBox_status.Location = new System.Drawing.Point(1047, 506);
            this.groupBox_status.Name = "groupBox_status";
            this.groupBox_status.Size = new System.Drawing.Size(175, 59);
            this.groupBox_status.TabIndex = 40;
            this.groupBox_status.TabStop = false;
            this.groupBox_status.Text = "Status";
            // 
            // txt_speed
            // 
            this.txt_speed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_speed.Location = new System.Drawing.Point(65, 37);
            this.txt_speed.Name = "txt_speed";
            this.txt_speed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_speed.Size = new System.Drawing.Size(41, 13);
            this.txt_speed.TabIndex = 47;
            this.txt_speed.Text = "0";
            this.txt_speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(102, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Point/Second";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Speed:";
            // 
            // txt_index_stream
            // 
            this.txt_index_stream.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txt_index_stream.Location = new System.Drawing.Point(65, 16);
            this.txt_index_stream.Name = "txt_index_stream";
            this.txt_index_stream.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_index_stream.Size = new System.Drawing.Size(38, 13);
            this.txt_index_stream.TabIndex = 44;
            this.txt_index_stream.Text = "0";
            this.txt_index_stream.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Point";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Received:";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 567);
            this.Controls.Add(this.groupBox_status);
            this.Controls.Add(this.Estimate_Period);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart_timeSeries);
            this.Name = "Main_Form";
            this.Text = "DISCORD_DISCOVERY_STREAM ver 2.2-Sep 4th 2017";
            this.Load += new System.EventHandler(this.form_SAX_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_timeSeries)).EndInit();
            this.Estimate_Period.ResumeLayout(false);
            this.Estimate_Period.PerformLayout();
            this.groupBox_status.ResumeLayout(false);
            this.groupBox_status.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_getW;
        private System.Windows.Forms.TextBox txt_threshold;
        private System.Windows.Forms.Label label_threshold;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_period_max;
        private System.Windows.Forms.Button btn_Period;
        private System.Windows.Forms.Button btn_stopStream;
        private System.Windows.Forms.Button btn_STREAM;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_data_to_calc_W;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_timeSeries;
        private System.Windows.Forms.GroupBox Estimate_Period;
        private System.Windows.Forms.Button btn_statistic;
        private System.Windows.Forms.TextBox txtMinEntry;
        private System.Windows.Forms.TextBox txtMaxEntry;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox combox_algorithm;
        private System.Windows.Forms.Label label_Algorithms;
        private System.Windows.Forms.Label txt_buffer_length;
        private System.Windows.Forms.TextBox txt_threshold_sim;
        private System.Windows.Forms.TextBox txt_bufferLength;
        private System.Windows.Forms.TextBox txt_threshold_std;
        private System.Windows.Forms.TextBox txt_threshold_mean;
        private System.Windows.Forms.TextBox txt_period;
        private System.Windows.Forms.TextBox txt_WLength;
        private System.Windows.Forms.TextBox txt_NLength;
        private System.Windows.Forms.TextBox txt_stream_data;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox combox_filename;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.GroupBox groupBox_status;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txt_index_stream;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txt_speed;
    }
}

