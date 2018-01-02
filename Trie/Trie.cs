using Trie.Insert;
using Trie.Search;

namespace Trie
{
    public class Trie : ITrie
    {
        /// <summary>
        /// This determines if we would either of the following :
        ///   * recursive insert
        ///   * iterative insert
        /// </summary>
        private ITrieInsertStrategy insertionStrategy { get; }
        private ITrieSearchStrategy searchStrategy { get; }

        private TrieNode root;

        /// <summary>
        /// Creates a Trie that by default use Iterative Insert and Search strategies
        /// </summary>
        public Trie() : this(new IterativeInsertStrategy(), new IterativeSearchStrategy())
        {                     
        }        

        /// <summary>
        /// Parameterized constructor for consumers to make Tries with a combination of 
        /// Iterative/Recursive insert and search strategies
        /// </summary>
        /// <param name="insertStrategy"></param>
        /// <param name="searchStrategy"></param>
        public Trie(ITrieInsertStrategy insertStrategy,  ITrieSearchStrategy searchStrategy)
        {
            root = new TrieNode();
            insertionStrategy = insertStrategy;
            this.searchStrategy = searchStrategy;
        }


        public bool IsEmpty()
        {
            return root == null;
        }        

        /// <summary>
        /// The iterative way of inserting a word into a Trie
        /// Insertion as it is done character by character is a pretty 
        /// expensive operation. 
        /// O(l*n)
        /// l => average length of the word
        /// n => number of words to insert
        /// </summary>
        /// <param name="word"></param>
        public void Insert(string word)
        {
            insertionStrategy.Insert(root, word);            
        }

        /// <summary>
        /// Given a word, this method will delete it from the Trie
        /// The logic is as follows:
        ///     Search for the word in the trie. 
        ///     If the whole word exists then check the EndOfWord boolean
        /// at the end. 
        /// </summary>
        /// <param name="word"></param>
        /// <returns> true or false stating whether the word could be deleted</returns>
        public bool Delete(string word)
        {
            return DeleteNode(root, word, 0);
        }

        /// <summary>
        /// This is a recursive function that checks if a node can be deleted from the Trie.
        /// A TrieNode can only be deleted if it has an empty children dictionary
        /// if not empty then all you can do is set EndOfWord to false.
        /// </summary>
        /// <param name="currentTrieNode">The node in question</param>
        /// <param name="word">The word to be deleted</param>
        /// <param name="index">The index of the element</param>
        /// <returns>true or false stating wehther the node can be deleted</returns>
        private bool DeleteNode(TrieNode currentTrieNode, string word, int index)
        {
            // base condition is when the index is equal to the length of the word
            // then determine if this node should be deleted or not
            // else all you can do is mark endOfWord as false
            if (index == word.Length)
            {
                // if this isn't the end of a word then clearly 
                // the word doesn't exist in the trie
                if (!currentTrieNode.EndOfWord)
                    return false; //that is you cannot delete

                currentTrieNode.EndOfWord = false;

                // only delete when children are empty else you'll destroy everything
                // else in the chain further
                return currentTrieNode.Children.Count == 0;
            }

            // now that we have dealt with the base case, let us go ahead with the rest.
            // So looking at cases where index < word.Length
            bool shouldDeleteNode;
            // if Children dictionary has the character that we are concerned at the moment
            // then recursively call this method on the node corresponding to that character
            if (currentTrieNode.Children.ContainsKey(word[index]))
            {
                var nextTrieNode = currentTrieNode.Children[word[index]];
                shouldDeleteNode = DeleteNode(nextTrieNode, word, index + 1);
            }
            else
            {
                // the character is not present in the trie so 
                // all you can do is say false - cannot delete
                return false;
            }

            // if the character's node can be deleted then rejoice!
            // go ahead and remove the character and its corresponding 
            // TrieNode (the key value pair) from the dictionary
            // then do a check of current node's children, could this node 
            // also be deleted?
            if (shouldDeleteNode)
            {
                currentTrieNode.Children.Remove(word[index]);
                return currentTrieNode.Children.Count == 0; // if true then this one can also be deleted!
            }
            // now if you haven't been able to return true anywhere earlier, then all you can do is
            // return a false. You can't delete the node.
            return false;
        }

        ///// <summary>
        ///// There are two main types of searches using a Trie
        ///// Prefix search and whole word search.
        ///// Prefix search is what is mostly used for auto complete apis
        ///// 
        ///// </summary>
        ///// <param name="word"></param>
        ///// <returns></returns>
        //public IEnumerable<string> Search(string word)
        //{
        //    return new List<string>();
        //}

        public bool Exists(string word)
        {
            return searchStrategy.Exists(root, word);
        }
    }
}
