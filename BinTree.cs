﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week5;

namespace week5
{
    class BinTree<T> where T : IComparable
    {
        protected Node<T> root;
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

        public int Height()
        {          
            return Height(root);       
        }


        
        private int Height(Node<T> tree)          //Return the max level of the tree
        {
            if (tree == null)
                return -1;

            int HLeft = Height(tree.Left);
            int HRight = Height(tree.Right);

            int height;
            if(HLeft > HRight)
            {
                height = HLeft;
            }
            else
            {
                height = HRight;
            }

            return height + 1;
        }

        public int Count()
        {
            return Count(root);
        }



        private int Count(Node<T> tree)          //Return the number of nodes in the tree
        {
            if (tree == null)
                return 0;
            
            int HLeft = Count(tree.Left);        //recurse left
            int HRight = Count(tree.Right);      //recure right

            return HLeft + HRight + 1; ;         //once recured left and right, add left and right and + 1 for current node
        }



















    }
}


