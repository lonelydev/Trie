namespace Trie.Search
{
    public interface ITrieSearchStrategy
    {
        bool Exists(TrieNode tNode, string word);
    }
}
