using System;
using System.Collections.Generic;

namespace Day008
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree("1", new Tree("1"), new Tree("1", new Tree("1", new Tree("1"), new Tree("1")), new Tree("0")));
            System.Console.WriteLine(Tree.NumberOfUniValTree(tree).Item1);
        }
    }

    class Tree
    {
        string value;
        Tree left;
        Tree right;

        public Tree(string value, Tree left = null, Tree right = null)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        static public Tuple<int, string> NumberOfUniValTree(Tree tree)
        {
            string value = tree.value;

            if (tree.left == null && tree.right == null)
            {
                return new Tuple<int, string>(1, value);
            }
            else if(tree.left != null && tree.right == null)
            {
                Tuple<int, string> left = NumberOfUniValTree(tree.left);
                if (left.Item2 != null)
                {
                    if (value == left.Item2)
                    {
                        return new Tuple<int, string>(left.Item1 + 1, value);
                    }
                    else
                    {
                        return new Tuple<int, string>(left.Item1, null);
                    }
                }
                else
                {
                    return new Tuple<int, string>(left.Item1, null);
                }
            }
            else if (tree.left == null && tree.right != null)
            {
                Tuple<int, string> right = NumberOfUniValTree(tree.right);
                if (right.Item2 != null)
                {
                    if (value == right.Item2)
                    {
                        return new Tuple<int, string>(right.Item1 + 1, value);
                    }
                    else
                    {
                        return new Tuple<int, string>(right.Item1, null);
                    }
                }
                else
                {
                    return new Tuple<int, string>(right.Item1, null);
                }
            }
            else
            {
                Tuple<int, string> left = NumberOfUniValTree(tree.left);
                Tuple<int, string> right = NumberOfUniValTree(tree.right);
                if (left.Item2 != null && right.Item2 != null)
                {
                    if (value == left.Item2 && value == right.Item2)
                    {
                        return new Tuple<int, string>(left.Item1 + right.Item1 + 1, value);
                    }
                    else
                    {
                        return new Tuple<int, string>(left.Item1 + right.Item1, null);
                    }
                }
                else
                {
                    return new Tuple<int, string>(left.Item1 + right.Item1, null);
                }
            }
        }
    }
}
