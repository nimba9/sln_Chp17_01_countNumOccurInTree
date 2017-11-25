using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Nakov & co C# book/Chp17 ex01:
//Write a program that finds the number of occurrences of a number
//in a tree of numbers.

namespace nakovChp17_01_countNumOccurInTree
{
    public class TreeNode<T>
    {
        private T value;
        private bool hasParent;
        private List<TreeNode<T>> children;
        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.children.Count;
            }
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            if (child.hasParent)
            {
                throw new ArgumentException("The node already has a parent!");
            }

            child.hasParent = true;
            this.children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.children[index];
        }
    }

    public class Tree<T>
    {
        private TreeNode<T> root;
        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        public TreeNode<T> Root
        {
            get
            {
                return this.root;
            }
        }

       
    }

    public class Program
    {
        static int countOccurance = 0;

        public static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(41, new Tree<int>(41, new Tree<int>(5), new Tree<int>(41), new Tree<int>(15), new Tree<int>(26)), new Tree<int>(41), new Tree<int>(48, new Tree<int>(58), new Tree<int>(71)));
            int num = int.Parse(Console.ReadLine());
            CountOccurNum(tree, num);
            Console.WriteLine(countOccurance);
        }

        static void CountOccurNum(Tree<int> tree, int num)
        {
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();
            stack.Push(tree.Root);

            while (stack.Count > 0)
            {
                TreeNode<int> currNode = stack.Pop();
                for (int i = 0; i < currNode.ChildrenCount; i++)
                {
                    TreeNode<int> childNode = currNode.GetChild(i);
                    if (childNode.Value == num)
                    {
                        countOccurance++;
                    }

                    stack.Push(childNode);
                }
            }

        }




    }
}





    

