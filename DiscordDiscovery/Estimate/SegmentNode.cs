using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordDiscovery.Estimate
{
    public class SegmentNode : IComparable<SegmentNode>, IMergeCostNode
    {
        private int begin_index;
        private int length;
        private double merge_cost;
        public SegmentNode pre_node, post_node;
        public SegmentNode(int begin_index, int length)
        {
            this.begin_index = begin_index;
            this.length = length;
            this.post_node = null;
            this.pre_node = null;
        }

        public void setLength(int length)
        {
            if (length > 0)
            {
                this.length = length;
            }
        }

        public int getLength()
        {
            return this.length;
        }

        public void setMergeCost(double merge_cost)
        {
            this.merge_cost = merge_cost;
        }

        public double getMergeCost()
        {
            return this.merge_cost;
        }

        public int getIndex()
        {
            return this.begin_index;
        }

        public void setIndex(int index)
        {
            this.begin_index = index;
        }

        public int CompareTo(SegmentNode other)
        {
            if (this.merge_cost < other.getMergeCost())
                return -1;
            else
                if (this.merge_cost > other.getMergeCost())
                return 1;
            else
                return 0;
        }
    }
}
