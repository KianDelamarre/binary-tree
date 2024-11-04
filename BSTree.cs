using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace week5
{
    class BSTree<T> : BinTree<T> where T : IComparable
    {  //root declared as protected in Parent Class – Binary Tree
        public BSTree()
        {
            root = null;
        }
        public BSTree(Node<T> node)
        {
            root = node;
        }

        public void insertItem(T item)
        {
            insertItem(item, ref root);
        }

        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                tree = new Node<T>(item);

            else if (item.CompareTo(tree.Data) < 0)
                insertItem(item, ref tree.Left);

            else if (item.CompareTo(tree.Data) > 0)
                insertItem(item, ref tree.Right);
        }

        public bool Equals(BSTree<T> tree)
        {
            return Equals(root, tree.root); 
        }

        private bool Equals(Node<T> node1, Node<T> node2)
        {
            if (node1 == null && node2 == null)
            {
                return true;
            }   

            if (node1 == null || node2 == null || node1.Data.CompareTo(node2.Data)!=0)
            {             
                return false;
            }
                //if (Equals(node1.Left, node2.Left) && Equals(node1.Right, node2.Right))       I left this in to show how i origianlly had the code before i realised how i could simplify it
                //{
                //    return true;
                //}
                //return false;

            return (Equals(node1.Left, node2.Left) && Equals(node1.Right, node2.Right));
        }

        public bool SubTree(BSTree<T> subTree)
        {
            //check if the subtree is nulll
            if (subTree == null)
            {
                return true;         //an empty tree is always a subtree
            }
            
            //check if the tree calling function is null
            if (this.root == null)
            {
                return false;   //if subTree!=null and larger tree == null, then tree cannot be a subtree of the larger tree
            }
            return SubTree(root, subTree.root);
        }

        private bool SubTree(Node<T> parentTreeNode, Node<T> subTreeRoot)
        {
            if(parentTreeNode == null)   //if the current node is null, then there are no more branches so there cannot be any subtrees after this
            {
                return false;
            }

            if(Equals(parentTreeNode, subTreeRoot))   //use Equal method to check if the trees are the exact same and return true if they are
            {
                return true;      
            }

            if (SubTree(parentTreeNode.Left, subTreeRoot))   //recurse to the left and see if the subtree matches
            {
                return true;
            }
            if (SubTree(parentTreeNode.Right, subTreeRoot))   //recurse right and see if the subtree matches
            {
                return true;
            }

            return false;     //no subtrees match so return false

        }




    }

}
