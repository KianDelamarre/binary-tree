ongoing binary tree in c#

added height() method

here is my explanation of how the height method works

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

        
![Height()-explanation](https://github.com/user-attachments/assets/8f15066b-20f4-4dae-9f11-1be594942ec0)
