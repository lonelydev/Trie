using NUnit.Framework;
using Trie.Insert;
using Trie.Search;

namespace TrieTester
{
    [TestFixture]
    public class TrieTest
    {
        [Test]
        public void TrieInsertTestDefault()
        {
            //default Trie would be created with Iterative Strategies
            var trie = new Trie.Trie();
            trie.Insert("ab");
            trie.Insert("abc");
            trie.Insert("abcd");
            trie.Insert("abcdefg");
            trie.Insert("abcde");
            trie.Insert("ilu");
            Assert.IsTrue(trie.Exists("abcd"));
            Assert.IsFalse(trie.Exists("af"));
            Assert.IsFalse(trie.Exists("i"));
            Assert.IsTrue(trie.Exists("ilu"));
            trie.Delete("ilu");
            Assert.IsFalse(trie.Exists("ilu"));
            trie.Delete("abc");
            Assert.IsTrue(trie.Exists("abcd"));
            Assert.IsFalse(trie.Exists("abc"));
        }

        [Test]
        public void TrieInsertTestRecursive()
        {
            //default Trie would be created with Iterative Strategies
            var trie = new Trie.Trie(new RecursiveInsertStrategy(), new RecursiveSearchStrategy());
            trie.Insert("ab");
            trie.Insert("abc");
            trie.Insert("abcd");
            trie.Insert("abcdefg");
            trie.Insert("abcde");
            trie.Insert("ilu");
            Assert.IsTrue(trie.Exists("abcd"));
            Assert.IsFalse(trie.Exists("af"));
            Assert.IsFalse(trie.Exists("i"));
            Assert.IsTrue(trie.Exists("ilu"));
            trie.Delete("ilu");
            Assert.IsFalse(trie.Exists("ilu"));
            trie.Delete("abc");
            Assert.IsTrue(trie.Exists("abcd"));
            Assert.IsFalse(trie.Exists("abc"));
        }
    }
}
