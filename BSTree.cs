using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

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







    }

}
