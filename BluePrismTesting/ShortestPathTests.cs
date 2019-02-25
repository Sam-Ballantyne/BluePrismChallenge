using Microsoft.VisualStudio.TestTools.UnitTesting;
using BluePrism.Services;
using BluePrism.Model;
using System.Collections.Generic;

namespace BluePrismTesting
{
    [TestClass]
    public class ShortestPathTests
    {
        ShortestPath shortestPath;

        [TestInitialize]
        public void ShortestPathTestsSetUp()
        {
            shortestPath = new ShortestPath();
        }

        [TestMethod]
        public void TestPathWithOnlyOnePathToResultIsReturned()
        {
            var wordOne = new Word("one");
            var wordTwo = new Word("two", null, wordOne);
            var wordThree = new Word("three", null, wordTwo);
            wordOne.Next.Add(wordTwo);
            wordTwo.Next.Add(wordThree);

            var result = shortestPath.GetShortestPath(new List<Word>() { wordOne }, "three");
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void TestPathWithMultiplePathsCorrectResultIsReturned()
        {
            var wordOne = new Word("one");
            var wordTwo = new Word("two", null, wordOne);
            var wordThree = new Word("three", null, wordTwo);
            wordOne.Next.Add(wordTwo);
            wordTwo.Next.Add(wordThree);
            var wordFour = new Word("four", null, wordOne);
            wordOne.Next.Add(wordFour);
            var wordFive = new Word("five", null, wordFour);
            wordFour.Next.Add(wordFive);
            var wordSix = new Word("three", null, wordFive);
            wordFive.Next.Add(wordSix);

            var result = shortestPath.GetShortestPath(new List<Word>() { wordOne }, "three");
            Assert.AreEqual(3, result.Count);
        }
    }
}
