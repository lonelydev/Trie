namespace Trie.Insert
{
    public class RecursiveInsertStrategy : ITrieInsertStrategy
    {
        public void Insert(TrieNode tNode, string word)
        {
            Insert(tNode, word, 0);
        }

        private void Insert(TrieNode tNode, string word, int index)
        {
            if (index == word.Length)
            {
                //if end of word is reached then mark endOfWord as true on current node
                tNode.EndOfWord = true;
                return;
            }
            TrieNode nextNode;
            tNode.Children.TryGetValue(word[index], out nextNode);

            // if the node does not already exist, then create one
            if (nextNode == null)
            {
                nextNode = new TrieNode();
                tNode.Children.Add(word[index], nextNode);
            }
            Insert(nextNode, word, ++index);
        }
    }
}
