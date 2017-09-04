using DiscordDiscovery.BoundingBox;
using DiscordDiscovery.Estimate;
using DiscordDiscovery.HOTSAX;
using DiscordDiscovery.Squeezer;
using DiscordDiscovery.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordDiscovery
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private const double SCALE = 1.1;
        bool is_stream_clicked = false;//help to control Pause, Resume
        private Thread chart_thread;
        private ManualResetEvent manualResetEvent = new ManualResetEvent(true);
        bool is_pause = true;
        private double K_LOWER_PERCENT = (5 / 100.0); // note: double type

        private void doStream(String file_name, String algorithm, List<double> result, List<double> norm_buffer, List<double> data_to_calc_w, List<double> stream_data, int N_LENGTH, int W_LENGTH, List<double> raw_buffer, double threshold_mean, double threshold_std, double threshold_sim, int R, int maxEntry, int minEntry, int period)
        {
            bool is_the_first_time = true;//control running HOTSAX for the first time
            int raw_buffer_len = raw_buffer.Count;
            int norm_buffer_len = norm_buffer.Count;
            //get last raw segment:
            //List<double> last_raw_segment = raw_buffer.GetRange(raw_buffer_len - N_LENGTH, N_LENGTH);

            //store index of the limited searching space (in case (b)):
            List<int> candidate_list = new List<int>();

            int index_stream = 0;//control the stream data point
            int index_table = 0;
            int i_b = 0; //calc number of cases (b).
            int data_calc_w_len = data_to_calc_w.Count;

            //store result from HOTSAX algorithm:
            //List<double> result
            //result[0]: dist
            //result[1]: loc

            double next_data_point;
            double currDist;
            System.Diagnostics.Stopwatch watch2; ;///calc execution time
            long elapsedMs2 = 0;

            double small_match_dist = 0;
            List<double> first_segment;

            double new_norm_point;

            AugmentedTrie tree;
            Dictionary<string, int> count_table;
            Dictionary<int, string> total_table;

            count_table = new Dictionary<string, int>();
            total_table = new Dictionary<int, string>();

            //Making the root node:
            HOTSAX.TreeNode root = new HOTSAX.TreeNode('R');

            //init the path (to print the tree later)
            List<char> path = new List<char>();

            // Making the augmented tree:
            tree = new AugmentedTrie(root, path);

            // Squeezer
            List<int> cluster_belong = new List<int>();
            List<Cluster_Squeezer> b_cluster = new List<Cluster_Squeezer>();
            List<int> lCluster_NonMember = new List<int>();

            // Bounding_Box
            int this_id_item = int.MinValue;
            List<int> this_id_itemList = new List<int>();
            RTree<int> this_RTree = new RTree<int>(maxEntry, minEntry);
            List<BoundingBox.Rectangle> this_recList = new List<BoundingBox.Rectangle>();
            double this_best_so_far_dist = -Constants.INFINITE;
            double this_best_so_far_loc = -1;
            BoundingBox.Rectangle new_rec;

            // Useless variable to pass parameter
            int dumb = 0;
            List<int> dumb_list = new List<int>();
            List<BoundingBox.Rectangle> dumb_rectlist = new List<BoundingBox.Rectangle>();
            RTree<int> dumb_rtree = new RTree<int>(maxEntry, minEntry);

            // Sanchez_method
            double this_best_so_far_dist_TheMostDiscord = -Constants.INFINITE;


            double old_mean = MathFuncs.CalcMean(raw_buffer);
            double old_std = MathFuncs.CalcStd(raw_buffer, old_mean);
            double new_mean, new_std;

            List<double> result_dist = new List<double>();
            List<double> result_loc = new List<double>();

            var watch = System.Diagnostics.Stopwatch.StartNew();///calc execution time
            int num_nor = 0;

            while (true)
            {
                manualResetEvent.WaitOne(Timeout.Infinite);//help for PAUSE, RESUME button

                if (is_the_first_time)
                {
                    switch (algorithm)
                    {
                        case "HOTSAX_Squeezer_Stream":
                            result = BitClusterDiscord.squeezer(ref lCluster_NonMember, ref cluster_belong, ref b_cluster, norm_buffer, N_LENGTH, W_LENGTH, threshold_sim, BitClusterDiscord.PAA);                            Console.WriteLine("Case 1");
                            break;
                        case "BFHS":
                        case "HOTSAX_Stream":
                            result = HOTSAX.HOTSAX.originalHOTSAX(0, norm_buffer, N_LENGTH, W_LENGTH,
                                    ref tree, ref count_table, ref total_table, true);
                            break;
                        case "Bounding_Box":
                        case "Sanchez_Method":
                            result = BoundingBox.BoundingBoxDiscordDiscovery.RunOfflineMinDist(raw_buffer, N_LENGTH, maxEntry, minEntry, R, W_LENGTH, ref this_id_item, ref this_id_itemList, ref this_recList, ref this_RTree, true);
                            this_best_so_far_dist = result[0];
                            this_best_so_far_loc = result[1];
                            this_best_so_far_dist_TheMostDiscord = result[0];
                            break;
                    }
                    is_the_first_time = false;
                    //print through console 
                    Console.WriteLine("\n\t best_so_far_dist = " + result.ElementAt(0) +
                                         "\n\t best_so_far_loc = " + result.ElementAt(1) +
                                          "\n\t execution_time = " + elapsedMs2);
                    Console.WriteLine("----------------- finished i = {0}--------------- \n\n", index_stream - 1);
                    Console.WriteLine("Finished the first call.");
                    if (chart_timeSeries.IsHandleCreated)
                    {
                        try
                        {
                            // call updateChart fucntion in GUI thread by chart thread

                            if (algorithm == "Bounding_Box" || algorithm == "Sanchez_Method")
                                this.Invoke((MethodInvoker)delegate { updateChart(raw_buffer, (int)(result[1]), N_LENGTH); });
                            else
                                this.Invoke((MethodInvoker)delegate { updateChart(norm_buffer, (int)(result[1]), N_LENGTH); });
                        }
                        catch
                        { }
                    }

                }
                else
                {
                    if (index_stream >= stream_data.Count)
                    {
                        watch.Stop();//stop timer
                        var elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine("Streaming is Done in " + elapsedMs + ".\nKeep going...Please wait");
                        // Write File
                        string[] all_dist = result_dist.Select(dist => dist.ToString()).ToArray();
                        string[] all_loc = result_loc.Select(loc => loc.ToString()).ToArray();

                        var data_name = System.IO.Path.GetFileNameWithoutExtension(file_name);
                        var extension = System.IO.Path.GetExtension(file_name);
                        string newPath = "Output\\" + data_name + "\\" + algorithm;
                        System.IO.Directory.CreateDirectory(newPath);
                        System.IO.File.WriteAllLines(newPath + "\\dist" + extension, all_dist);
                        System.IO.File.WriteAllLines(newPath + "\\loc" + extension, all_loc);
                        using (System.IO.StreamWriter file =
                                new System.IO.StreamWriter(newPath + "\\time" + extension, false))
                        {
                            file.WriteLine(elapsedMs);
                        }

                        Statistical_Form statistical_form = new Statistical_Form(result_loc, result_dist, elapsedMs);
                        System.Windows.Forms.MessageBox.Show("stream_data ran out of points");
                        Console.WriteLine("num norm: " + num_nor);
                        return;
                    }

                    //get the next data point:
                    next_data_point = stream_data[index_stream];
                    
                    new_mean = MathFuncs.CalcNewMean(old_mean, raw_buffer_len, raw_buffer[0], next_data_point);

                    //store the last subsequence of the buffer for Bounding Box and Sanchez algorithms:
                    List<double> last_sub = raw_buffer.GetRange(raw_buffer.Count - N_LENGTH, N_LENGTH);

                    //get the first sub before update the buffer (help to find the small match in Liu's method)
                    List<double> first_sub = raw_buffer.GetRange(0, N_LENGTH);

                    //update raw_buffer:
                    raw_buffer.Add(next_data_point);
                    raw_buffer.RemoveAt(0);

                    new_std = MathFuncs.CalcStd(raw_buffer, new_mean);
                    watch2 = System.Diagnostics.Stopwatch.StartNew();///calc execution time

                    switch (algorithm)
                    {
                        case "HOTSAX_Squeezer_Stream":
                        case "BFHS":
                        case "HOTSAX_Stream":
                            if ((Math.Abs(new_mean - old_mean) <= threshold_mean) && (Math.Abs(new_std - old_std) <= threshold_std))
                            {
                                new_norm_point = (next_data_point - old_mean) / old_std;

                                index_table++;

                                norm_buffer.Add(new_norm_point);

                                //calc 'currDist':
                                currDist = MathFuncs.EuDistance(norm_buffer.GetRange((int)result[1], N_LENGTH), norm_buffer.GetRange(norm_buffer.Count - N_LENGTH, N_LENGTH));


                                //if the case (a): Modify the Tree, Tables:
                                if (currDist < result[0] || (int)(result[1]) == 0 || algorithm == "BFHS")
                                {
                                    Console.WriteLine("--- Running case (a)... ---");

                                    if (algorithm == "HOTSAX_Squeezer_Stream")
                                    {
                                        result = BitClusterDiscord.squeezer(ref lCluster_NonMember, ref cluster_belong, ref b_cluster, norm_buffer.Select(point => point).ToList(), N_LENGTH, W_LENGTH, threshold_sim, BitClusterDiscord.PAA, index_table, false);
                                        //update buffer:
                                        norm_buffer.RemoveAt(0);
                                        Console.WriteLine("B_cluster.Count: " + b_cluster.Count.ToString());
                                    }
                                    else
                                    {
                                        //call the original HOTSAX ver3:
                                        result = HOTSAX.HOTSAX.originalHOTSAX(index_table, norm_buffer,
                                                        N_LENGTH, W_LENGTH, ref tree, ref count_table, ref total_table);
                                    }
                                }
                                else // case (b), we can limit candidate_list:
                                {
                                    Console.WriteLine("--------------- Running case (b)... -----------------");
                                    /* Find the candidate_list:  */
                                    candidate_list.Clear(); //reset the list


                                    //The local discord at time t:
                                    candidate_list.Add((int)(result[1]) - 1);

                                    //The subsequence (m-n+1, n)(t+1):
                                    candidate_list.Add(norm_buffer_len - N_LENGTH);

                                    //The small match of subsequence (1, n)(t):
                                    first_segment = norm_buffer.GetRange(0, N_LENGTH);
                                    for (int j = N_LENGTH; j <= norm_buffer_len - N_LENGTH; j++)
                                    {
                                        small_match_dist = MathFuncs.EuDistance(norm_buffer.GetRange(j, N_LENGTH), first_segment);
                                        if (small_match_dist < result[0])
                                        {
                                            if ((int)(result[1]) != j)
                                                candidate_list.Add(j - 1);
                                        }
                                    }

                                    if (algorithm == "HOTSAX_Squeezer_Stream")
                                    {
                                        result = BitClusterDiscord.squeezerAgain(ref lCluster_NonMember, candidate_list, index_table, ref cluster_belong, ref b_cluster, norm_buffer.Select(point => point).ToList(), N_LENGTH, W_LENGTH, threshold_sim, BitClusterDiscord.PAA);
                                        //update buffer:
                                        norm_buffer.RemoveAt(0);
                                        Console.WriteLine("B_cluster.Count: " + b_cluster.Count.ToString());
                                    }
                                    else
                                    {
                                        //update buffer:
                                        norm_buffer.RemoveAt(0);

                                        //searching on candidates;  
                                        result = HOTSAX.HOTSAX.candidateHOTSAX(candidate_list, index_table, norm_buffer,
                                                        N_LENGTH, W_LENGTH, ref tree, ref count_table, ref total_table);
                                    }


                                    i_b++;//count number of cases (b) - just for testing

                                    Console.WriteLine("len(candidate_list) = {0}, Number of cases (b) is {1}/{2}", candidate_list.Count, i_b, index_stream);
                                }//end else - case (b)

                            }
                            else
                            {
                                Console.WriteLine("--------------- Normalizing buffer ... -----------------");
                                num_nor++;
                                index_table = 0;
                                norm_buffer = MathFuncs.zScoreNorm(raw_buffer, raw_buffer_len);
                                count_table = new Dictionary<string, int>();
                                total_table = new Dictionary<int, string>();
                                cluster_belong = new List<int>();
                                b_cluster = new List<Cluster_Squeezer>();

                                //Making the root node:
                                root = new HOTSAX.TreeNode('R');

                                //init the path (to print the tree later)
                                path = new List<char>();

                                // Making the augmented tree:
                                tree = new AugmentedTrie(root, path);

                                if (algorithm == "HOTSAX_Squeezer_Stream")
                                {
                                    result = BitClusterDiscord.squeezer(ref lCluster_NonMember, ref cluster_belong, ref b_cluster, norm_buffer, N_LENGTH, W_LENGTH, threshold_sim, BitClusterDiscord.PAA);
                                }
                                else
                                    result = HOTSAX.HOTSAX.originalHOTSAX(0, norm_buffer, N_LENGTH, W_LENGTH,
                                            ref tree, ref count_table, ref total_table, true);
                                old_std = new_std;
                                old_mean = new_mean;
                            }
                            break;
                        case "Bounding_Box":
                            //update last_sub at time t to get new_sub at time (t+1):
                            last_sub.Add(next_data_point);
                            last_sub.RemoveAt(0);
                            List<double> new_sub = last_sub; // the same object

                            // Insert the new entry into the tree:
                            this_id_item++;

                            // Add the new rec to the tree:
                            new_rec = new BoundingBox.Rectangle(Utils.MathFuncs.PAA_Lower(new_sub, W_LENGTH, R).ToArray(), Utils.MathFuncs.PAA_Upper(new_sub, W_LENGTH, R).ToArray(), raw_buffer.Count - N_LENGTH + 1 + index_stream);
                            this_RTree.Add(new_rec, this_id_item);
                            this_recList.Add(new_rec);
                            this_id_itemList.Add(this_id_item);

                            //remove the oldest entry:
                            this_RTree.Delete(this_recList[index_stream], this_id_itemList[index_stream]);

                            result = BoundingBoxDiscordDiscovery.RunOnline_LiuMethod_edited(raw_buffer, index_stream, first_sub, this_RTree, this_best_so_far_dist, (int)this_best_so_far_loc, N_LENGTH, W_LENGTH);
                            this_best_so_far_dist = result[0];
                            this_best_so_far_loc = result[1];

                            break;
                        case "Sanchez_Method":
                            //update last_sub at time t to get new_sub at time (t+1):
                            last_sub.Add(next_data_point);
                            last_sub.RemoveAt(0);
                            new_sub = last_sub; // the same object

                            // Insert the new entry into the tree:
                            this_id_item++;

                            // Add the new rec to the tree:
                            new_rec = new BoundingBox.Rectangle(Utils.MathFuncs.PAA_Lower(new_sub, W_LENGTH, R).ToArray(), Utils.MathFuncs.PAA_Upper(new_sub, W_LENGTH, R).ToArray(), raw_buffer.Count - N_LENGTH + 1 + index_stream);
                            this_RTree.Add(new_rec, this_id_item);
                            this_recList.Add(new_rec);
                            this_id_itemList.Add(this_id_item);

                            //remove the oldest entry:
                            this_RTree.Delete(this_recList[index_stream], this_id_itemList[index_stream]);

                            result = BoundingBoxDiscordDiscovery.NewOnlineAlgorithm(raw_buffer, 2 * period, index_stream, period, new_sub, this_RTree, N_LENGTH, W_LENGTH, R, maxEntry, minEntry, ref this_best_so_far_dist_TheMostDiscord);

                            break;
                    }

                    watch2.Stop(); //stop timer
                    elapsedMs2 = watch2.ElapsedMilliseconds;
                    //print through console 
                    Console.WriteLine("\n\t best_so_far_dist = " + result.ElementAt(0) +
                                         "\n\t best_so_far_loc = " + result.ElementAt(1) +
                                          "\n\t execution_time = " + elapsedMs2);
                    Console.WriteLine("----------------- finished i = {0}--------------- \n\n", index_stream);
                    index_stream++;// make 'index' increase by 1 to get the next data point
                }//end else


                if (chart_timeSeries.IsHandleCreated)
                {
                    try
                    {
                        // call updateChart fucntion in GUI thread by chart thread

                        if (algorithm == "Bounding_Box" || algorithm == "Sanchez_Method")
                            this.Invoke((MethodInvoker)delegate { updateChart(raw_buffer, (int)(result[1]), N_LENGTH); });
                        else
                            this.Invoke((MethodInvoker)delegate { updateChart(norm_buffer, (int)(result[1]), N_LENGTH); });
                    }
                    catch
                    { }
                }


                // Store result
                result_dist.Add(result.ElementAt(0));
                result_loc.Add(result.ElementAt(1));
                //Thread.Sleep(2000);
            }
        }

        private void updateChart(List<double> norm_buffer, int loc, int N_LENGTH)
        {
            chart_timeSeries.Series["data"].Points.Clear();
            for (int i = 0; i < norm_buffer.Count; i++)
            {
                chart_timeSeries.Series["data"].Points.AddY(norm_buffer[i]);
                if (loc <= i && i < loc + N_LENGTH && loc >= 0)
                {
                    chart_timeSeries.Series["data"].Points[i].Color = Color.Red;
                }
            }
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {

            //this.txt_best_so_far_dist_Heuristic.Clear();
            //this.txt_best_so_far_loc_Heuristic.Clear();
            //this.txt_execution_time_Heuristic.Clear();
            this.txt_WLength.Clear();
            this.txt_threshold_mean.Clear();
            this.txt_threshold_std.Clear();
            //this.txt_threshold.Clear();
            this.txt_period.Clear();
            this.txt_status.Text = "Cleared !";
        }
        private void btn_GetW_Click(object sender, EventArgs e)
        {
            this.txt_status.Text = "Ready"; 
              
            int N_LENGTH = Convert.ToInt16(txt_NLength.Text);
            //todo /*Duc*/

            //try
            //{
            //read file
            List<double> stream_data;
            stream_data = IOFuncs.readStreamFile(txt_data_to_calc_W.Text);
            stream_data = MathFuncs.zScoreNorm(stream_data, stream_data.Count);
            //get threshold:
            double threshold = Convert.ToDouble(txt_threshold.Text);


            /*todo*/
            int result = stream_data.Count;
            MinHeap<SegmentNode> segment_heap = null;
            BottomUp.Bottom_Up(stream_data, threshold, ref result, ref segment_heap);
            result = (int)(N_LENGTH / result);


            Segment_Form form2 = new Segment_Form(stream_data, segment_heap);
            //form2.Show();

            /*show the result:*/
            txt_WLength.Text = result.ToString();
            Console.WriteLine("W_LENGTH = " + result);
            //}
            //catch
            //{
            //    MessageBox.Show("re-check the parameters !", "Error", MessageBoxButtons.OK);
            //}

        }
        private void form_SAX_Load(object sender, EventArgs e)
        {
            string link = System.IO.Path.Combine(System.Environment.CurrentDirectory, @"Data\");
            string[] fileArray = System.IO.Directory.GetFiles(@link);

            /*combox_filename*/
            foreach (string file in fileArray)
                this.combox_filename.Items.Add(System.IO.Path.GetFileName(file));//get all data filenames in the directory
            string default_file = "ECG.txt";
            var match = fileArray.FirstOrDefault(stringToCheck => stringToCheck.Contains(default_file));
            if (match != null)
                combox_filename.Text = default_file;// set default value for the combox

            /*combox_algorithm*/
            string[] algorithms = { "BFHS", "HOTSAX_Stream", "HOTSAX_Squeezer_Stream", "Bounding_Box", "Sanchez_Method" };
            foreach (string algorithm in algorithms)
                this.combox_algorithm.Items.Add(algorithm);
            string default_algorithm = "HOTSAX_Squeezer_Stream";
            match = algorithms.FirstOrDefault(stringToCheck => stringToCheck.Contains(default_algorithm));
            if (match != null)
                combox_algorithm.Text = default_algorithm;// set default value for the combox


            //set default value for period_max:
            List<double> data_to_calc_w = IOFuncs.readStreamFile(txt_data_to_calc_W.Text);
            txt_period_max.Text = (data_to_calc_w.Count() / 10).ToString();


        }
        private void btn_Stream_Click(object sender, EventArgs e)
        {
            is_stream_clicked = true;
            //read file
            List<double> data_to_calc_w, stream_data;
            int buffer_len;

            data_to_calc_w = IOFuncs.readStreamFile(txt_data_to_calc_W.Text);
            //WriteFile.rewriteStreamFile(txt_stream_data.Text, 0, 100);
            stream_data = IOFuncs.readStreamFile(txt_stream_data.Text);

            //get N_LENGTH
            int N_LENGTH = Convert.ToInt16(txt_NLength.Text);

            int period = Convert.ToInt16(txt_period.Text);
            buffer_len = Convert.ToInt16(txt_bufferLength.Text) * period;


            // get W_LENGTH
            int W_LENGTH = Convert.ToInt16(txt_WLength.Text);

            // get Threshold Mean
            double threshold_mean = Convert.ToDouble(txt_threshold_mean.Text);

            // get Threshold Std
            double threshold_std = Convert.ToDouble(txt_threshold_std.Text);

            // get algorithm
            String algorithm = combox_algorithm.Text;

            // get Threshold Similarity
            double threshold_sim = Convert.ToDouble(txt_threshold_sim.Text);

            // get parameter for RTree
            int R = Convert.ToInt16(txtR.Text);
            int maxEntry = Convert.ToInt16(txtMaxEntry.Text);
            int minEntry = Convert.ToInt16(txtMinEntry.Text);

            // get file_name
            String file_name = combox_filename.Text;

            if (buffer_len > data_to_calc_w.Count)
            {
                MessageBox.Show("buffer must be smaller than data_to_calc_w !, please modify Buffer_length.");
                return;
            }


            //starting:
            Console.WriteLine("Running Stream HOTSAX...\n");

            List<double> result = new List<double>();
            //result[0]: dist
            //result[1]: loc

            //get the buffer:
            List<double> raw_buffer = data_to_calc_w.GetRange(data_to_calc_w.Count - buffer_len, buffer_len);

            //normalize buffer:
            List<double> norm_buffer = HOTSAX.HOTSAX.normalizeData(raw_buffer, buffer_len, N_LENGTH);

            if (algorithm == "Bounding_Box" || algorithm == "Sanchez_Method")
            {
                //SCALE:
                chart_timeSeries.ChartAreas[0].AxisY.Maximum = raw_buffer.Max() * SCALE;
                chart_timeSeries.ChartAreas[0].AxisY.Minimum = raw_buffer.Min() / SCALE;

                // turn the labels off:
                chart_timeSeries.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;//turn off X-axis labels
                chart_timeSeries.ChartAreas["ChartArea1"].AxisY.LabelStyle.Enabled = false;//turn off Y-axis labels
            }
            


            //updateChart(raw_buffer, (int)result[1], N_LENGTH);
            // create a new thread to run the chart:
            chart_thread = new Thread(() => this.doStream(file_name, algorithm, result, norm_buffer, data_to_calc_w, stream_data, N_LENGTH, W_LENGTH, raw_buffer, threshold_mean, threshold_std, threshold_sim, R, maxEntry, minEntry, period));
            chart_thread.IsBackground = true;
            chart_thread.Start();
        }
        private void combox_filename_SelectedIndexChanged(object sender, EventArgs e)
        {

            var data_name = System.IO.Path.GetFileNameWithoutExtension(combox_filename.Text);
            var extension = System.IO.Path.GetExtension(combox_filename.Text);
            txt_data_to_calc_W.Text = data_name + "_W" + extension;
            txt_stream_data.Text = data_name + "_Stream" + extension;

            //set default value for period_max:
            List<double> data_to_calc_w = IOFuncs.readStreamFile(txt_data_to_calc_W.Text);
            txt_period_max.Text = (data_to_calc_w.Count() / 10).ToString();
            switch (this.combox_filename.SelectedItem.ToString())
            {
                case "ECG.txt":
                    setValues("40", "4", "375", "0.001", "0.01", "0.95", "2", "25", "12");
                    break;
                case "TEK16.txt":
                    break;
            }
        }
        private void btn_stopStream_Click(object sender, EventArgs e)
        {
            if (!is_stream_clicked)
                return; //do nothing if the STREAM button wasnt clicked.
            if (is_pause)
            {
                manualResetEvent.Reset();
                this.btn_stopStream.Text = "Resume";
                Console.WriteLine("PAUSED...!");
            }
            else//resume
            {
                manualResetEvent.Set();
                this.btn_stopStream.Text = "Pause";
                Console.WriteLine("RESUMING...!");
            }

            is_pause = !is_pause; //change the variable from 'pause' state to 'resume' and vice versa
        }

        /*Fig. 11 ('Luo_2011' paper): Estimating period with the median gap between two neighboring local minima*/
        private void Luo_2011_Period()
        {
            //get max value for p, q:
            List<double> data_to_calc_w = IOFuncs.readStreamFile(txt_data_to_calc_W.Text);
            int data_len = data_to_calc_w.Count;
            int N_length = Convert.ToInt16(txt_NLength.Text);

            //normalize data:
            List<double> norm_data = MathFuncs.zScoreNorm(data_to_calc_w, data_len);

            //create a list to restore dists(p,q):
            List<double> dist_pq = new List<double>();

            //calc collection of gaps delta for local minima of dist(p,q), here:
            // p is picked randomly 
            // q =  0 to (bufer_len - N_length)

            //choose a random p:
            Random random_obj = new Random();
            int p = random_obj.Next(data_len - N_length + 1);

            //get segment p:
            List<double> p_segment = norm_data.GetRange(p, N_length);

            //go through all q(s), compute dist(p,q) for every q:
            for (int q = 0; q <= (data_len - N_length); q++)
            {
                dist_pq.Add(MathFuncs.EuDistance(p_segment, norm_data.GetRange(q, N_length)));
            }


            /* Find the lower K_LOWER_PERCENT quantile of all distances calculated in the previous step.*/
            int dist_pq_len = dist_pq.Count();
            // WriteFile.WriteFile_2(dist_pq);
            // WriteFile.WriteFile_2(norm_data, "norm_data.csv");

            int k_percent_index = (int)(dist_pq_len * K_LOWER_PERCENT);
            var sorted_dist_pq = dist_pq.OrderBy(n => n);


            //lower K_LOWER_PERCENT:
            double cp = sorted_dist_pq.ElementAt(k_percent_index);

            //get all local minima q such that dist(p, q) <= cp.
            List<int> Q = new List<int>();//store the result
            for (int q = 0; q < dist_pq_len; q++)
            {
                if (dist_pq[q] <= cp)
                {
                    Q.Add(q);
                }
            }

            //Order Q list from smallest to largest:
            Q.Sort();
            int Q_len = Q.Count;

            //calc lag 1 (delta):
            List<int> delta = new List<int>();
            for (int k = 0; k < Q_len - 1; k++)
            {
                if (Q[k + 1] - Q[k] > 2)
                    delta.Add(Q[k + 1] - Q[k]);
            }

            //sort delta:
            delta.Sort();
            int median_index = delta.Count / 2;
            int delta_median = delta[median_index];

            txt_period.Text = delta_median.ToString();
        }

        private void btnPeriod_Click(object sender, EventArgs e)
        {
            //calc acf function:

            acf_function();

            /*we have 2 other algorithms as well:*/
            //Luo_2011_Period();
            //phaseCoherenceFuntion();
        }

        private void acf_function()
        {
            List<double> data_to_calc_w = IOFuncs.readStreamFile(txt_data_to_calc_W.Text);
            int data_len = data_to_calc_w.Count;

            int period_max = Convert.ToInt16(txt_period_max.Text);

            //normalize data:
            List<double> norm_data = MathFuncs.zScoreNorm(data_to_calc_w, data_len);
            ACF_Form form3 = new ACF_Form(this, norm_data, 1, period_max);
            //txt_period.Text = period.ToString();
        }

        /*phase coherence analysis*/
        private void phaseCoherenceFuntion()
        {
            Console.WriteLine("Running phaseCohenrence...");

            System.Diagnostics.Stopwatch watch2; ;///calc execution time
            long elapsedMs2 = 0;

            watch2 = System.Diagnostics.Stopwatch.StartNew();///calc execution time

            List<double> std_list = new List<double>();//store std(s)
            List<double> norm_data = new List<double>();//data after normalizing all its subsets

            List<double> raw_data = IOFuncs.readStreamFile(txt_data_to_calc_W.Text);
            int data_len = raw_data.Count;

            int K_MAX = Convert.ToInt16(txt_period_max.Text);

            for (int k = 1; k <= K_MAX; k++)//do calc std for each value of 'k'
            {
                //reset variables:
                norm_data.Clear();

                double[] sum_subsets = new double[k];//store k sums
                double[] mean_subsets = new double[k];//store k means

                int len_average_subset = data_len / k;
                int remainder_len_subset = data_len % k;

                /*calc mean for each subsets:*/
                //find the sum(s):
                for (int j = 0; j < data_len; j++)
                {
                    sum_subsets[j % k] += raw_data[j];
                }
                //calc mean(s):
                for (int i = 0; i < k; i++)
                {
                    if (i < remainder_len_subset)
                        mean_subsets[i] = sum_subsets[i] / (len_average_subset + 1);
                    else
                        mean_subsets[i] = sum_subsets[i] / len_average_subset;
                }


                for (int i = 0; i < data_len; i++)
                {
                    norm_data.Add(raw_data[i] - mean_subsets[i % k]);
                }

                //calc  std then append it to std_list
                std_list.Add(MathFuncs.CalcStdMeanZero(norm_data));

            }//end for


            double min = std_list.Min();
            int period = std_list.FindIndex(n => Math.Abs(n - min) < 0.0000001);
            watch2.Stop();
            elapsedMs2 = watch2.ElapsedMilliseconds;

            //print file to check:
            IOFuncs.WriteFile_2(std_list, "std_list.csv");

            txt_period.Text = period.ToString();
            Console.WriteLine("DONE CALC PERIOD_ REF 7, time = " + elapsedMs2 + "; period = " + period);
        }

        public void setPeriod(int period)
        {
            if (!txt_period.IsDisposed)
                txt_period.Invoke(new Action(() => txt_period.Text = period.ToString()));
        }

        private void btn_statistic_Click(object sender, EventArgs e)
        {
            string file_name = combox_filename.Text;
            string algorithm = combox_algorithm.Text;
            List<double> dist = null, loc = null;
            double time = 0;
            IOFuncs.readStatisticalFile(file_name, algorithm, ref dist, ref loc, ref time);
            Statistical_Form new_form = new Statistical_Form(loc, dist, time);
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_period_TextChanged(object sender, EventArgs e)
        {
            int length = (Convert.ToInt16(txt_bufferLength.Text) * Convert.ToInt16(txt_period.Text));
            txt_buffer_length.Text = length.ToString();
        }

        private void txt_bufferLength_TextChanged(object sender, EventArgs e)
        {
            int length = (Convert.ToInt16(txt_bufferLength.Text) * Convert.ToInt16(txt_period.Text));
            txt_buffer_length.Text = length.ToString();
        }

        private void setValues(string txt_N_LENGTH, string txt_WLength, string period, string txt_threshold_mean, string txt_threshold_std, string txt_threshold_sim, string R, string maxEntry, string minEntry)
        {
            this.txt_period.Text = period;
            this.txt_WLength.Text = txt_WLength;
            this.txt_NLength.Text = txt_N_LENGTH;
            this.txtR.Text = R;
            this.txtMaxEntry.Text = maxEntry;
            this.txtMinEntry.Text = minEntry;
            this.txt_threshold_mean.Text = txt_threshold_mean;
            this.txt_threshold_std.Text = txt_threshold_std;
            this.txt_threshold_sim.Text = txt_threshold_sim;
        }
    }
}
