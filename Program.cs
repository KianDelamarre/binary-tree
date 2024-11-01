using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<int> test = new Node<int>(6);
            test.Left = new Node<int>(2);
            test.Left.Right = new Node<int>(5);

            BinTree<int> testTree = new BinTree<int>(test);

            string buffer = "";
            testTree.inOrder(ref buffer);
            Console.WriteLine(buffer);

            buffer = "";
            testTree.preOrder(ref buffer);
            Console.WriteLine(buffer);

            buffer = "";
            testTree.postOrder(ref buffer);
            Console.WriteLine(buffer);    


            BSTree<string> BSTreetest = new BSTree<string>();
            BSTreetest.insertItem("d");
            BSTreetest.insertItem("f");
            BSTreetest.insertItem("b");
            BSTreetest.insertItem("e");

            BSTree<string> BSTree1 = new BSTree<string>();
            BSTree1.insertItem("d");
            BSTree1.insertItem("f");
            BSTree1.insertItem("b");
            BSTree1.insertItem("e");
            BSTree1.insertItem("x");




            buffer = "";
            BSTreetest.inOrder(ref buffer);
            Console.WriteLine(buffer);

            buffer = "";
            BSTreetest.preOrder(ref buffer);
            Console.WriteLine(buffer);

            buffer = "";
            BSTreetest.postOrder(ref buffer);
            Console.WriteLine(buffer);

            Console.WriteLine(BSTreetest.Height());
            Console.WriteLine(BSTreetest.Count());
            Console.WriteLine(BSTreetest.Contains("d"));
            Console.WriteLine(BSTreetest.Contains("x"));
            Console.WriteLine(BSTreetest.Equals(BSTree1));





            Console.ReadLine();

        }
    }
}
