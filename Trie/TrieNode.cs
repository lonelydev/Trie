using System.Collections.Generic;

namespace Trie
{
    /// <summary>
    /// This is private as we really don't have a need to expose this.        
    /// </summary>
    public class TrieNode
    {
        /// <summary>
        /// character to store char at current node
        /// dictionary to store children with child char as key
        /// is word boolean 
        /// * l => average length of word
        /// * n => total number of words
        /// * Time complexity of Inserts Trie should be O(l* n)
        /// </summary>
        public IDictionary<char, TrieNode> Children { get; set; }
        /// <summary>
        /// bool to mark the end of the inserted word
        /// </summary>
        public bool EndOfWord { get; set; }
        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            EndOfWord = false;
        }

        public TrieNode(bool endOfWord = false)
        {
            Children = new Dictionary<char, TrieNode>();
            EndOfWord = endOfWord;
        }
    }

}
