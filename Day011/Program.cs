using System;
using System.Collections.Generic;
using System.Linq;

namespace Day011
{
    class Program
    {
        List<string> words = new List<string>();

        static void Main(string[] args)
        {
            var program = new Program();
            foreach (var word in args)
            {
                program.words.Add(word);
            }
            DictionaryTree tree = program.initDictionary(program.words);
            // System.Console.WriteLine(tree.children[0].children[1].node);

            while(true)
            {
                var query = System.Console.ReadLine();
                var results = program.searchDictionary(tree, "", query);
                System.Console.WriteLine(results.Count);
                foreach(var result in results)
                {
                    System.Console.WriteLine(result);
                }
            }
        }

        public DictionaryTree initDictionary(List<string> words)
        {
            var tree = new DictionaryTree();
            foreach(var word in words)
            {
                var currentNode = tree;
                foreach(var letter in word)
                {
                    if (currentNode.children.Count(c => c.node == letter) > 0)
                    {
                        currentNode = currentNode.children.FirstOrDefault(c => c.node == letter);
                    }
                    else
                    {
                        var newNode = new DictionaryTree(letter);
                        currentNode.children.Add(newNode);
                        currentNode = newNode;
                    }
                }
            }
            return tree;
        }

        public List<string> searchDictionary(DictionaryTree tree, string matched, string match)
        {
            if (match.Length == 0)
            {
                if (tree.children.Count > 0)
                {
                    var results = new List<string>();
                    foreach (var child in tree.children)
                    {
                        results.AddRange(searchDictionary(child, matched + child.node.ToString(), ""));
                    }
                    return results;
                }
                else
                {
                    var results = new List<string>();
                    results.Add(matched);
                    return results;
                }
            }
            var found = tree.children.FirstOrDefault(c => c.node == match[0]);
            if (found == null)
            {
                return new List<string>();
            }
            else
            {
                return searchDictionary(found, matched + found.node.ToString(), match.Substring(1));
            }
        }
    }

    class DictionaryTree
    {
        public System.Char node;
        public List<DictionaryTree> children;

        public DictionaryTree(System.Char letter = ' ')
        {
            this.node = letter;
            children = new List<DictionaryTree>();
        }
    }
}
