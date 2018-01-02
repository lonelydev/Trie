namespace Trie
{
    /// <summary>
    /// An interface to declare the methods that 
    /// we wish to expose via our Trie.     
    /// </summary>
    public interface ITrie
    {
        void Insert(string word);
        bool Delete(string word);
        bool Exists(string word);
    }
}
