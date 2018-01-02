namespace Trie.Insert
{
    public class IterativeInsertStrategy : ITrieInsertStrategy
    {
        public void Insert(TrieNode tNode, string word)
        {
            var current = tNode;
            for (var index = 0; index < word.Length; index++)
            {
                // insert character in the dictionary.
                if (!current.Children.ContainsKey(word[index]))
                {
                    current.Children.Add(word[index], new TrieNode());
                }
                current = current.Children[word[index]];
            }
            // now that we have finished iterating through the word we can mark 
            // the current node as end of word! 
            current.EndOfWord = true;
        }
    }
}
