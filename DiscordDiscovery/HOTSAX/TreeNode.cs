using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordDiscovery.HOTSAX
{
    class TreeNode
    {
        // Each node include 3 variables:

        private List<TreeNode> childs; // to store list child_nodes (3 nodes in the case)
        private char key; //'a', 'b' or 'c'
        private List<int> data; //list data storing list_indice (at the leaves only) 



        // 2 contructors:

        public TreeNode()
        {
            this.childs = new List<TreeNode>(3);
            this.key = '\0'; //null
            this.data = new List<int>();
        }

        //when we wanna assign the key value
        public TreeNode(char key)
        {
            childs = new List<TreeNode>(3);
            this.key = key;
            data = new List<int>();
        }



        // get + set functions
        public char GetKeyNode()
        {
            return this.key;
        }

        public List<int> GetDataNode()
        {
            return this.data;
        }

        public List<TreeNode> GetChildsNode()
        {
            return this.childs;
        }
        public void SetKeyNode(char key)
        {
            this.key = key;

        }

        public void SetDataNode(List<int> data)
        {
            this.data = data;
        }

        public void AddDataNode(int index)
        {
            this.data.Add(index);
        }

        //take a glance at this one
        public void SetChildsNode(string string_abc)
        {
            for (int i = 0; i < 3; i++)//go through 3 childs
            {
                TreeNode new_child = new TreeNode(string_abc[i]);//make new child, assign the key
                this.childs.Add(new_child);//add the child to its parents childs_list
            }

        }
    }
}
