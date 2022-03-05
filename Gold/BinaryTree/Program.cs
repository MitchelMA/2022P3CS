using System;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // create an empty binary tree node
            Node root = new(10);
            // insert values to the root to create a tree
            root.Insert(20);
            root.Insert(9);
            root.Insert(1);
            root.Insert(2);
            root.Insert(21);
            root.Insert(19);
            root.Insert(11);
            root.Insert(18);
            root.Insert(100);
            root.Insert(8);
            root.Insert(90);
            root.Insert(80);
            // As you'll notice, the tree will still only contain one entry with a value of "2".
            // A branch of a tree with this structure will not allow duplicates.
            // A tree-branch is also ordered from low to high 
            root.Insert(2);
            // I can create duplicates by doing this, however:
            root.Right.Insert(2);

            // print out the binary tree
            root.Display();
            Console.WriteLine();

            // how it will be organized in the tree (order in wich content was inserted plays a very important role here):
            Console.WriteLine(root.Left.Left.Value);                   // 1
            Console.WriteLine(root.Left.Left.Right.Value);             // 2
            Console.WriteLine(root.Left.Left.Right.Right.Value);       // 8
            Console.WriteLine(root.Left.Value);                        // 9
            Console.WriteLine(root.Value);                             // 10
            Console.WriteLine(root.Right.Left.Left.Left.Value);        // 2
            Console.WriteLine(root.Right.Left.Left.Value);             // 11
            Console.WriteLine(root.Right.Left.Left.Right.Value);       // 18
            Console.WriteLine(root.Right.Left.Value);                  // 19
            Console.WriteLine(root.Right.Value);                       // 20
            Console.WriteLine(root.Right.Right.Value);                 // 21
            Console.WriteLine(root.Right.Right.Right.Left.Left.Value); // 80
            Console.WriteLine(root.Right.Right.Right.Left.Value);      // 90
            Console.WriteLine(root.Right.Right.Right.Value);           // 100
            Console.WriteLine();

            // create an empty list
            List<int> treeList = new List<int>();
            // fill the list with the tree-contents
            root.Search(treeList);
            // print the contents of the list
            foreach(int x in treeList)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            // create an empty Node-list
            List<Node> treeNodes = new List<Node>();
            // fill the list with the treenodes
            root.Search(treeNodes);
            // print the contents of the list
            foreach(Node x in treeNodes)
            {
                Console.WriteLine(x.Value);
            }
        }
    }
}
