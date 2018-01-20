using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTrie.Trie
{
    class Node
    {
        public Node()
        {
            IsTerminal = false;
            childNodes = new Dictionary<char, Node>();
        }
        public char Letter { get; set; }
        public bool IsTerminal { get; set; }
        private Dictionary<char, Node> childNodes { get; set; }

        public IEnumerable<char> GetChildKeys()
        {
            if(childNodes != null)
                return childNodes.Keys;
            
            return new List<char>();
        }

        public Node GetNode(char key)
        {
            if (childNodes != null && childNodes.ContainsKey(key))
                return childNodes[key];

            return null;
        }

        public void AddWord(string word)
        {
            var root = this;
            // todo : implement addition logic
            AddWord(root, word, 0);
        }

        private void AddWord(Node root, string word, int idx)
        {

            /*if (idx == word.Length - 1)
            {
                root.IsTerminal = true;
                return;
            }*/

            char key = word[idx];
            if (!root.childNodes.ContainsKey(key))
            {
                var nextNode = new Node() {Letter = key};
                if (idx == word.Length - 1)
                {
                    nextNode.IsTerminal = true;
                }

                root.childNodes.Add(key, nextNode);
            }

            if (idx == word.Length - 1)
            {
                //root.IsTerminal = true;
                return;
            }

            // else
            AddWord(root.childNodes[key], word, idx + 1);
        }
    }
}
