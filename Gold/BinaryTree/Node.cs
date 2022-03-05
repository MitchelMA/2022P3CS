using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Node
    {
        public Node Left { get; set; } = null;
        public Node Right { get; set; } = null;
        public int Value { get; }

        public Node(int value)
        {
            Value = value;
        }
        public void Insert(int value)
        {
            if (this != null)
            {
                if (value < this.Value)
                {
                    if (this.Left == null)
                        this.Left = new(value);
                    else this.Left.Insert(value);
                }
                else if (value > this.Value)
                {
                    if (this.Right == null)
                        this.Right = new(value);
                    else this.Right.Insert(value);
                }
            }
        }
        /// <summary>
        /// Method to display the Contents
        /// </summary>
        public void Display()
        {
            if(this != null)
            {
                if(this.Left != null)
                    this.Left.Display();
                Console.WriteLine(Value);
                if(this.Right !=null)
                    this.Right.Display();
            }
        }
        /// <summary>
        /// Method to convert the contents to an integer list
        /// This is only possible because a "List" is a reference type
        /// </summary>
        /// <param name="inlist">list which will contain the contents</param>
        public void Search(List<int> inlist)
        {
            if(Left != null)
                Left.Search(inlist);
            if (this != null)
                inlist.Add(this.Value);
            if (Right != null)
                Right.Search(inlist);
        }
    }
}
