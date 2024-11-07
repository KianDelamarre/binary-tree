using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5
{
    class AVLTree<T> : BSTree<T> where T : IComparable
    {
        public new void insertItem(T item)
        {
            insertItem(item, ref root);
        }

        private new void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                tree = new Node<T>(item);
            else if (item.CompareTo(tree.Data) < 0)
                insertItem(item, ref tree.Left);
            else if (item.CompareTo(tree.Data) > 0)
                insertItem(item, ref tree.Right);
            tree.BalanceFactor = Height(tree.Left) - Height(tree.Right);
            if (tree.BalanceFactor <= -2)
                rotateLeft(ref tree);
            if (tree.BalanceFactor >= 2)
                rotateRight(ref tree);

        }

        public void removeItem(T item)
        {
            removeItem(item, ref root);
        }

        private void removeItem(T item, ref Node<T> tree)
        {
            if (Contains(item))
            {

            }

        }

        private void rotateLeft(ref Node<T> tree)
        {
            if (tree.Right != null && tree.Right.BalanceFactor > 0)  //double rotate
                rotateRight(ref tree.Right);
            Node<T> oldRoot = tree;
            Node<T> newRoot = tree.Right;
            Node<T> rightLeft = tree.Right.Left;

            tree = newRoot;
            tree.Left = oldRoot;
            tree.Left.Right = rightLeft;

        }

        private void rotateRight(ref Node<T> tree)
        {
            if (tree.Left != null && tree.Left.BalanceFactor < 0)  //double rotate
                rotateLeft(ref tree.Left);
            Node<T> oldRoot = tree;
            Node<T> newRoot = tree.Left;
            Node<T> LeftRight = tree.Left.Right;

            tree = newRoot;
            tree.Right = oldRoot;
            tree.Right.Left = LeftRight;
        }

    }

}
