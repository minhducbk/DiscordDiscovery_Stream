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
    static class BitCluster
    {
        static private Random random_obj = new Random();// helping for making a random order
        private static void Shuffle(this List<int> list)
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

        static public double support(Cluster_Squeezer cluster_Squeezer, int element, int pos)
        {
            List<Dictionary<int, int>> count_elements = cluster_Squeezer.getCountElements();

            if (!((count_elements[pos]).ContainsKey(element)))
                return 0;
            else
                return (double)((count_elements[pos])[element]) / cluster_Squeezer.getCluster().getNumberOfMembers();

        }


        static public double simComputation(Cluster_Squeezer cluster, BitseriesType bit_data)
        {
            int bit_len = bit_data.Count;
            double sim = 0;

            for (int i = 0; i < bit_len; i++)
            {
                sim += support(cluster, bit_data[i], i);
            }
            return (sim / bit_len);
        }


        static public void squeezerCluster(RawDataType data, int type_convert_raw_data, ref List<Cluster_Squeezer> b_cluster, ref List<int> cluster_belong, double threshold, int N_LENGTH, int W_LENGTH, int index_table = 0)
        {
            //store Bit series data
            Dictionary<int, BitseriesType> bit_series_data;

            if (type_convert_raw_data == BitClusterDiscord.BIT_SERIES)
            {
                //get bit series data from original data
                bit_series_data = OtherFuncs.bitSeriesDataset(data, N_LENGTH, W_LENGTH);
            }
            else
            {
                if (type_convert_raw_data == BitClusterDiscord.PLA)
                {
                    bit_series_data = OtherFuncs.PLA(data, N_LENGTH, W_LENGTH);
                }

                else
                {
                    bit_series_data = OtherFuncs.PAA(data, N_LENGTH, W_LENGTH);
                }


            }


            //set some variables:
            int bit_series_data_length = bit_series_data.Count;

            b_cluster = new List<Cluster_Squeezer>();//store clusters
            cluster_belong = new List<int>(); //store the Cluster_Squeezer whose each point belong to

            //set initial values for cluster_belong: '-1'  here imply they dont lie in any clusters
            for (int i = 0; i < bit_series_data_length; i++)
            {
                cluster_belong.Add(-1);
            }


            //initialize the first data as a center point
            b_cluster.Add(new Cluster_Squeezer(new Cluster(1), new List<Dictionary<int, int>>()));// or 0 ??
            b_cluster[0].getCluster().addToListMemberIndice(index_table);
            b_cluster[0].updateCountElements(bit_series_data[0]);
            cluster_belong[0] = 0;


            double sim_max = 0;
            double sim_value = 0;
            int cluster_index = 0;//the Cluster_Squeezer whose point j belong to.

            for (int j = 1; j < bit_series_data_length; j++)//go through the BD data,  except the first one
            {

                sim_max = 0;
                cluster_index = 0;
                //for each existed Cluster_Squeezer C
                for (int i = 0; i < b_cluster.Count; i++)
                {
                    sim_value = simComputation(b_cluster[i], bit_series_data[j]);
                    if (sim_max < sim_value)
                    {
                        cluster_index = i;
                        sim_max = sim_value;
                    }

                }


                if (sim_max >= threshold)
                {
                    cluster_belong[j] = cluster_index;
                    b_cluster[cluster_index].getCluster().plusOneToNumberOfMembers();
                    b_cluster[cluster_index].getCluster().addToListMemberIndice(j + index_table);
                    b_cluster[cluster_index].updateCountElements(bit_series_data[j]);
                }
                else
                {

                    //make a new Cluster_Squeezer then add it to b_cluster
                    b_cluster.Add(new Cluster_Squeezer(new Cluster(1), new List<Dictionary<int, int>>()));
                    cluster_belong[j] = b_cluster.Count - 1;
                    b_cluster[b_cluster.Count - 1].getCluster().addToListMemberIndice(j + index_table);
                    b_cluster[b_cluster.Count - 1].updateCountElements(bit_series_data[j]);

                }

            }//end of for

            Console.WriteLine("The number of clusters is " + b_cluster.Count);

            foreach (Cluster_Squeezer list_members in b_cluster)
            {
                list_members.getCluster().getListMemberIndice().Shuffle();
            }

            Console.WriteLine("End shuffle.");

            //double radius;
            //List<double> center_value;
            //for (int i = 0; i < b_cluster.Count; i++)
            //{
            //    center_value = data.GetRange(b_cluster[i].getCluster().getCenterIndex(), N_LENGTH);
            //    radius = HelperFunctions.calculateRadius(data, b_cluster[i].getCluster().getListMemberIndice(), center_value, N_LENGTH);
            //    b_cluster[i].getCluster().setRadius(radius);
            //}




        }//end squeezerCluster() function

        static public void squeezerClusterAgain(ref List<int> lCluster_NonMember, int index_table, RawDataType data, int type_convert_raw_data, ref List<Cluster_Squeezer> b_cluster, ref List<int> cluster_belong, double threshold, int N_LENGTH, int W_LENGTH)
        {
            // Get old_bit_series and remove it from data
            Dictionary<int, BitseriesType> old_bit_series_data;
            old_bit_series_data = OtherFuncs.PAA(data.GetRange(0, N_LENGTH), N_LENGTH, W_LENGTH);
            data.RemoveAt(0);


            //store Bit series data
            Dictionary<int, BitseriesType> bit_series_data;


            if (type_convert_raw_data == BitClusterDiscord.BIT_SERIES)
            {
                //get bit series data from original data
                bit_series_data = OtherFuncs.bitSeriesDataset(data, N_LENGTH, W_LENGTH);
            }
            else
            {
                if (type_convert_raw_data == BitClusterDiscord.PLA)
                {
                    bit_series_data = OtherFuncs.PLA(data, N_LENGTH, W_LENGTH);
                }

                else
                {
                    bit_series_data = OtherFuncs.PAA(data, N_LENGTH, W_LENGTH);
                }


            }



            // Update b_cluster and cluster_belong
            // *Remove old_bit_series
            if (b_cluster[cluster_belong[0]].getCluster().getNumberOfMembers() == 1)
            {
                lCluster_NonMember.Add(cluster_belong[0]);
                Console.WriteLine("lCluster_NonMember has new member!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            b_cluster[cluster_belong[0]].getCluster().removeToListMemberIndice(index_table - 1);
            b_cluster[cluster_belong[0]].getCluster().extractOneToNumberOfMembers();
            b_cluster[cluster_belong[0]].decreaseCountElements(old_bit_series_data[0]);
            cluster_belong.RemoveAt(0);

            //set some variables:
            int bit_series_data_length = bit_series_data.Count;

            // *Add new_bit_series
            cluster_belong.Add(-1);
            int cluster_index = 0;//the Cluster_Squeezer whose point j belong to.
            double sim_max = 0;
            double sim_value = 0;

            sim_max = 0;
            cluster_index = 0;
            //for each existed Cluster_Squeezer C
            for (int i = 0; i < b_cluster.Count; i++)
            {
                if (lCluster_NonMember.FindIndex(x => x == i) < 0)
                {
                    sim_value = simComputation(b_cluster[i], bit_series_data[bit_series_data_length - 1]);
                    if (sim_max < sim_value)
                    {
                        cluster_index = i;
                        sim_max = sim_value;
                    }
                }
            }

            if (sim_max >= threshold)
            {
                cluster_belong[bit_series_data_length - 1] = cluster_index;
                b_cluster[cluster_index].getCluster().plusOneToNumberOfMembers();
                b_cluster[cluster_index].getCluster().addToListMemberIndice(bit_series_data_length + index_table - 1); // error?
                b_cluster[cluster_index].updateCountElements(bit_series_data[bit_series_data_length - 1]);
            }
            else
            {
                int new_cluster_index;
                if (lCluster_NonMember.Count == 0)
                {
                    //make a new Cluster_Squeezer then add it to b_cluster
                    b_cluster.Add(new Cluster_Squeezer(new Cluster(1), new List<Dictionary<int, int>>()));
                    new_cluster_index = b_cluster.Count - 1;
                }
                else
                {
                    new_cluster_index = lCluster_NonMember[0];
                    lCluster_NonMember.RemoveAt(0);
                }
                cluster_belong[bit_series_data_length - 1] = new_cluster_index;
                b_cluster[new_cluster_index].getCluster().addToListMemberIndice(bit_series_data_length + index_table - 1);
                b_cluster[new_cluster_index].updateCountElements(bit_series_data[bit_series_data_length - 1]);

            }
            for (int i = 0; i < cluster_belong.Count; i++)
                if (cluster_belong[i] < 0)
                    Console.WriteLine("Cluster belong has -1");
            Console.WriteLine("The number of clusters is " + b_cluster.Count);

            foreach (Cluster_Squeezer list_members in b_cluster)
            {
                list_members.getCluster().getListMemberIndice().Shuffle();
            }

            Console.WriteLine("End shuffle.");

        }
    }
}
