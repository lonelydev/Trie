namespace Trie.Search
{
    public class RecursiveSearchStrategy : ITrieSearchStrategy
    {
        /// <summary>
        /// The recursive search strategy is very similar to the 
        /// recursive inserts. 
        /// Instead of doing an insert we just check return either the 
        /// current nodes EndOfWord flag or a false if the char is not found.
        /// </summary>
        /// <param name="tNode"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exists(TrieNode tNode, string word)
        {
            return Exists(tNode, word, 0);
        }

        private bool Exists(TrieNode tNode, string word, int index)
        {
            if (index == word.Length)
            {
                //return true of current's endOfWord is true else return false.
                return tNode.EndOfWord;
            }
            TrieNode nextNode;
            tNode.Children.TryGetValue(word[index], out nextNode);
            //if node does not exist for given char then return false
            if (nextNode == null)
            {
                return false;
            }
            return Exists(nextNode, word, ++index);
        }
    }
}
