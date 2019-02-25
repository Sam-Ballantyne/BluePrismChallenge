using Microsoft.VisualStudio.TestTools.UnitTesting;
using BluePrism.Services;

namespace BluePrismTesting
{
    [TestClass]
    public class WordMatcherTest
    {
        WordMatcher wordMatcher;
        TextFileReader fileReader;

        [TestInitialize]
        public void WordMatcherTestsSetup()
        {
            //Input path to dictionary
            fileReader = new TextFileReader(@"", 4);
            wordMatcher = new WordMatcher("rice", "rift", fileReader);
        }

        [TestMethod]
        public void CheckAllIndexesAreReturnedForTotalMismatchedWord()
        {
            var result = wordMatcher.GetMismatchIndexes("XXXX");
            Assert.AreEqual(4, result.Length);
        }

        [TestMethod]
        public void CheckNoIndexesAreReturnedForIndeticalWord()
        {
            var result = wordMatcher.GetMismatchIndexes("rift");
            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void CheckIndexZeroIsRetunedInPartialMatch()
        {
            var result = wordMatcher.GetMismatchIndexes("rxft");
            Assert.AreEqual(1, result[0]);
        }

        [TestMethod]
        public void CheckTreeIsReturnedForWordWithManyOffByOneIndexMatches()
        {
            var result = wordMatcher.Run();
            Assert.AreNotEqual(0, result.Next.Count);
        }

        [TestMethod]
        public void CheckNoTreeIsReturnedForWordWithNoMatches()
        {
            var dodgyWordMatcher = new WordMatcher("FFFF", "XXXX", fileReader);
            var result = dodgyWordMatcher.Run();
            Assert.AreEqual(0, result.Next.Count);
        }
    }
}
