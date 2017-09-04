using DiscordDiscovery.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitseriesType = System.Collections.Generic.List<int>;//user defined type 
using RawDataType = System.Collections.Generic.List<double>;//user defined type for the raw data

namespace DiscordDiscovery.Squeezer
{
    static class BitClusterDiscord
    {
        private const double INFINITE = 99999;
        public const int PAA = 3;
        public const int PLA = 2;
        public const int BIT_SERIES = 1;

        static private Random random_obj = new Random();// helping for making a random order

        //static private void Shuffle_Generic<T>(this IList<T> list)
        //{
        //    int n = list.Count;
        //    while (n > 1)
        //    {
        //        n--;
        //        int k = random_obj.Next(n + 1);
        //        T value = list[k];
        //        list[k] = list[n];
        //        list[n] = value;
        //    }
        //}//end Shuffle function

        private static void Shuffle2(this List<int> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random_obj.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }//end Shuffle function

        static public List<int> getOuterLoop(List<Cluster_Squeezer> b_cluster, int K_CLUSTERS, int index_table = 0)
        {
            List<Cluster_Squeezer> ordered_bCluster = b_cluster.OrderBy(obj => obj.getCluster().getNumberOfMembers()).ToList();

            List<int> outer_loop = new List<int>();

            //outer_loop.AddRange(ordered_bCluster[0].getCluster().getListMemberIndice());
            //outer_loop.Shuffle2();

            for (int i = 0; i < K_CLUSTERS; i++)
            {
                outer_loop.AddRange(ordered_bCluster[i].getCluster().getListMemberIndice().Select(index => index - index_table));
            }
            return outer_loop;
        }

        //note: 'cluster_of_cur_outer' is a value of the cluster containing current outer element. 
        //( 'cluster_of_cur_outer'runs from 0 to (K_CLUSTERS-1) );
        static List<int> getInnerLoop(List<Cluster_Squeezer> b_cluster, int K_CLUSTERS, int cluster_of_cur_outer, int index_table = 0)
        {
            List<int> inner_loop = new List<int>();

            //append the same cluster first
            inner_loop.AddRange(b_cluster[cluster_of_cur_outer].getCluster().getListMemberIndice().Select(index => index - index_table));
            inner_loop.Shuffle2();

            for (int cluster_remainder = 0; cluster_remainder < K_CLUSTERS; cluster_remainder++)
            {
                if (cluster_remainder != cluster_of_cur_outer)
                    inner_loop.AddRange(b_cluster[cluster_remainder].getCluster().getListMemberIndice().Select(index => index - index_table));
            }

            return inner_loop;
        }


        static double distanceBetween2Clusters(RawDataType p_center, RawDataType q_center, double radius_p, double radius_q)
        {
            double dist = Math.Sqrt(p_center.Zip(q_center, (a, b) => (a - b) * (a - b)).Sum()) - radius_p - radius_q;
            return dist;

        }

        static public List<double> squeezer(ref List<int> lCluster_NonMember, ref List<int> cluster_belong, ref List<Cluster_Squeezer> b_cluster, List<double> data, int N_LENGTH, int W_LENGTH, double threshold, int type_convert_raw_data, int index_table = 0, bool first_time = true)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();///calc execution time
            //call the function
            if (first_time)
                BitCluster.squeezerCluster(data, type_convert_raw_data, ref b_cluster, ref cluster_belong, threshold, N_LENGTH, W_LENGTH, index_table);
            else
                BitCluster.squeezerClusterAgain(ref lCluster_NonMember, index_table, data, type_convert_raw_data, ref b_cluster, ref cluster_belong, threshold, N_LENGTH, W_LENGTH);
            lCluster_NonMember = new List<int>();
            watch.Stop();//stop timer
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine("________squeezerCluster is Done in " + elapsedMs + ".\nKeep going...Please wait");



            // get Outer loop:
            List<int> outer_loop = getOuterLoop(b_cluster, b_cluster.Count, index_table); //get outer

            List<int> inner_loop;
            bool continue_to_outer_loop = false;

            double nearest_neighbor_dist = 0;
            double dist = 0;

            double best_so_far_dist = 0;
            int best_so_far_loc = 0;

            List<double> p_center, q_center;

            bool[] is_skip_at_p = new bool[outer_loop.Count];
            for (int i = 0; i < outer_loop.Count; i++)
                is_skip_at_p[i] = false;

            int cluster_of_cur_outer;//thang p dang nam o cluster nao
            int cluster_of_cur_inner;// tracking for q's cluster at inner loop

            //test
            int count_skip_at_p = 0;
            int count_break_sub_2_dis = 0;
            int count_dis_smaller_best_so_far = 0;
            int count_center_p_diff_center_q = 0;

