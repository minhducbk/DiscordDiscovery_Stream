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
            this.txt_status = new System.Windows.Forms.Label();
            this.btn_statistic = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.txt_data_to_calc_W = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chart_timeSeries = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Estimate_Period = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_timeSeries)).BeginInit();
            this.Estimate_Period.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_getW
            // 
            this.btn_getW.Location = new System.Drawing.Point(356, 138);
            this.btn_getW.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_getW.Name = "btn_getW";
            this.btn_getW.Size = new System.Drawing.Size(156, 44);
            this.btn_getW.TabIndex = 10;
            this.btn_getW.Text = "Get W";
            this.btn_getW.UseVisualStyleBackColor = true;
            this.btn_getW.Click += new System.EventHandler(this.btn_GetW_Click);
            // 
            // txt_threshold
            // 
            this.txt_threshold.Location = new System.Drawing.Point(184, 142);
            this.txt_threshold.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_threshold.Name = "txt_threshold";
            this.txt_threshold.Size = new System.Drawing.Size(156, 31);
            this.txt_threshold.TabIndex = 14;
            this.txt_threshold.Text = "0.005";
            // 
            // label_threshold
            // 
            this.label_threshold.AutoSize = true;
            this.label_threshold.Location = new System.Drawing.Point(18, 148);
            this.label_threshold.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_threshold.Name = "label_threshold";
            this.label_threshold.Size = new System.Drawing.Size(173, 25);
            this.label_threshold.TabIndex = 13;
            this.label_threshold.Text = "Threshold_Error:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 90);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 25);
            this.label10.TabIndex = 33;
            this.label10.Text = "Period_max:";
            // 
            // txt_period_max
            // 
            this.txt_period_max.Location = new System.Drawing.Point(184, 85);
            this.txt_period_max.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_period_max.Name = "txt_period_max";
            this.txt_period_max.Size = new System.Drawing.Size(156, 31);
            this.txt_period_max.TabIndex = 34;
            // 
            // btn_Period
            // 
            this.btn_Period.Location = new System.Drawing.Point(356, 81);
            this.btn_Period.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_Period.Name = "btn_Period";
            this.btn_Period.Size = new System.Drawing.Size(156, 44);
            this.btn_Period.TabIndex = 31;
            this.btn_Period.Text = "Get Period";
            this.btn_Period.UseVisualStyleBackColor = true;
            this.btn_Period.Click += new System.EventHandler(this.btnPeriod_Click);
            // 
            // btn_stopStream
            // 
            this.btn_stopStream.Location = new System.Drawing.Point(264, 785);
            this.btn_stopStream.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_stopStream.Name = "btn_stopStream";
            this.btn_stopStream.Size = new System.Drawing.Size(118, 54);
            this.btn_stopStream.TabIndex = 23;
            this.btn_stopStream.Text = "Pause";
            this.btn_stopStream.UseVisualStyleBackColor = true;
            this.btn_stopStream.Click += new System.EventHandler(this.btn_stopStream_Click);
            // 
            // btn_STREAM
            // 
            this.btn_STREAM.Location = new System.Drawing.Point(122, 785);
            this.btn_STREAM.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_STREAM.Name = "btn_STREAM";
            this.btn_STREAM.Size = new System.Drawing.Size(120, 54);
            this.btn_STREAM.TabIndex = 15;
            this.btn_STREAM.Text = "STREAM";
            this.btn_STREAM.UseVisualStyleBackColor = true;
            this.btn_STREAM.Click += new System.EventHandler(this.btn_Stream_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(22, 785);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(88, 54);
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
            this.groupBox1.Controls.Add(this.txt_status);
            this.groupBox1.Controls.Add(this.btn_statistic);
            this.groupBox1.Controls.Add(this.Status);
            this.groupBox1.Controls.Add(this.btn_stopStream);
            this.groupBox1.Controls.Add(this.btn_STREAM);
            this.groupBox1.Controls.Add(this.btn_clear);
            this.groupBox1.Location = new System.Drawing.Point(6, 212);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(534, 850);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stream";
            // 
            // combox_algorithm
            // 
            this.combox_algorithm.FormattingEnabled = true;
            this.combox_algorithm.Location = new System.Drawing.Point(210, 25);
            this.combox_algorithm.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.combox_algorithm.Name = "combox_algorithm";
            this.combox_algorithm.Size = new System.Drawing.Size(288, 33);
            this.combox_algorithm.TabIndex = 136;
            // 
            // label_Algorithms
            // 
            this.label_Algorithms.AutoSize = true;
            this.label_Algorithms.Location = new System.Drawing.Point(18, 31);
            this.label_Algorithms.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_Algorithms.Name = "label_Algorithms";
            this.label_Algorithms.Size = new System.Drawing.Size(113, 25);
            this.label_Algorithms.TabIndex = 135;
            this.label_Algorithms.Text = "Algorithms";
            // 
            // txt_buffer_length
            // 
            this.txt_buffer_length.AutoSize = true;
            this.txt_buffer_length.Location = new System.Drawing.Point(438, 362);
            this.txt_buffer_length.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.txt_buffer_length.Name = "txt_buffer_length";
            this.txt_buffer_length.Size = new System.Drawing.Size(60, 25);
            this.txt_buffer_length.TabIndex = 134;
            this.txt_buffer_length.Text = "3750";
            // 
            // txt_threshold_sim
            // 
            this.txt_threshold_sim.Location = new System.Drawing.Point(206, 519);
            this.txt_threshold_sim.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_threshold_sim.Name = "txt_threshold_sim";
            this.txt_threshold_sim.Size = new System.Drawing.Size(290, 31);
            this.txt_threshold_sim.TabIndex = 133;
            this.txt_threshold_sim.Text = "0.95";
            // 
            // txt_bufferLength
            // 
            this.txt_bufferLength.Location = new System.Drawing.Point(310, 356);
            this.txt_bufferLength.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_bufferLength.Name = "txt_bufferLength";
            this.txt_bufferLength.Size = new System.Drawing.Size(74, 31);
            this.txt_bufferLength.TabIndex = 119;
            this.txt_bufferLength.Text = "10";
            this.txt_bufferLength.TextChanged += new System.EventHandler(this.txt_bufferLength_TextChanged);
            // 
            // txt_threshold_std
            // 
            this.txt_threshold_std.Location = new System.Drawing.Point(208, 463);
            this.txt_threshold_std.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_threshold_std.Name = "txt_threshold_std";
            this.txt_threshold_std.Size = new System.Drawing.Size(290, 31);
            this.txt_threshold_std.TabIndex = 126;
            this.txt_threshold_std.Text = "0.01";
            // 
            // txt_threshold_mean
            // 
            this.txt_threshold_mean.Location = new System.Drawing.Point(206, 406);
            this.txt_threshold_mean.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_threshold_mean.Name = "txt_threshold_mean";
            this.txt_threshold_mean.Size = new System.Drawing.Size(292, 31);
            this.txt_threshold_mean.TabIndex = 125;
            this.txt_threshold_mean.Text = "0.001";
            // 
            // txt_period
            // 
            this.txt_period.Location = new System.Drawing.Point(206, 300);
            this.txt_period.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_period.Name = "txt_period";
            this.txt_period.Size = new System.Drawing.Size(290, 31);
            this.txt_period.TabIndex = 129;
            this.txt_period.Text = "375";
            this.txt_period.TextChanged += new System.EventHandler(this.txt_period_TextChanged);
            // 
            // txt_WLength
            // 
            this.txt_WLength.Location = new System.Drawing.Point(208, 244);
            this.txt_WLength.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_WLength.Name = "txt_WLength";
            this.txt_WLength.Size = new System.Drawing.Size(288, 31);
            this.txt_WLength.TabIndex = 116;
            this.txt_WLength.Text = "4";
            // 
            // txt_NLength
            // 
            this.txt_NLength.Location = new System.Drawing.Point(210, 183);
            this.txt_NLength.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_NLength.Name = "txt_NLength";
            this.txt_NLength.Size = new System.Drawing.Size(288, 31);
            this.txt_NLength.TabIndex = 114;
            this.txt_NLength.Text = "40";
            // 
            // txt_stream_data
            // 
            this.txt_stream_data.Location = new System.Drawing.Point(210, 129);
            this.txt_stream_data.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_stream_data.Name = "txt_stream_data";
            this.txt_stream_data.Size = new System.Drawing.Size(286, 31);
            this.txt_stream_data.TabIndex = 121;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(16, 525);
            this.label27.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(162, 25);
            this.label27.TabIndex = 132;
            this.label27.Text = "Threshold_Sim:";
            // 
            // combox_filename
            // 
            this.combox_filename.FormattingEnabled = true;
            this.combox_filename.Location = new System.Drawing.Point(210, 77);
            this.combox_filename.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.combox_filename.Name = "combox_filename";
            this.combox_filename.Size = new System.Drawing.Size(288, 33);
            this.combox_filename.TabIndex = 118;
            this.combox_filename.SelectedIndexChanged += new System.EventHandler(this.combox_filename_SelectedIndexChanged);
            this.combox_filename.TextUpdate += new System.EventHandler(this.combox_filename_SelectedIndexChanged);
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(200, 362);
            this.label68.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(74, 25);
            this.label68.TabIndex = 131;
            this.label68.Text = "Period";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(274, 362);
            this.label69.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(23, 25);
            this.label69.TabIndex = 127;
            this.label69.Text = "x";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(16, 469);
            this.label70.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(158, 25);
            this.label70.TabIndex = 124;
            this.label70.Text = "Threshold_Std:";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(400, 362);
            this.label71.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(24, 25);
            this.label71.TabIndex = 130;
            this.label71.Text = "=";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(16, 412);
            this.label72.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(180, 25);
            this.label72.TabIndex = 123;
            this.label72.Text = "Threshold_Mean:";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(16, 306);
            this.label73.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(80, 25);
            this.label73.TabIndex = 128;
            this.label73.Text = "Period:";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(16, 362);
            this.label74.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(146, 25);
            this.label74.TabIndex = 120;
            this.label74.Text = "Buffer_length:";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(16, 83);
            this.label75.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(118, 25);
            this.label75.TabIndex = 113;
            this.label75.Text = "File_name:";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(16, 135);
            this.label76.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(140, 25);
            this.label76.TabIndex = 122;
            this.label76.Text = "Stream_data:";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(16, 250);
            this.label77.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(109, 25);
            this.label77.TabIndex = 115;
            this.label77.Text = "W_length:";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(16, 188);
            this.label78.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(111, 25);
            this.label78.TabIndex = 117;
            this.label78.Text = "N_Length:";
            // 
            // txtMinEntry
            // 
            this.txtMinEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinEntry.Location = new System.Drawing.Point(206, 683);
            this.txtMinEntry.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtMinEntry.Name = "txtMinEntry";
            this.txtMinEntry.Size = new System.Drawing.Size(290, 32);
            this.txtMinEntry.TabIndex = 112;
            this.txtMinEntry.Text = "12";
            // 
            // txtMaxEntry
            // 
            this.txtMaxEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxEntry.Location = new System.Drawing.Point(204, 621);
            this.txtMaxEntry.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtMaxEntry.Name = "txtMaxEntry";
            this.txtMaxEntry.Size = new System.Drawing.Size(292, 32);
            this.txtMaxEntry.TabIndex = 111;
            this.txtMaxEntry.Text = "25";
            // 
            // txtR
            // 
            this.txtR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtR.Location = new System.Drawing.Point(204, 569);
            this.txtR.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(292, 32);
            this.txtR.TabIndex = 110;
            this.txtR.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 688);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 26);
            this.label2.TabIndex = 109;
            this.label2.Text = "MinEntryPerNode:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 627);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 26);
            this.label6.TabIndex = 108;
            this.label6.Text = "MaxEntryPerNode:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 575);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 26);
            this.label8.TabIndex = 107;
            this.label8.Text = "R:";
            // 
            // txt_status
            // 
            this.txt_status.AutoSize = true;
            this.txt_status.Location = new System.Drawing.Point(290, 735);
            this.txt_status.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.txt_status.Name = "txt_status";
            this.txt_status.Size = new System.Drawing.Size(74, 25);
            this.txt_status.TabIndex = 41;
            this.txt_status.Text = "Ready";
            // 
            // btn_statistic
            // 
            this.btn_statistic.Location = new System.Drawing.Point(394, 785);
            this.btn_statistic.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_statistic.Name = "btn_statistic";
            this.btn_statistic.Size = new System.Drawing.Size(108, 54);
            this.btn_statistic.TabIndex = 39;
            this.btn_statistic.Text = "Statistic";
            this.btn_statistic.UseVisualStyleBackColor = true;
            this.btn_statistic.Click += new System.EventHandler(this.btn_statistic_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(16, 735);
            this.Status.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(79, 25);
            this.Status.TabIndex = 35;
            this.Status.Text = "Status:";
            // 
            // txt_data_to_calc_W
            // 
            this.txt_data_to_calc_W.Location = new System.Drawing.Point(184, 29);
            this.txt_data_to_calc_W.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_data_to_calc_W.Name = "txt_data_to_calc_W";
            this.txt_data_to_calc_W.Size = new System.Drawing.Size(324, 31);
            this.txt_data_to_calc_W.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "Estimate_data:";
            // 
            // chart_timeSeries
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_timeSeries.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_timeSeries.Legends.Add(legend1);
            this.chart_timeSeries.Location = new System.Drawing.Point(564, 23);
            this.chart_timeSeries.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chart_timeSeries.Name = "chart_timeSeries";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "data";
            this.chart_timeSeries.Series.Add(series1);
            this.chart_timeSeries.Size = new System.Drawing.Size(1888, 1038);
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
            this.Estimate_Period.Location = new System.Drawing.Point(6, 2);
            this.Estimate_Period.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Estimate_Period.Name = "Estimate_Period";
            this.Estimate_Period.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Estimate_Period.Size = new System.Drawing.Size(534, 198);
            this.Estimate_Period.TabIndex = 39;
            this.Estimate_Period.TabStop = false;
            this.Estimate_Period.Text = "Estimate";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2476, 1077);
            this.Controls.Add(this.Estimate_Period);
            this.Controls.Add(this.chart_timeSeries);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Main_Form";
            this.Text = "HOTSAX_STREAM ver 2.1-Sep 4th 2017";
            this.Load += new System.EventHandler(this.form_SAX_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_timeSeries)).EndInit();
            this.Estimate_Period.ResumeLayout(false);
            this.Estimate_Period.PerformLayout();
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
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Button btn_statistic;
        private System.Windows.Forms.Label txt_status;
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
    }
}

