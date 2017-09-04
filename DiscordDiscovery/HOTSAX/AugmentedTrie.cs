using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordDiscovery.HOTSAX
{
    class AugmentedTrie
    {
        private TreeNode root;
        private List<char> path;
        private static int total_printing_row = 0;

        private static int number_run = 0;

        //contructor
        public AugmentedTrie(TreeNode node, List<char> path_tree)
        {
            this.root = node;
            this.path = path_tree;
        }


        //print tree (for testing wether it was made correctly)
        private void PrintTheTree_helper()
        {

            if (this.root.GetChildsNode().Count == 0)
            {

                this.path.ForEach(Console.Write);
                Console.WriteLine();
                AugmentedTrie.total_printing_row++; // counting how many rows were printed

            }
            else
            {
                foreach (TreeNode node_child in this.root.GetChildsNode())
                {
                    List<char> path_child = new List<char>(this.path);
                    path_child.Add(node_child.GetKeyNode());
                    AugmentedTrie tree_child = new AugmentedTrie(node_child, path_child);
                    tree_child.PrintTheTree_helper();
                }
            }
        }

        //print the empty tree (when no data was added)
        private void PrintTheTree()
        {
            AugmentedTrie.number_run++;
            this.PrintTheTree_helper();
            Console.WriteLine("The total is " + (AugmentedTrie.total_printing_row / AugmentedTrie.number_run) + " rows.\n");
        }
        public void InsertChildsIntoCurNode(TreeNode cur_node)
        {
            String string_abc = "abc";
            cur_node.SetChildsNode(string_abc);
        }

        public void InsertChildsRecursive(TreeNode node, int number_recursion)//in this case, 'number_recursion' is 'w_length'.
        {
            if (number_recursion == 0)
                return;
            else
            {
                InsertChildsIntoCurNode(node);
                foreach (TreeNode child_node in node.GetChildsNode())
                {
                    InsertChildsRecursive(child_node, (number_recursion - 1));
                }
            }

        }


        //make an empty trie
        public void CreateTheAugmentedTrie(int w_length, bool is_print_the_tree = false)
        {
            this.InsertChildsRecursive(this.root, w_length);
            if (is_print_the_tree)
                this.PrintTheTree();
        }


        public TreeNode FindtheLeaf(string path_to_the_leaf)//the string which has 3 char,
        {                                           //e.g. path_to_the_leaf ="aab", "aaa", "abc",.....
            TreeNode node = this.root;

            foreach (char key in path_to_the_leaf)
            {
                switch (key)
                {
                    case 'a':
                        node = node.GetChildsNode()[0];
                        break;
                    case 'b':
                        node = node.GetChildsNode()[1];
                        break;
                    case 'c':
                        node = node.GetChildsNode()[2];
                        break;
                    default:
                        {
                            System.Console.WriteLine("The key is not 'a', 'b' or 'c'. Return the root instead.");
                            return this.root;
                        }
                }
            }


            return node;
        }


        public void AddTheDataToLeaf(string path_to_the_leaf, int index, bool is_print_success = false)
        {
            // find the leaf, append its position to 'Node.data' attribute.
            TreeNode the_leaf;
            the_leaf = FindtheLeaf(path_to_the_leaf);
            the_leaf.AddDataNode(index);

            if (is_print_success)
                Console.WriteLine("ADD is successed at node '" + the_leaf.GetKeyNode() + "'");
        }

        public void PrintTheTree_WithData()
        {

            if (this.root.GetChildsNode().Count == 0)
            {
                this.path.ForEach(Console.Write);
                Console.Write("\t" + "data:");
                foreach (int index_data in this.root.GetDataNode())
                    Console.Write(index_data + " ");
                Console.WriteLine();
            }
            else
            {
                foreach (TreeNode node_child in this.root.GetChildsNode())
                {
                    List<char> path_child = new List<char>(this.path);
                    path_child.Add(node_child.GetKeyNode());
                    AugmentedTrie tree_child = new AugmentedTrie(node_child, path_child);
                    tree_child.PrintTheTree_WithData();
                }
            }
        }
    }
}
