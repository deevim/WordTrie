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
        static string secodWord = "";
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
            Console.WriteLine("Second Largest Composite Word : " + secodWord);
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

                    if (maxWord == secodWord)
                    {
                        maxWord = currentWord;
                    }

                    if (String.IsNullOrWhiteSpace(secodWord) && currentWord.Length < maxWord.Length)
                    {
                        secodWord = currentWord;
                    }

                    if (currentWord.Length > maxWord.Length)
                    {
                        secodWord = maxWord;
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
