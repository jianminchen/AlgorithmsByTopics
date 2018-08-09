using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morris_Traversal_algorithm
{
    /// <summary>
    /// study Morris traversal for preorder
    /// https://www.geeksforgeeks.org/morris-traversal-for-preorder/
    /// August 9, 2018
    /// </summary>
    class BinaryTree
    {
        class Node
        {
            public int  Data;
            public Node Left, Right;

            public Node(int item)
            {
                Data = item;
                Left = Right = null;
            }
        }

        static void Main(string[] args)
        {            
            var tree = new Node(1);
            tree.Left = new Node(2);
            tree.Right = new Node(3);
            tree.Left.Left = new Node(4);
            tree.Left.Right = new Node(5);
            tree.Right.Left = new Node(6);
            tree.Right.Right = new Node(7);
            tree.Left.Left.Left = new Node(8);
            tree.Left.Left.Right = new Node(9);
            tree.Left.Right.Left = new Node(10);
            tree.Left.Right.Right = new Node(11);

            morrisTraversalPreorder(tree);
        
            Console.WriteLine("");            
        }                
 
        // Preorder traversal without recursion and without stack
        static void morrisTraversalPreorder(Node node) {
            while (node != null) {
 
                // If left child is null, print the current node data. Move to
                // right child.
                if (node.Left == null) {
                    Console.WriteLine(node.Data + " ");

                    node = node.Right;
                } else {
 
                    // Find inorder predecessor
                    var current = node.Left;
                    while (current.Right != null && current.Right != node) {
                        current = current.Right;
                    }
 
                    // If the right child of inorder predecessor already points to
                    // this node
                    if (current.Right == node) {
                        current.Right = null;
                        node = node.Right;
                    }
  
                    // If right child doesn't point to this node, then print this
                    // node and make right child point to this node
                    else {
                        Console.WriteLine(node.Data + " ");

                        current.Right = node;
                        node = node.Left;
                    }
                }
            }
        }                  
    }
}
