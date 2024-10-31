using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5
{
    class BinTree<T> where T : IComparable
    {
        private Node<T> root;
        public BinTree()
        {
            root = null;
        }
        public BinTree(Node<T> node)
        {
            root = node;
        }

        public void inOrder(ref string buffer)   //diplay nodes from left-most to right-most
        {
            inOrder(root, ref buffer);
        }

        private void inOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {
                inOrder(tree.Left, ref buffer);
                buffer += tree.Data.ToString() + " , ";
                inOrder(tree.Right, ref buffer);
            }
        }


        public void preOrder(ref string buffer)    //display 
        {
            preOrder(root, ref buffer);
        }

        private void preOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {
                buffer += tree.Data.ToString() + " , ";
                preOrder(tree.Left, ref buffer);           
                preOrder(tree.Right, ref buffer);
            }
        }


        public void postOrder(ref string buffer)    //display 
        {
            postOrder(root, ref buffer);
        }

        private void postOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)
            {
                postOrder(tree.Left, ref buffer);           
                postOrder(tree.Right, ref buffer);
                buffer += tree.Data.ToString() + " , ";

            }
        }



















    }
}