            foreach (int p in outer_loop)
            {

                if (is_skip_at_p[p])
                {
                    count_skip_at_p++;
                    //p was visited at inner loop before
                    continue;
                }
                else
                {
                    nearest_neighbor_dist = INFINITE;

                    cluster_of_cur_outer = cluster_belong[p];

                    inner_loop = getInnerLoop(b_cluster, b_cluster.Count, cluster_of_cur_outer, index_table);

                    foreach (int q in inner_loop)// inner loop
                    {
                        if (Math.Abs(p - q) < N_LENGTH)
                        {
                            continue;// self-match => skip to the next one
                        }
                        else
                        {

                            //calculate the Distance between p and q
                            dist = OtherFuncs.gaussDistance(data.GetRange(p, N_LENGTH), data.GetRange(q, N_LENGTH));

                            if (dist < best_so_far_dist)
                            {
                                //skip the element q at oute_loop, 'cuz if (p,q) is not a solution, so does (q,p).
                                is_skip_at_p[q] = true;
                                count_dis_smaller_best_so_far++;

                                continue_to_outer_loop = true; //break, to the next loop at outer_loop
                                break;// break at inner_loop first
                            }

                            if (dist < nearest_neighbor_dist)
                            {
                                nearest_neighbor_dist = dist;
                            }
                        }//end else
                    }//end inner
                    if (continue_to_outer_loop)
                    {
                        continue_to_outer_loop = false;//reset
                        continue;//go to the next p in outer loop
                    }

                    if (nearest_neighbor_dist > best_so_far_dist)
                    {
                        best_so_far_dist = nearest_neighbor_dist;
                        best_so_far_loc = p;
                    }
                }//end else


            }//end outter

            Console.WriteLine("count_skip_at_p =" + count_skip_at_p);
            Console.WriteLine("=======count_break_sub_2_dis =" + count_break_sub_2_dis);
            Console.WriteLine("count_dis_smaller_best_so_far =" + count_dis_smaller_best_so_far);
            Console.WriteLine("count_center_p_diff_center_q=" + count_center_p_diff_center_q);


            return new List<double> { best_so_far_dist, best_so_far_loc };
        }//end bitClusterDiscord_Enhancement()

        static public List<double> squeezerAgain(ref List<int> lCluster_NonMember, List<int> candidate_list, int index_table, ref List<int> cluster_belong, ref List<Cluster_Squeezer> b_cluster, List<double> data, int N_LENGTH, int W_LENGTH, double threshold, int type_convert_raw_data)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();///calc execution time
            //call the function
            BitCluster.squeezerClusterAgain(ref lCluster_NonMember, index_table, data, type_convert_raw_data, ref b_cluster, ref cluster_belong, threshold, N_LENGTH, W_LENGTH);
            watch.Stop();//stop timer
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine("________squeezerCluster is Done in " + elapsedMs + ".\nKeep going...Please wait");



            // get Outer loop:
            List<int> outer_loop = candidate_list;//getOuterLoop(b_cluster, b_cluster.Count, index_table); //get outer

            List<int> inner_loop;
            bool continue_to_outer_loop = false;

            double nearest_neighbor_dist = 0;
            double dist = 0;

            double best_so_far_dist = 0;
            int best_so_far_loc = 0;


            bool[] is_skip_at_p = new bool[data.Count];
            for (int i = 0; i < data.Count; i++)
                is_skip_at_p[i] = false;

            int cluster_of_cur_outer;//thang p dang nam o cluster nao

            //test
            int count_skip_at_p = 0;
            int count_break_sub_2_dis = 0;
            int count_dis_smaller_best_so_far = 0;
            int count_center_p_diff_center_q = 0;

            foreach (int p in outer_loop)
            {

                if (is_skip_at_p[p])
                {
                    count_skip_at_p++;
                    //p was visited at inner loop before
                    continue;
                }
                else
                {
                    nearest_neighbor_dist = INFINITE;

                    cluster_of_cur_outer = cluster_belong[p];

                    inner_loop = getInnerLoop(b_cluster, b_cluster.Count, cluster_of_cur_outer, index_table);

                    foreach (int q in inner_loop)// inner loop
                    {
                        if (Math.Abs(p - q) < N_LENGTH)
                        {
                            continue;// self-match => skip to the next one
                        }
                        else
                        {

                            //calculate the Distance between p and q
                            dist = OtherFuncs.gaussDistance(data.GetRange(p, N_LENGTH), data.GetRange(q, N_LENGTH));

                            if (dist < best_so_far_dist)
                            {
                                //skip the element q at oute_loop, 'cuz if (p,q) is not a solution, so does (q,p).
                                is_skip_at_p[q] = true;
                                count_dis_smaller_best_so_far++;

                                continue_to_outer_loop = true; //break, to the next loop at outer_loop
                                break;// break at inner_loop first
                            }

                            if (dist < nearest_neighbor_dist)
                            {
                                nearest_neighbor_dist = dist;
                            }
                        }//end else
                    }//end inner
                    if (continue_to_outer_loop)
                    {
                        continue_to_outer_loop = false;//reset
                        continue;//go to the next p in outer loop
                    }

                    if (nearest_neighbor_dist > best_so_far_dist)
                    {
                        best_so_far_dist = nearest_neighbor_dist;
                        best_so_far_loc = p;
                    }
                }//end else


            }//end outter

            Console.WriteLine("count_skip_at_p =" + count_skip_at_p);
            Console.WriteLine("=======count_break_sub_2_dis =" + count_break_sub_2_dis);
            Console.WriteLine("count_dis_smaller_best_so_far =" + count_dis_smaller_best_so_far);
            Console.WriteLine("count_center_p_diff_center_q=" + count_center_p_diff_center_q);


            return new List<double> { best_so_far_dist, best_so_far_loc };
        }//end bitClusterDiscord_Enhancement()
    }
}
