using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordTrie.Trie;

namespace WordTrie
{
    class Program
    {

        static string maxWord = "";
        static string secondWord = "";
        static int wordCount = 0;

        static void Main(string[] args)
        {
            var root = new Node();

            // add words to trie
            using (var reader = new StreamReader("./wordlist.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if(String.IsNullOrWhiteSpace(line))
                        continue;

                    root.AddWord(line);
                }
            }

            // retrieve longest & second longest words, and count of all words
            TraverseTrie(root, false, "");

            Console.WriteLine("Word Count : " + wordCount);
            Console.WriteLine("Largest Composite Word : " + maxWord);
            Console.WriteLine("Second Largest Composite Word : " + secondWord);
            Console.ReadLine();

        }

        private static void TraverseTrie(Node root, bool isCompositeWord, string currentWord)
        {
            if(root == null)
                return;

            if (root.IsTerminal)
            {
                if (isCompositeWord)
                {
                    wordCount++;

                    if (maxWord == secondWord)
                    {
                        maxWord = currentWord;
                    }

                    if (String.IsNullOrWhiteSpace(secondWord) && currentWord.Length < maxWord.Length)
                    {
                        secondWord = currentWord;
                    }

                    if (currentWord.Length > maxWord.Length)
                    {
                        secondWord = maxWord;
                        maxWord = currentWord;
                    }
                }
            }

            

            foreach (var nodeKey in root.GetChildKeys())
            {
                TraverseTrie(root.GetNode(nodeKey), isCompositeWord || root.IsTerminal, currentWord + root.Letter);
            }
        }
    }
}
