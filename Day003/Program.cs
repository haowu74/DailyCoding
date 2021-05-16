using System;

namespace Day003
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node = new Node("root", new Node("left", new Node("left.left"), new Node("left.right")), new Node("right"));
            string s = Node.Serialize(node);
            System.Console.WriteLine(s);
            System.Console.WriteLine(Node.Deserialize(s)?.left?.right?.value);
        }
    }

    class Node
    {
        public string value;
        public Node left;
        public Node right;
        public Node(string value, Node left = null, Node right = null)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public static string Serialize(Node node)
        {
            if (node.left == null && node.right == null)
            {
                return $"({node.value}()())";
            }
            else if(node.left != null && node.right == null)
            {
                return $"({node.value}{Node.Serialize(node.left)}())";
            }
            else if(node.left == null && node.right != null)
            {
                return $"({node.value}(){Node.Serialize(node.right)})";
            }
            else
            {
                return $"({node.value}{Node.Serialize(node.left)}{Node.Serialize(node.right)})";
            }
        }

        public static Node Deserialize(string nodeString)
        {
            var openBracket = nodeString.IndexOf("(");
            var closeBracket = nodeString.LastIndexOf(")");
            var leftOpenBracket = nodeString.IndexOf("(", openBracket + 1);
            var rightCloseBracket = nodeString.LastIndexOf(")", closeBracket - 1);
            if(leftOpenBracket == -1 || rightCloseBracket == -1)
            {
                return null;
            }
            var value = nodeString.Substring(openBracket+1, leftOpenBracket-openBracket-1);
            Node node = new Node(value);
            int match = 1;
            int leftCloseBracket = -1;
            int rightOpenBracket = -1;
            for(int n = leftOpenBracket+1; n < rightCloseBracket; n++)
            {
                if (nodeString[n] == '(')
                {
                    if(match == 0)
                    {
                        rightOpenBracket = n;
                    }
                    match++;
                }
                else if(nodeString[n] == ')')
                {
                    match--;
                    if(match == 0)
                    {
                        leftCloseBracket = n;
                    }
                }
            }
            string leftNodeString = nodeString.Substring(leftOpenBracket, leftCloseBracket-leftOpenBracket+1);
            string rightNodeString = nodeString.Substring(rightOpenBracket, rightCloseBracket-rightOpenBracket+1);
            node.left = Node.Deserialize(leftNodeString);
            node.right = Node.Deserialize(rightNodeString);
            return node;
        }
    }
}
