using DiscordDiscovery.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordDiscovery.Estimate
{
    static public class BottomUp
    {
        static public void Bottom_Up(List<double> data, double max_error, ref int result, ref MinHeap<SegmentNode> segment_heap)
        {
            segment_heap = new MinHeap<SegmentNode>();
            int i = 0;
            SegmentNode pre_segment = null, cur_segment = null;
            while (i <= (data.Count / 2 - 1))
            {
                cur_segment = new SegmentNode(i * 2, 2);
                cur_segment.pre_node = pre_segment;
                if (pre_segment != null)
                {
                    pre_segment.post_node = cur_segment;
                    double merge_cost = SumSquareError(data.GetRange(pre_segment.getIndex(), pre_segment.getLength() + cur_segment.getLength()));
                    pre_segment.setMergeCost(merge_cost);
                    segment_heap.Insert(pre_segment);
                }
                pre_segment = cur_segment;
                i++;
            }

            if (data.Count % 2 == 1)
            {
                pre_segment = cur_segment;
                cur_segment = new SegmentNode(data.Count - 1, 1);
                cur_segment.pre_node = pre_segment;
                pre_segment.post_node = cur_segment;
                double merge_cost = SumSquareError(data.GetRange(pre_segment.getIndex(), pre_segment.getLength() + cur_segment.getLength()));
                pre_segment.setMergeCost(merge_cost);
                segment_heap.Insert(pre_segment);
            }
            cur_segment.setMergeCost(Constants.INFINITE);
            segment_heap.Insert(cur_segment);

            while (segment_heap.Count > 1 && segment_heap.Peek().getMergeCost() < max_error)
            {
                SegmentNode removed_node, min_node = segment_heap.Peek();
                int index = min_node.getIndex();
                // Merge them
                min_node.setLength(min_node.getLength() + min_node.post_node.getLength());

                // Remove records index + 1
                removed_node = min_node.post_node;
                if (min_node.post_node.post_node != null)
                {
                    min_node.post_node.post_node.pre_node = min_node;
                    min_node.post_node = min_node.post_node.post_node;
                }
                else
                {
                    min_node.post_node = null;
                }
                segment_heap.ExtractAt(segment_heap.getIndexInHeapByValueOfAttributeIndex(removed_node.getIndex()));

                // Update merge_cost
                if (min_node.post_node != null)
                {
                    double merge_cost = SumSquareError(data.GetRange(min_node.getIndex(), min_node.getLength() + min_node.post_node.getLength()));
                    segment_heap.UpdateMergeCostAtTop(merge_cost);
                }
                else
                {
                    segment_heap.UpdateMergeCostAtTop(Constants.INFINITE);
                }


                if (min_node.pre_node != null)
                {
                    double merge_cost_pre = SumSquareError(data.GetRange(min_node.pre_node.getIndex(), min_node.pre_node.getLength() + min_node.getLength()));
                    pre_segment = segment_heap.ExtractAt(segment_heap.getIndexInHeapByValueOfAttributeIndex(min_node.pre_node.getIndex()));
                    pre_segment.setMergeCost(merge_cost_pre);
                    segment_heap.Insert(pre_segment);
                }
            }

            result = (int)(data.Count / segment_heap.Count);
        }

        static public double SumSquareError(List<double> segment)
        {
            double paraA = getParaA(segment);
            double paraB = getParaB(segment);
            double sse = 0;
            foreach (double val in segment)
            {
                sse += Math.Pow(val - (paraA * val + paraB), 2);
            }
            return sse;
        }

        static public double getParaA(List<double> segment)
        {
            int n = segment.Count;
            double paraA = 0;
            for (int i = 1; i <= n; i++)
            {
                paraA += (i - (n + 1) / 2.0) * segment.ElementAt(i - 1);
            }
            return paraA * 12 / (n * (n + 1.0) * (n - 1));
        }

        static public double getParaB(List<double> segment)
        {
            int n = segment.Count;
            double paraA = 0;
            for (int i = 1; i <= n; i++)
            {
                paraA += (i - (2 * n + 1) / 3.0) * segment.ElementAt(i - 1);
            }
            return paraA * 6 / (n * (1.0 - n));
        }
    }
}
