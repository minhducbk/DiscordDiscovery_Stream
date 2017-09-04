using DiscordDiscovery.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordDiscovery.HOTSAX
{
    static class HOTSAX
    {

        static private Random random_obj = new Random();// helping for making a random order

        // Make the tree and tables function
        static public List<double> normalizeData(List<double> raw_data, int data_len, int N_LENGTH)
        {
            List<double> norm_data;
            norm_data = MathFuncs.zScoreNorm(raw_data, raw_data.Count);
            return norm_data;
        }

        static public void MakeTree_And_Table_2(List<double> norm_data, int N_LENGTH, int W_LENGTH, ref AugmentedTrie tree, ref Dictionary<string, int> count_table, ref Dictionary<int, string> total_table)
        {

            List<double> c_w = new List<double>();//  w dimension
            int index = -1;
            if (N_LENGTH % W_LENGTH != 0)
            {

                for (int i = 0; i < norm_data.Count - N_LENGTH + 1; i++)
                {
                    List<double> c_n = norm_data.GetRange(i, N_LENGTH);
                    index++;
                    c_w.Clear();// reset C_w
                    string s = String.Empty;//initialize the SAX word

                    for (int j = 0; j < W_LENGTH; j++)
                        c_w.Add(0);//set initial value for C_w

                    for (int j = 0; j < N_LENGTH * W_LENGTH; j++)
                    {
                        c_w[j / N_LENGTH] += c_n[j / W_LENGTH];
                    }



                    //SAX word:
                    for (int j = 0; j < W_LENGTH; j++)
                    {
                        c_w[j] /= N_LENGTH;
                        //Convert c_i to SAX
                        if (c_w[j] <= Constants.GAUSS_1)
                        {
                            s += "a";
                        }
                        else if (c_w[j] >= Constants.GAUSS_2)
                        {
                            s += "c";
                        }
                        else
                        {
                            s += "b";
                        }
                    }

                    total_table.Add(index, s);

                    if (count_table.ContainsKey(s))
                    {
                        count_table[s]++;//if it did have, just plus 1 to 'count_table'
                    }
                    else
                    {
                        count_table.Add(s, 1);// else, we'll make a new one
                    }
                }//end foreach
            }//end IF
            else
            {
                double c_i;
                int from_index, to_index;
                for (int i = 0; i < norm_data.Count - N_LENGTH + 1; i++)
                {
                    List<double> c_n = norm_data.GetRange(i, N_LENGTH);
                    index++;
                    c_w.Clear();// reset C_w
                    string s = String.Empty;//initialize the SAX word


                    //Calculate C_w 
                    for (int w_start = 0; w_start < W_LENGTH; w_start++)
                    {
                        from_index = (N_LENGTH / W_LENGTH) * w_start;
                        to_index = (N_LENGTH / W_LENGTH) * (w_start + 1) - 1;

                        c_i = 0;
                        for (int j = from_index; j <= to_index; j++)
                        {
                            c_i += c_n[j];
                        }
                        c_i = c_i * (W_LENGTH / (double)(N_LENGTH));


                        //Convert c_i to SAX
                        if (c_i <= Constants.GAUSS_1)
                        {
                            s += "a";
                        }
                        else if (c_i >= Constants.GAUSS_2)
                        {
                            s += "c";
                        }
                        else
                        {
                            s += "b";
                        }
                    }

                    total_table.Add(index, s);

                    if (count_table.ContainsKey(s))
                    {
                        count_table[s]++;//if it did have, just plus 1 to 'count_table'
                    }
                    else
                    {
                        count_table.Add(s, 1);// else, we'll make a new one
                    }
                }
            }//end ELSE


            tree.CreateTheAugmentedTrie(W_LENGTH);

            // appending the indice to the tree.
            foreach (KeyValuePair<int, string> pair in total_table)
            {
                tree.AddTheDataToLeaf(pair.Value, pair.Key);
            }

        } //end function

        //Shuffle function for List<int>
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

        // outer loop
        private static List<int> OuterArrangement(int index, Dictionary<int, string> total_table, Dictionary<string, int> count_table)
        {
            List<int> outter_list = new List<int>();
            List<int> outer_random = new List<int>();

            foreach (KeyValuePair<int, string> pair in total_table)
            {
                if (count_table[pair.Value] == 1)
                    outter_list.Add(pair.Key - index);
                else
                    outer_random.Add(pair.Key - index);
            }

            //make outer_random randomly
            outer_random.Shuffle();

            outter_list = outter_list.Concat(outer_random).ToList();
            return outter_list;
        }//end OuterArrangement

        // inner loop
        private static List<int> InnerArrangement(int index, int data_len, Dictionary<string, int> count_table, AugmentedTrie tree, string word)
        {
            TreeNode the_leaf = tree.FindtheLeaf(word);
            List<int> inner_list = new List<int>(the_leaf.GetDataNode());//go through the data first

            bool[] over_arr = new bool[data_len];
            for (int i = 0; i < data_len; i++)
                over_arr[i] = false;

            foreach (int element in inner_list)
            {
                over_arr[element - index] = true;
            }

            List<int> inner_random = new List<int>();
            List<int> inner_first = new List<int>();
            for (int i = 0; i < data_len; i++)
            {
                if (over_arr[i] == false)
                    inner_random.Add(i);
                else
                    inner_first.Add(i);


            }

            //make random_inner randomly
            inner_random.Shuffle();

            inner_list = inner_first.Concat(inner_random).ToList();

            return inner_list;
        }//end innerArrangement

        public static string convertSegmentToWord(List<double> c_n, int N_LENGTH, int W_LENGTH)
        {
            List<double> c_w = new List<double>();
            string s = String.Empty;

            for (int j = 0; j < W_LENGTH; j++)
                c_w.Add(0);//set initial value for C_w

            for (int j = 0; j < N_LENGTH * W_LENGTH; j++)
            {
                c_w[j / N_LENGTH] += c_n[j / W_LENGTH];
            }

            //SAX word:
            for (int j = 0; j < W_LENGTH; j++)
            {
                c_w[j] /= N_LENGTH;
                //Convert c_i to SAX
                if (c_w[j] <= Constants.GAUSS_1)
                {
                    s += "a";
                }
                else if (c_w[j] >= Constants.GAUSS_2)
                {
                    s += "c";
                }
                else
                {
                    s += "b";
                }
            }

            return s;
        }

        public static List<double> originalHOTSAX(int index, List<double> norm_data, int N_LENGTH, int W_LENGTH,
           ref AugmentedTrie tree, ref Dictionary<string, int> count_table, ref Dictionary<int, string> total_table, bool is_first_run = false)
        {

            if (is_first_run)//make Tree and Tables for the first time running HOTSAX
                MakeTree_And_Table_2(norm_data, N_LENGTH, W_LENGTH, ref tree, ref count_table, ref total_table);
            else//update tree and tables
            {
                string old_segment_word, new_segment_word;
                //old_segment_word: store the first segment at time t to SAX word.
                //new_segment_word: store the new segment at time t+1 to SAX word.
                List<double> new_segment = norm_data.GetRange(norm_data.Count - N_LENGTH, N_LENGTH);

                old_segment_word = total_table[index - 1];
                new_segment_word = convertSegmentToWord(new_segment, N_LENGTH, W_LENGTH);

                //update Tree, and Tables:
                // first, we  update 'count_table':
                if (count_table.ContainsKey(old_segment_word))
                {
                    count_table[old_segment_word]--;

                }
                if (count_table.ContainsKey(new_segment_word))
                {
                    count_table[new_segment_word]++;
                }
                else
                {
                    count_table.Add(new_segment_word, 1);
                }

                //update 'total_table':
                int len_total_table = norm_data.Count;
                total_table.Remove(index - 1);
                total_table.Add(index + len_total_table - N_LENGTH, new_segment_word);

                //update 'Tree':
                TreeNode old_seg_leaf = tree.FindtheLeaf(old_segment_word);
                TreeNode new_seg_leaf = tree.FindtheLeaf(new_segment_word);
                old_seg_leaf.GetDataNode().Remove(index - 1);
                new_seg_leaf.GetDataNode().Add(index + len_total_table - N_LENGTH);
            }//end update

            double best_so_far_dist = 0;
            int best_so_far_loc = 0;

            double nearest_neighbor_dist = 0;
            double dist = 0;

            List<int> outer_list, inner_list;

            outer_list = OuterArrangement(index, total_table, count_table);
            bool break_to_outer_loop = false;

            bool[] is_skip_at_p = new bool[norm_data.Count];
            for (int i = 0; i < norm_data.Count; i++)
                is_skip_at_p[i] = false;

            foreach (int p in outer_list)
            {
                if (is_skip_at_p[p])
                {
                    //p was visited at inner loop before
                    continue;
                }
                else
                {
                    nearest_neighbor_dist = Constants.INFINITE;
                    string word = total_table[p + index];

                    inner_list = InnerArrangement(index, total_table.Count, count_table, tree, word);

                    foreach (int q in inner_list)// inner loop
                    {
                        if (Math.Abs(p - q) < N_LENGTH)
                        {
                            continue;// self-match => skip to the next one
                        }
                        else
                        {
                            //calculate the Distance between p and q
                            dist = MathFuncs.EuDistance(norm_data.GetRange(p, N_LENGTH), norm_data.GetRange(q, N_LENGTH));

                            if (dist < best_so_far_dist)
                            {
                                //skip the element q at oute_loop, 'cuz if (p,q) is not a solution, so does (q,p).
                                is_skip_at_p[q] = true;

                                break_to_outer_loop = true; //break, to the next loop at outer_loop
                                break;// break at inner_loop first
                            }

                            if (dist < nearest_neighbor_dist)
                            {
                                nearest_neighbor_dist = dist;
                            }
                        }
                    }//end inner
                    if (break_to_outer_loop)
                    {
                        break_to_outer_loop = false;//reset
                        continue;//go to the next p in outer loop
                    }

                    if (nearest_neighbor_dist > best_so_far_dist)
                    {
                        best_so_far_dist = nearest_neighbor_dist;
                        best_so_far_loc = p;
                    }
                }//end else


            }//end outter

            List<double> result = new List<double> { best_so_far_dist, best_so_far_loc };
            //Console.WriteLine("skip = " + number_skip);

            return result;
        }// end

        public static List<double> candidateHOTSAX(List<int> candidate_list, int index, List<double> norm_data, int N_LENGTH, int W_LENGTH, ref AugmentedTrie tree, ref Dictionary<string, int> count_table, ref Dictionary<int, string> total_table)
        {
            string old_segment_word, new_segment_word;
            //old_segment_word: store the first segment at time t to SAX word.
            //new_segment_word: store the new segment at time t+1 to SAX word.

            List<double> new_segment = norm_data.GetRange(norm_data.Count - N_LENGTH, N_LENGTH);

            old_segment_word = total_table[index - 1];
            new_segment_word = convertSegmentToWord(new_segment, N_LENGTH, W_LENGTH);

            //update Tree, and Tables:
            // first, we  update 'count_table':

            if (count_table.ContainsKey(old_segment_word))
            {
                count_table[old_segment_word]--;
            }
            if (count_table.ContainsKey(new_segment_word))
            {
                count_table[new_segment_word]++;
            }
            else
            {
                count_table.Add(new_segment_word, 1);
            }

            //update 'total_table':
            int len_total_table = norm_data.Count;
            total_table.Remove(index - 1);
            total_table.Add(index + len_total_table - N_LENGTH, new_segment_word);

            //update 'Tree':
            TreeNode old_seg_leaf = tree.FindtheLeaf(old_segment_word);
            TreeNode new_seg_leaf = tree.FindtheLeaf(new_segment_word);
            old_seg_leaf.GetDataNode().Remove(index - 1);
            new_seg_leaf.GetDataNode().Add(index + len_total_table - N_LENGTH);
            //end update

            double best_so_far_dist = 0;
            int best_so_far_loc = 0;

            double nearest_neighbor_dist = 0;
            double dist = 0;

            List<int> outer_list, inner_list;

            outer_list = candidate_list;//OuterArrangement(index, total_table, count_table);
            bool break_to_outer_loop = false;

            bool[] is_skip_at_p = new bool[norm_data.Count];
            for (int i = 0; i < norm_data.Count; i++)
                is_skip_at_p[i] = false;

            foreach (int p in outer_list)
            {
                if (is_skip_at_p[p])
                {
                    //p was visited at inner loop before
                    continue;
                }
                else
                {
                    nearest_neighbor_dist = Constants.INFINITE;
                    string word = total_table[p + index];

                    inner_list = InnerArrangement(index, total_table.Count, count_table, tree, word);

                    foreach (int q in inner_list)// inner loop
                    {
                        if (Math.Abs(p - q) < N_LENGTH)
                        {
                            continue;// self-match => skip to the next one
                        }
                        else
                        {
                            //calculate the Distance between p and q
                            dist = MathFuncs.EuDistance(norm_data.GetRange(p, N_LENGTH), norm_data.GetRange(q, N_LENGTH));

                            if (dist < best_so_far_dist)
                            {
                                //skip the element q at oute_loop, 'cuz if (p,q) is not a solution, so does (q,p).
                                is_skip_at_p[q] = true;

                                break_to_outer_loop = true; //break, to the next loop at outer_loop
                                break;// break at inner_loop first
                            }

                            if (dist < nearest_neighbor_dist)
                            {
                                nearest_neighbor_dist = dist;
                            }
                        }
                    }//end inner
                    if (break_to_outer_loop)
                    {
                        break_to_outer_loop = false;//reset
                        continue;//go to the next p in outer loop
                    }

                    if (nearest_neighbor_dist > best_so_far_dist)
                    {
                        best_so_far_dist = nearest_neighbor_dist;
                        best_so_far_loc = p;
                    }
                }//end else


            }//end outter

            List<double> result = new List<double> { best_so_far_dist, best_so_far_loc };
            //Console.WriteLine("skip = " + number_skip);

            return result;
        }
    }
}
