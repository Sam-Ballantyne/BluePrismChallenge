using Microsoft.VisualStudio.TestTools.UnitTesting;
using BluePrism.Services;

namespace BluePrismTesting
{
    [TestClass]
    public class WordCheckerTests
    {
        [TestMethod]
        public void TestTwoIndeticalWordsReturnsFalse()
        {
            var wordChecker = new WordChecker("nice");
            Assert.IsFalse(wordChecker.CheckIfDiffersByOneIndex("nice"));
        }

        [TestMethod]
        public void TestWordsWhichDifferByOneIndexReturnsTrue()
        {
            var wordChecker = new WordChecker("ONE");
            Assert.IsTrue(wordChecker.CheckIfDiffersByOneIndex("ONT"));
        }

        [TestMethod]
        public void TestWordsWhichDifferByMoreThanOneIndexReturnsFalse()
        {
            var wordChecker = new WordChecker("Two");
            Assert.IsFalse(wordChecker.CheckIfDiffersByOneIndex("Pop"));
        }

        [TestMethod]
        public void TestWordsOfDifferentLengthsReturnFalse()
        {
            var wordChecker = new WordChecker("AMassiveWord");
            Assert.IsFalse(wordChecker.CheckIfDiffersByOneIndex("Yup"));
        }
    }
}
