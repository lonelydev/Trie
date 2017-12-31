using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    internal class TrieNode
    {
        /*
         * character to store char at current node
         * dictionary to store children with child char as key
         * is word boolean 
         * 
         */
        internal char Character { get; private set; }
        IDictionary<char, TrieNode> children;

    }
}
