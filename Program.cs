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


            Console.ReadLine();

        }
    }
}
