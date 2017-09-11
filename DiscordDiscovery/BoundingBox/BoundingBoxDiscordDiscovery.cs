using DiscordDiscovery.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordDiscovery.BoundingBox
{
    class BoundingBoxDiscordDiscovery
    {

        ////////////// Main Functions //////////////

        /*Run new offline (minDist) */
        public static List<double> RunOfflineMinDist(List<double> inputData, int NLength, int maxEntry, int minEntry, int R, int D, ref int this_id_item, ref List<int> this_id_itemList, ref List<Rectangle> this_rectList, ref RTree<int> this_RTree, bool is_first_time)
        {

            int id_item = int.MinValue;
            RTree<int> rtree = new RTree<int>(maxEntry, minEntry);

            List<int> candidateList = new List<int>();
            List<int> beginIndexInner = new List<int>();
            List<int> indexOfLeafMBRS = new List<int>();

            double best_so_far_dist = 0;
            int best_so_far_loc = -1;

            double nearest_neighbor_dist = 0;
            double dist = 0;
            bool break_to_outer_loop = false;

            bool[] is_skipped_at_p = new bool[inputData.Count];
            for (int i = 0; i < inputData.Count; i++)
                is_skipped_at_p[i] = false;

            if (minEntry > maxEntry / 2)
            {
                MessageBox.Show("Requirement: MinNodePerEntry <= MaxNodePerEntry/2");
                return new List<double> { best_so_far_dist, best_so_far_loc };
            }

            List<Rectangle> recList = new List<Rectangle>();
            List<int> id_itemList = new List<int>();

            for (int i = 0; i <= inputData.Count - NLength; i++)
            {
                List<double> subseq = inputData.GetRange(i, NLength);
                id_item++;
                Rectangle new_rec = new Rectangle(MathFuncs.PAA_Lower(subseq, D, R).ToArray(), MathFuncs.PAA_Upper(subseq, D, R).ToArray(), i);
                rtree.Add(new_rec, id_item);
                recList.Add(new_rec);
                id_itemList.Add(id_item);
            }


            Dictionary<int, Node<int>> nodeMap = rtree.getNodeMap();
            List<Node<int>> leafNodes = nodeMap.Values.Where(node => node.level == 1).OrderBy(node => node.entryCount).ToList();

            List<Rectangle> leafMBRs = leafNodes.Select(node => node.mbr).ToList(); // List rectangle of leaf nodes in order of list leafNodes

            for (int i = 0; i < leafNodes.Count; i++)
            {
                List<Rectangle> leafEntries = leafNodes[i].entries.Where(mbr => mbr != null).Select(mbr => mbr).ToList();
                if (leafEntries.Count > 0)
                {
                    int beginIndex = candidateList.Count;
                    candidateList.AddRange(leafEntries.Select(mbr => mbr.getIndexSubSeq()));
                    beginIndexInner.AddRange(Enumerable.Repeat(beginIndex, leafEntries.Count));
                    indexOfLeafMBRS.AddRange(Enumerable.Repeat(i, leafEntries.Count));
                }
            }

            for (int i = 0; i < candidateList.Count; i++)//outer loop
            {

                int p = candidateList[i];

                // rectangle of subseq in p postion
                if (is_skipped_at_p[p])
                {
                    //p was visited at inner loop before
                    continue;
                }
                else
                {
                    List<double> subseq_p = inputData.GetRange(p, NLength);
                    //Rectangle p_rectangle = recList[p];
                    List<double> P_PAA = MathFuncs.PAA(subseq_p, D);

                    nearest_neighbor_dist = Constants.INFINITE;

                    List<bool> eliminatedMBR = new List<bool>();
                    for (int k = 0; k < leafMBRs.Count; k++)
                        eliminatedMBR.Add(false);

                    int indexMBRLeaf = -1;
                    int num_leaf_skips = 0;

                    for (int j = 0; j < candidateList.Count; j++)// inner loop
                    {
                        // int q = innerList[j];
                        int index_inner = (beginIndexInner[i] + j) % candidateList.Count;
                        int q = candidateList[index_inner];

                        int index_MBRInnner = (beginIndexInner[i] + j) % candidateList.Count;
                        int MBRInnner = indexOfLeafMBRS[index_MBRInnner];

                        if (indexMBRLeaf < MBRInnner)//the first entry of the next node ?
                        {
                            indexMBRLeaf++;


                            /* Test:
                             * if (indexMBRInnner[j] == MBRInnner)
                                Console.WriteLine("OK");*/

                            //calc minDist:
                            //double minDist = MathFuncss.MINDIST(p_rectangle, leafMBRs[MBRInnner], (NLength / (double)(D)));
                            double minDist = MathFuncs.MINDIST(P_PAA, leafMBRs[MBRInnner], (NLength / (double)(D)));

                            //if (minDist_keo > minDist)
                            //{
                            //   Console.WriteLine("STOPPP");
                            //  return;
                            //}

                            if (minDist >= nearest_neighbor_dist)
                            {
                                num_leaf_skips++;
                                eliminatedMBR[MBRInnner] = true;

                                continue;// pruned => skip to the next one
                            }
                            else
                            {
                                if (Math.Abs(p - q) < NLength)
                                {
                                    continue;// self-match => skip to the next one
                                }

                                //calculate the Distance between p and q
                                dist = MathFuncs.EuDistance(subseq_p, inputData.GetRange(q, NLength));

                                if (dist < best_so_far_dist)
                                {
                                    //skip the element q at oute_loop, 'cuz if (p,q) is not a solution, neither is (q,p).
                                    is_skipped_at_p[q] = true;

                                    break_to_outer_loop = true; //break, to the next loop at outer_loop
                                    break;// break at inner_loop first
                                }

                                if (dist < nearest_neighbor_dist)
                                {
                                    nearest_neighbor_dist = dist;
                                }
                            }
                        }
                        else // still the same node
                        {
                            if (eliminatedMBR[MBRInnner]) // can prune ?
                            {
                                continue;
                            }
                            else //do it normally
                            {
                                if (Math.Abs(p - q) < NLength)
                                {
                                    continue;// self-match => skip to the next one
                                }
                                else
                                {
                                    //calculate the Distance between p and q
                                    dist = MathFuncs.EuDistance(subseq_p, inputData.GetRange(q, NLength));

                                    if (dist < best_so_far_dist)
                                    {
                                        //skip the element q at oute_loop, 'cuz if (p,q) is not a solution, neither is (q,p).
                                        is_skipped_at_p[q] = true;

                                        break_to_outer_loop = true; //break, to the next loop at outer_loop
                                        break;// break at inner_loop first
                                    }

                                    if (dist < nearest_neighbor_dist)
                                    {
                                        nearest_neighbor_dist = dist;
                                    }
                                }
                            }


                        }//end ELSE

                    } //end for inner loop

                    //Console.WriteLine("num_leaf_skips="+ num_leaf_skips);
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
                }

            }//end outer loop
            if (is_first_time)
            {
                this_id_item = id_item;
                this_id_itemList = id_itemList;
                this_RTree = rtree;
                this_rectList = recList;
            }
            return new List<double> { best_so_far_dist, best_so_far_loc };
        }

        /*Run Online (Liu method)*/
        private void btnRunOnl_Click(List<double> training_data, List<double> streaming_data, int period, int NLength, int maxEntry, int minEntry, int R, int D)
        {
            //create a new buffer. In this demo, the buffer is training_data (edit later):
            List<double> this_buffer = new List<double>();
            this_buffer.AddRange(training_data);

            // Store furnitures in RTree
            int this_id_item = int.MinValue;
            List<int> this_id_itemList = new List<int>();
            RTree<int> this_RTree = new RTree<int>(maxEntry, minEntry);
            List<Rectangle> this_recList = new List<Rectangle>();

            // Call 'Run Offline' for the first time, store results into variables ("this" object):
            List<double> discord_firsttime = RunOfflineMinDist(training_data, NLength, maxEntry, minEntry, R, D, ref this_id_item, ref this_id_itemList, ref this_recList, ref this_RTree, true);

            // Store current discord in buffer
            double this_best_so_far_dist = discord_firsttime[0];
            double this_best_so_far_loc = discord_firsttime[1];

            //store the last subsequence of the buffer:
            List<double> last_sub = this_buffer.GetRange(this_buffer.Count - NLength, NLength);
            

            // STREAMING: keep streaming until we have no more data points
            for (int index_stream = 0; index_stream < streaming_data.Count; index_stream++)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();///calc execution time

                double new_data_point = streaming_data[index_stream];

                //update last_sub at time t to get new_sub at time (t+1):
                last_sub.Add(new_data_point);
                last_sub.RemoveAt(0);
                List<double> new_sub = last_sub; // the same object

                // Insert the new entry into the tree:
                this_id_item++;

                // Add the new rec to the tree:
                Rectangle new_rec = new Rectangle(Utils.MathFuncs.PAA_Lower(new_sub, D, R).ToArray(), Utils.MathFuncs.PAA_Upper(new_sub, D, R).ToArray(), this_buffer.Count - NLength + 1 + index_stream);
                this_RTree.Add(new_rec, this_id_item);
                this_recList.Add(new_rec);
                this_id_itemList.Add(this_id_item);

                //remove the oldest entry:
                this_RTree.Delete(this_recList[index_stream], this_id_itemList[index_stream]);

                //get the first sub before update the buffer (help to find the small match in Liu's method)
                List<double> first_sub = this_buffer.GetRange(0, NLength);

                // update buffer:
                this_buffer.Add(new_data_point);
                this_buffer.RemoveAt(0);

                /* 'til now, we have already updated the tree.
                 from now on, almost just copy the offline code:
                 */

                //Method 1: just re-order the 2 loops:
                //RunOnline_Method1(this_buffer, index_stream);

                //Method 2: Liu's algorithm:
                //Note: Method_2 includes method_1 (case a)
                //RunOnline_LiuMethod_origin(this_buffer, index_stream, first_sub);

                //Method 3: motified_Liu's
                List<double> discord_Liu = RunOnline_LiuMethod_edited(this_buffer, index_stream, first_sub, this_RTree, this_best_so_far_dist, (int)this_best_so_far_loc, NLength, D);
                this_best_so_far_dist = discord_Liu[0];
                this_best_so_far_loc = discord_Liu[1];

                watch.Stop(); //stop timer
                long elapsedMs = watch.ElapsedMilliseconds;
                //this.txtExeTime.Text = elapsedMs.ToString();

                Console.WriteLine("ExeTime_Online=" + elapsedMs.ToString());

                // Useless variable to pass parameter
                int dumb = 0;
                List<int> dumb_list = new List<int>();
                List<Rectangle> dumb_rectlist = new List<Rectangle>();
                RTree<int> dumb_rtree = new RTree<int>(maxEntry, minEntry);



                //call offline version to assure the results and compare the time executions:
                var watch2 = System.Diagnostics.Stopwatch.StartNew();///calc execution time offline
                List<double> discord_offline = RunOfflineMinDist(training_data, NLength, maxEntry, minEntry, R, D, ref dumb, ref dumb_list, ref dumb_rectlist, ref dumb_rtree, false);
                double this_best_so_far_dist_offline = discord_offline[0];

                watch2.Stop(); //stop timer
                long this_exeTimeOffline = watch2.ElapsedMilliseconds;

                //check:
                if (Math.Abs(this_best_so_far_dist - this_best_so_far_dist_offline) < 10e-7)
                {
                    Console.WriteLine("checked, ok.");
                    if (elapsedMs > this_exeTimeOffline)
                    {
                        Console.WriteLine("Online takes more time than Offline !!!");
                    }
                }
                else
                {
                    Console.WriteLine("this.best_so_far_dist = " + this_best_so_far_dist);
                    Console.WriteLine("this.best_so_far_dist_Offline = " + this_best_so_far_dist_offline);
                    Console.WriteLine("The results are different. Stop Streaming !!!");
                    return;
                }

                Console.WriteLine("------------------------");

            } // end For loop (streaming)

            Console.WriteLine("--- Streaming's done (run out of data) ---");
        } //end btnRunOnl_Click function

        /*Run Online - new method (inner loop only)*/
        private void Btn_NewOnline_Click(List<double> training_data, List<double> streaming_data, int period, int NLength, int maxEntry, int minEntry, int R, int D)
        {
            //create a new buffer. In this demo, the buffer is training_data (edit later):
            List<double>  this_buffer = new List<double>();
            this_buffer.AddRange(training_data);

            // Store furnitures in RTree
            int this_id_item = int.MinValue;
            List<int> this_id_itemList = new List<int>();
            RTree<int> this_RTree = new RTree<int>(maxEntry, minEntry);
            List<Rectangle> this_recList = new List<Rectangle>();

            // Call 'Run Offline' for the first time, store results into variables ("this" object):
            List<double> discord_firsttime = RunOfflineMinDist(training_data, NLength, maxEntry, minEntry, R, D, ref this_id_item, ref this_id_itemList, ref this_recList, ref this_RTree, true);
            double this_best_so_far_dist_TheMostDiscord = discord_firsttime[0];

            //store the last subsequence of the buffer:
            List<double> last_sub = this_buffer.GetRange(this_buffer.Count - NLength, NLength);


            // STREAMING: keep streaming until we have no more data points
            for (int index_stream = 0; index_stream < streaming_data.Count; index_stream++)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();///calc execution time

                double new_data_point = streaming_data[index_stream];

                //update last_sub at time t to get new_sub at time (t+1):
                last_sub.Add(new_data_point);
                last_sub.RemoveAt(0);
                List<double> new_sub = last_sub; // the same object

                // Insert the new entry into the tree:
                this_id_item++;

                // Add the new rec to the tree:
                Rectangle new_rec = new Rectangle(Utils.MathFuncs.PAA_Lower(new_sub, D, R).ToArray(), Utils.MathFuncs.PAA_Upper(new_sub, D, R).ToArray(), this_buffer.Count - NLength + 1 + index_stream);
                this_RTree.Add(new_rec, this_id_item);
                this_recList.Add(new_rec);
                this_id_itemList.Add(this_id_item);

                //remove the oldest entry:
                this_RTree.Delete(this_recList[index_stream], this_id_itemList[index_stream]);

                // update buffer:
                this_buffer.Add(new_data_point);
                this_buffer.RemoveAt(0);

                /* 'til now, we have already updated the tree.
                 from now on, almost just copy the offline code:
                 */

                //Run new_online_algorithm:
                NewOnlineAlgorithm(this_buffer, 2 * period, index_stream, period, new_sub, this_RTree, NLength, D, R, maxEntry, minEntry, ref this_best_so_far_dist_TheMostDiscord);

                watch.Stop(); //stop timer
                long elapsedMs = watch.ElapsedMilliseconds;
                //this.txtExeTime.Text = elapsedMs.ToString();

                Console.WriteLine("ExeTime_Online=" + elapsedMs.ToString());

                Console.WriteLine("------------------------");

            } // end For loop (streaming)

            Console.WriteLine("--- Streaming's done (run out of data) ---");
        }

        //////////// Helper Functions ///////////////

        /* Called by RunOnline_LiuMethod_edited:*/
        public static List<double> LiuEdited_CaseA(List<double> inputData, int index_stream, RTree<int> this_RTree, int this_NLength, int this_D)
        {  /* This function is almost the same as Offline_minDist version. We just edit some lines*/
            List<int> candidateList = new List<int>();
            List<int> beginIndexInner = new List<int>();
            List<int> indexOfLeafMBRS = new List<int>();


            bool[] is_skipped_at_p = new bool[inputData.Count];
            for (int i = 0; i < inputData.Count; i++)
                is_skipped_at_p[i] = false;

            double best_so_far_dist = 0;
            int best_so_far_loc = 0;

            double nearest_neighbor_dist = 0;
            double dist = 0;
            bool break_to_outer_loop = false;


            Dictionary<int, Node<int>> nodeMap = this_RTree.getNodeMap();
            List<Node<int>> leafNodes = nodeMap.Values.Where(node => node.level == 1).OrderBy(node => node.entryCount).ToList();

            List<Rectangle> leafMBRs = leafNodes.Select(node => node.mbr).ToList(); // List rectangle of leaf nodes in order of list leafNodes

            for (int i = 0; i < leafNodes.Count; i++)
            {
                List<Rectangle> leafEntries = leafNodes[i].entries.Where(mbr => mbr != null).Select(mbr => mbr).ToList();
                if (leafEntries.Count > 0)
                {
                    int beginIndex = candidateList.Count;

                    // we change a bit at the following line, we subtract mbr indice by "index_stream + 1":
                    candidateList.AddRange(leafEntries.Select(mbr => mbr.getIndexSubSeq(index_stream + 1)));

                    beginIndexInner.AddRange(Enumerable.Repeat(beginIndex, leafEntries.Count));
                    indexOfLeafMBRS.AddRange(Enumerable.Repeat(i, leafEntries.Count));
                }
            }

            for (int i = 0; i < candidateList.Count; i++)//outer loop
            {

                int p = candidateList[i];

                if (is_skipped_at_p[p])
                {
                    //p was visited at inner loop before
                    continue;
                }
                else
                {
                    List<double> subseq_p = inputData.GetRange(p, this_NLength);
                    //Rectangle p_rectangle = recList[p];
                    List<double> P_PAA = MathFuncs.PAA(subseq_p, this_D);

                    nearest_neighbor_dist = Constants.INFINITE;

                    List<bool> eliminatedMBR = new List<bool>();
                    for (int k = 0; k < leafMBRs.Count; k++)
                        eliminatedMBR.Add(false);

                    int indexMBRLeaf = -1;
                    int num_leaf_skips = 0;

                    for (int j = 0; j < candidateList.Count; j++)// inner loop
                    {
                        // int q = innerList[j];
                        int index_inner = (beginIndexInner[i] + j) % candidateList.Count;
                        int q = candidateList[index_inner];

                        int index_MBRInnner = (beginIndexInner[i] + j) % candidateList.Count;
                        int MBRInnner = indexOfLeafMBRS[index_MBRInnner];

                        if (indexMBRLeaf < MBRInnner)//the first entry of the next node ?
                        {
                            indexMBRLeaf++;

                            //calc minDist:
                            //double minDist = MathFuncs.MINDIST(p_rectangle, leafMBRs[MBRInnner], (NLength / (double)(D)));
                            double minDist = MathFuncs.MINDIST(P_PAA, leafMBRs[MBRInnner], (this_NLength / (double)(this_D)));

                            if (minDist >= nearest_neighbor_dist)
                            {
                                num_leaf_skips++;
                                eliminatedMBR[MBRInnner] = true;

                                continue;// pruned => skip to the next one
                            }
                            else
                            {
                                if (Math.Abs(p - q) < this_NLength)
                                {
                                    continue;// self-match => skip to the next one
                                }

                                //calculate the Distance between p and q
                                dist = MathFuncs.EuDistance(subseq_p, inputData.GetRange(q, this_NLength));

                                if (dist < best_so_far_dist)
                                {
                                    //skip the element q at oute_loop, 'cuz if (p,q) is not a solution, neither is (q,p).
                                    is_skipped_at_p[q] = true;

                                    break_to_outer_loop = true; //break, to the next loop at outer_loop
                                    break;// break at inner_loop first
                                }

                                if (dist < nearest_neighbor_dist)
                                {
                                    nearest_neighbor_dist = dist;
                                }
                            }
                        }
                        else // still the same node
                        {
                            if (eliminatedMBR[MBRInnner]) // can prune ?
                            {
                                continue;
                            }
                            else //do it normally
                            {
                                if (Math.Abs(p - q) < this_NLength)
                                {
                                    continue;// self-match => skip to the next one
                                }
                                else
                                {
                                    //calculate the Distance between p and q
                                    dist = MathFuncs.EuDistance(subseq_p, inputData.GetRange(q, this_NLength));

                                    if (dist < best_so_far_dist)
                                    {
                                        //skip the element q at oute_loop, 'cuz if (p,q) is not a solution, neither is (q,p).
                                        is_skipped_at_p[q] = true;

                                        break_to_outer_loop = true; //break, to the next loop at outer_loop
                                        break;// break at inner_loop first
                                    }

                                    if (dist < nearest_neighbor_dist)
                                    {
                                        nearest_neighbor_dist = dist;
                                    }
                                }
                            }
                        }//end ELSE

                    } //end for inner loop

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
                }

            }//end outer loop

            Console.WriteLine("index_stream=" + index_stream);
            Console.WriteLine("best_so_far_loc=" + best_so_far_loc);
            Console.WriteLine("best_so_far_dist=" + best_so_far_dist);

            List<double> result = new List<double> { best_so_far_dist, best_so_far_loc };

            return result;
        } //end RunOnline_LiuEditedCaseA

        /* Called by RunOnline_LiuMethod_edited:*/
        public static List<double> LiuEdited_CaseB(List<double> buffer, int index_stream, int first_candidate, int second_candidate, List<double> removed_sub, RTree<int> this_RTree, int this_NLength, int this_D, double this_best_so_far_dist)
        {
            List<int> candidateList = new List<int>();
            List<int> beginIndexInner = new List<int>();
            List<int> indexOfLeafMBRS = new List<int>();

            Dictionary<int, Node<int>> nodeMap = this_RTree.getNodeMap();

            List<Node<int>> leafNodes = nodeMap.Values.Where(node => ((node.level == 1))).OrderBy(node => node.entryCount).ToList();
            List<Rectangle> leafMBRs = leafNodes.Select(node => node.mbr).ToList(); // List rectangle of leaf nodes in order of list leafNodes

            for (int num = 0; num < leafNodes.Count; num++)
            {
                List<Rectangle> leafEntries = leafNodes[num].entries.Where(mbr => mbr != null).Select(mbr => mbr).ToList();
                if (leafEntries.Count > 0)
                {
                    int beginIndex = candidateList.Count;
                    // we change a bit at the following line, we subtract mbr indice by "index_stream + 1":
                    candidateList.AddRange(leafEntries.Select(mbr => mbr.getIndexSubSeq(index_stream + 1)));
                    beginIndexInner.AddRange(Enumerable.Range(1, leafEntries.Count).Select(x => beginIndex));
                    indexOfLeafMBRS.AddRange(Enumerable.Repeat(num, leafEntries.Count));
                }
            } // end for

            // get the two first candidates to the head of candidateList
            int count = 0;
            int index = 0;
            while (count < 1)
            {
                if (candidateList[index] == first_candidate)
                {
                    candidateList[index] = candidateList[0];
                    int temp = beginIndexInner[index];
                    beginIndexInner[index] = beginIndexInner[0];
                    beginIndexInner[0] = temp;
                    count++;
                }
                if (candidateList[index] == second_candidate)
                {
                    candidateList[index] = candidateList[1];
                    int temp = beginIndexInner[index];
                    beginIndexInner[index] = beginIndexInner[1];
                    beginIndexInner[1] = temp;
                    count++;
                }
                index++;
            }
            candidateList[0] = first_candidate;
            candidateList[1] = second_candidate;

            double best_so_far_dist = 0;
            int best_so_far_loc = 0;

            double nearest_neighbor_dist = 0;
            double dist = 0;
            bool break_to_outer_loop = false;

            bool[] is_skipped_at_p = new bool[buffer.Count];
            for (int i = 0; i < buffer.Count; i++)
                is_skipped_at_p[i] = false;



            for (int i = 0; i < candidateList.Count; i++)
            {
                int p = candidateList[i];

                //check small_match:
                double small_match = Utils.MathFuncs.EuDistance(buffer.GetRange(p, this_NLength), removed_sub);

                if (i >= 2 && small_match >= this_best_so_far_dist)
                {
                    continue;
                }
                if (is_skipped_at_p[p])
                {
                    //p was visited at inner loop before
                    continue;
                }
                else
                {

                    List<double> subseq_p = buffer.GetRange(p, this_NLength);
                    //Rectangle p_rectangle = recList[p];
                    List<double> P_PAA = MathFuncs.PAA(subseq_p, this_D);

                    nearest_neighbor_dist = Constants.INFINITE;

                    List<bool> eliminatedMBR = new List<bool>();
                    for (int k = 0; k < leafMBRs.Count; k++)
                        eliminatedMBR.Add(false);

                    int indexMBRLeaf = -1;

                    for (int j = 0; j < candidateList.Count; j++)// inner loop
                    {
                        // int q = innerList[j];
                        int index_inner = (beginIndexInner[i] + j) % candidateList.Count;
                        int q = candidateList[index_inner];

                        int index_MBRInnner = (beginIndexInner[i] + j) % candidateList.Count;
                        int MBRInnner = indexOfLeafMBRS[index_MBRInnner];

                        if (indexMBRLeaf < MBRInnner)//the first entry of the next node ?
                        {
                            indexMBRLeaf++;

                            /* Test:
                             * if (indexMBRInnner[j] == MBRInnner)
                                Console.WriteLine("OK");*/

                            //calc minDist:
                            //double minDist = MathFuncs.MINDIST(p_rectangle, leafMBRs[MBRInnner], (NLength / (double)(D)));
                            double minDist = MathFuncs.MINDIST(P_PAA, leafMBRs[MBRInnner], (this_NLength / (double)(this_D)));

                            //if (minDist_keo > minDist)
                            //{
                            //   Console.WriteLine("STOPPP");
                            //  return;
                            //}

                            if (minDist >= nearest_neighbor_dist)
                            {
                                eliminatedMBR[MBRInnner] = true;

                                continue;// pruned => skip to the next one
                            }
                            else
                            {
                                if (Math.Abs(p - q) < this_NLength)
                                {
                                    continue;// self-match => skip to the next one
                                }

                                //calculate the Distance between p and q
                                dist = MathFuncs.EuDistance(subseq_p, buffer.GetRange(q, this_NLength));

                                if (dist < best_so_far_dist)
                                {
                                    //skip the element q at oute_loop, 'cuz if (p,q) is not a solution, neither is (q,p).
                                    is_skipped_at_p[q] = true;

                                    break_to_outer_loop = true; //break, to the next loop at outer_loop
                                    break;// break at inner_loop first
                                }

                                if (dist < nearest_neighbor_dist)
                                {
                                    nearest_neighbor_dist = dist;
                                }
                            }
                        }
                        else // still the same node
                        {
                            if (eliminatedMBR[MBRInnner]) // can prune ?
                            {
                                continue;
                            }
                            else //do it normally
                            {
                                if (Math.Abs(p - q) < this_NLength)
                                {
                                    continue;// self-match => skip to the next one
                                }
                                else
                                {
                                    //calculate the Distance between p and q
                                    dist = MathFuncs.EuDistance(subseq_p, buffer.GetRange(q, this_NLength));

                                    if (dist < best_so_far_dist)
                                    {
                                        //skip the element q at oute_loop, 'cuz if (p,q) is not a solution, neither is (q,p).
                                        is_skipped_at_p[q] = true;

                                        break_to_outer_loop = true; //break, to the next loop at outer_loop
                                        break;// break at inner_loop first
                                    }

                                    if (dist < nearest_neighbor_dist)
                                    {
                                        nearest_neighbor_dist = dist;
                                    }
                                }
                            }


                        }//end ELSE

                    } //end for inner loop

                    //Console.WriteLine("num_leaf_skips="+ num_leaf_skips);
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

                    ////////////////////////
                }

            } // end for
            //update the results:

            Console.WriteLine("index_stream = " + index_stream);
            Console.WriteLine("best_so_far_loc = " + best_so_far_loc);
            Console.WriteLine("best_so_far_dist = " + best_so_far_dist);


            List<double> result = new List<double> { best_so_far_dist, best_so_far_loc };

            return result;
        } // end RunOnline_Liu_edit

        public static List<double> RunOnline_LiuMethod_edited(List<double> buffer, int index_stream, List<double> removed_sub, RTree<int> this_RTree, double this_best_so_far_dist, int this_best_so_far_loc, int this_NLength, int this_D)
        {
            /* Liu's algorithm */

            //calc 'currDist' which is the distance of the discord at time t and the new subsquence at time (t+1):
            double currDist = 0;
            if (this_best_so_far_loc > 0) // make sure we can calc CurrDist when 'this_best_so_far_loc - 1' >= 0
                currDist = Utils.MathFuncs.EuDistance(buffer.GetRange(this_best_so_far_loc - 1, this_NLength), buffer.GetRange(buffer.Count - this_NLength, this_NLength));

            //if the case (a): Modify the Rtree: call method1
            if (currDist < this_best_so_far_dist || this_best_so_far_loc == 0)
            {
                Console.WriteLine("Running case (a)...");
                return LiuEdited_CaseA(buffer, index_stream, this_RTree, this_NLength, this_D);
            }
            else //case (b): we can reduce the num of elements in the outer loop:
            {
                Console.WriteLine("Running case (b).........");
                List<int> candidate_list_reduced = new List<int>(); //store outer loop

                /* Find the candidate_list:*/
                //The local discord at time t:
                int first_candidate = (this_best_so_far_loc - 1);

                //The subsequence (m-n+1, n)(t+1):
                int second_candidate = (buffer.Count - this_NLength);

                /* we will do the rest by calling Liu_edit:*/
                return LiuEdited_CaseB(buffer, index_stream, first_candidate, second_candidate, removed_sub, this_RTree, this_NLength, this_D, this_best_so_far_dist);

            }

        } 

        /* new_online_algorithm: */
        public static List<double> NewOnlineAlgorithm(List<double> buffer, int startPoint, int index_stream, int period, List<double> new_sub, RTree<int> this_RTree, int this_NLength, int this_D, int this_R, int maxEntry, int minEntry, ref double this_best_so_far_dist_TheMostDiscord)
        {
            int best_so_far_loc = -1;

            // update data (for calculating thres) ?
            if (index_stream % period == 0) //update after a period
            {
                List<double> this_buffer_to_startPoint = buffer.GetRange(0, startPoint);

                // Useless variable to pass parameter
                int dumb = 0;
                List<int> dumb_list = new List<int>();
                List<Rectangle> dumb_rectlist = new List<Rectangle>();
                RTree<int> dumb_rtree = new RTree<int>(maxEntry, minEntry);
                
                //calc TheMostDiscord T[1:sp] (return at "this_best_so_far_dist_TheMostDiscord" variable):
                List <double> discord = RunOfflineMinDist(this_buffer_to_startPoint, this_NLength, maxEntry, minEntry, this_R, this_D, ref dumb, ref dumb_list, ref dumb_rectlist, ref dumb_rtree, false);
                this_best_so_far_dist_TheMostDiscord = discord[0];

                Console.WriteLine("update data (for calculating thres), at index_stream " + index_stream);
            }

            //get threshold_dist:
            double threshold_dist = this_best_so_far_dist_TheMostDiscord;

            //index of new_subsequence q: 
            int q_outer = buffer.Count - this_NLength;

            // get Inner list:
            Dictionary<int, Node<int>> nodeMap = this_RTree.getNodeMap();
            List<Node<int>> leafNodes = nodeMap.Values.Where(node => node.level == 1).OrderBy(node => node.entryCount).ToList();

            List<int> innerList = new List<int>();
            for (int num = 0; num < leafNodes.Count; num++)
            {
                List<int> all_entry_IDs_from_a_node = leafNodes[num].entries.Where(mbr => (mbr != null) && (mbr.getIndexSubSeq(index_stream + 1) != q_outer)).Select(mbr => mbr.getIndexSubSeq(index_stream + 1)).ToList();

                if (all_entry_IDs_from_a_node.Count == leafNodes[num].entryCount) // if q in the outer loop is NOT in this leaf:
                {
                    innerList.AddRange(all_entry_IDs_from_a_node);
                }
                else // If q is IN this leaf: We add all entry ids in the leaf to the head of the innerList 
                {
                    innerList.InsertRange(0, all_entry_IDs_from_a_node);
                    // note: In this case, all_Entry_IDs_from_a_node doesnt include 'q' id.
                }
            }

            double nearest_neighbor_dist = Constants.INFINITE;
            foreach (int p_inner in innerList)
            {
                if (Math.Abs(p_inner - q_outer) >= this_NLength)
                {
                    //calculate the Distance between p and q
                    double dist = MathFuncs.EuDistance(new_sub, buffer.GetRange(p_inner, this_NLength));

                    if (dist < nearest_neighbor_dist)
                    {
                        nearest_neighbor_dist = dist;
                       // best_so_far_loc = p_inner; //store best_so_far_loc
                    }

                    if (dist < threshold_dist)
                        break;
                }
            }


            if (nearest_neighbor_dist > threshold_dist)
            {
                best_so_far_loc = q_outer;
                Console.WriteLine("Discord!\nbest_so_far_loc = " + best_so_far_loc + "\nbest_so_far_dist = " + nearest_neighbor_dist);
            }
            else
            {
                Console.WriteLine("No discord");
                best_so_far_loc = -1;
                nearest_neighbor_dist = -1;
            }

            return new List<double>() { nearest_neighbor_dist, best_so_far_loc }; //return "-1" if there is no discord.
        }

    }
}
