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

        protected void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                tree = new Node<T>(item);

            else if (item.CompareTo(tree.Data) < 0)
                insertItem(item, ref tree.Left);

            else if (item.CompareTo(tree.Data) > 0)
                insertItem(item, ref tree.Right);
        }

        public void removeItem(T item)
        {
            removeItem(item, ref root);
        }

        protected void removeItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                return;

            //if (item.CompareTo(tree.Data) != 0)      //ive left this in to show what i had originally
            //{                                        //this is quite innefficient as it will recurse all the way down the left first, but this is pointless because if 
            //    removeItem(item, ref tree.Left);     //the item im looking for is larger than the root, i can just recurse down the right, and if its smaller than the root,
            //    removeItem(item, ref tree.Right);    //just recurse down the right and not the left
            //}

            if (item.CompareTo(tree.Data) < 0)
            {
                removeItem(item, ref tree.Left); 
            }

            else if (item.CompareTo(tree.Data) > 0)
            {
                removeItem(item, ref tree.Right);
            }

            else if (item.CompareTo(tree.Data) == 0)
            {
                ///    case 1 no child    ////////////////////////////////////////////////////////////////
                if (tree.Right == null && tree.Left == null)
                {
                    tree = null;    
                }
                ///    case 2.1 one child to the right     ///////////////////////////////////////////////
                else if (tree.Right != null && tree.Left==null)
                {
                    Node<T> newRoot = tree.Right;
                    tree = newRoot;
                }
                ///    case 2.2 one child to the left     ////////////////////////////////////////////////
                else if (tree.Right == null && tree.Left != null)
                {
                    Node<T> newRoot = tree.Left;
                    tree = newRoot;                
                }

                ///    case case 3  2 children             ///////////////////////////////////////////////
                else if (tree.Right != null && tree.Left != null)
                {
                    //Node<T> newRoot = retrieveSmallest(tree.Right);
                    //tree.Data = newRoot.Data;


                    Node<T> newRootParent = tree;   //newRootParent needs to be tree because newRoot could be the direct right child of tre
                    Node<T> newRoot = tree.Right;   

                    while (newRoot.Left != null)   //while loop to keep track of new root (left most node to the right of the the item to be removed
                    {                              //and also keeps track of its parent which is needed later 
                        newRootParent = newRoot;  
                        newRoot = newRoot.Left;
                    }

                    tree.Data = newRoot.Data;      //overwrite data of item being removed with newRood.Data

                    if (newRoot.Right != null)     //if new root has a right child
                    {
                        if (newRoot == tree.Right)
                        //if (tree.Data.CompareTo(newRootParent.Data)==0)
                        {
                            newRootParent.Right = newRoot.Right;
                        }

                        else
                        {
                            newRootParent.Left = null;   //replace newRoot with newRoot.Right by changing parents Left
                        }
                    }
                    else   //when newRoot has no Right child
                    {
                        if (newRoot == tree.Right)
                        //if (tree.Data.CompareTo(newRootParent.Data)==0)
                        {
                            newRootParent.Right = null;
                        }
                        //newRootParent.Right = null;    //just set newRootParent.Left to null as there is nothing to the left of it now
                        else
                            newRootParent.Left = null;
                    }
                    




                    //if (newRoot.Right != null)
                    //{
                    //    //tree.Right = newRoot.Right;
                    //    newRoot.Data = newRoot.Right.Data;
                    //    newRoot.Right = null;

                    //}
                    //else if (newRoot.Right == null)
                    //{
                    //    newRoot = null;
                    //}
                }
            }
        }

        protected Node<T> retrieveSmallest(Node<T> tree)   //retieveSmallest function to return the leftmost leaf node of a given tree for use in removeItem method
        {
            if(tree == null)
            {
                return null;
            }
            if (tree.Left == null )
                return tree;
            return (retrieveSmallest(tree.Left));
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
