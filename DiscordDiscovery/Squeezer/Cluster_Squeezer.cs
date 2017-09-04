using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordDiscovery.Squeezer
{
    class Cluster_Squeezer
    {
        private Cluster cluster;
        //count the element to calculate support
        private List<Dictionary<int, int>> count_element;
        //Constructor
        public Cluster_Squeezer(Cluster cluster, List<Dictionary<int, int>> count_element)
        {
            this.cluster = cluster;
            this.count_element = count_element;

        }

        public Cluster getCluster()
        {
            return this.cluster;
        }

        public List<Dictionary<int, int>> getCountElements()
        {
            return this.count_element;
        }

        public void updateCountElements(List<int> bit_data)
        {
            if (this.count_element.Count == 0)
                for (int i = 0; i < bit_data.Count; i++)
                {
                    this.count_element.Add(new Dictionary<int, int>() { { bit_data[i], 1 } });
                }

            else
            {
                for (int i = 0; i < bit_data.Count; i++)
                {
                    if ((this.count_element[i]).ContainsKey(bit_data[i]))
                        (this.count_element[i])[bit_data[i]]++;//increase 1;
                    else
                    {
                        (this.count_element[i]).Add(bit_data[i], 1);
                    }

                }

            }

        }

        public void decreaseCountElements(List<int> bit_data)
        {
            for (int i = 0; i < bit_data.Count; i++)
            {
                if ((this.count_element[i]).ContainsKey(bit_data[i]))
                    (this.count_element[i])[bit_data[i]]--;//increase 1;
                else
                {
                    throw new System.Exception("Error at decreaseCountElement");
                }

            }
        }
    }
}
