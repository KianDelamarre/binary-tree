using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5
{
    internal class Node<T> where T : IComparable
    {
        private T data;
        public Node<T> Left, Right;
        private int balanceFactor;


        public Node(T data)
        {
            this.data = data;
            Left = null;
            Right = null;
        }


        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public int BalanceFactor
        {
            get { return balanceFactor; }
            set { balanceFactor = value; }

        }
    }
}
