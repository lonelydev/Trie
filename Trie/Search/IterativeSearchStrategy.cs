namespace Trie.Search
{
    public class IterativeSearchStrategy : ITrieSearchStrategy
    {
        /// <summary>
        /// The iterative implementation of existence check in a Trie. 
        /// This is very similar to the iterative insertion into a Trie. 
        /// Where we create a new key,value pair for Inserts, 
        /// we just return a boolean for Exists. 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exists(TrieNode tNode, string word)
        {
            var current = tNode;
            for (var index = 0; index < word.Length; index++)
            {
                // insert character in the dictionary.
                if (!current.Children.ContainsKey(word[index]))
                {
                    return false;
                }
                current = current.Children[word[index]];
            }
            // now that we have finished iterating through the word we can mark 
            // the current node as end of word! 
            return current.EndOfWord;
        }
    }
}
