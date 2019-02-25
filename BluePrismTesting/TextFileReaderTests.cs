using Microsoft.VisualStudio.TestTools.UnitTesting;
using BluePrism.Services;

namespace BluePrismTesting
{
    [TestClass]
    public class TextFileReaderTests
    {
        TextFileReader fileReader; 

        [TestInitialize]
        public void TextFileReaderTestsSetUp()
        {
            //Put path to text file reader
            fileReader = new TextFileReader(@"", 4);
        }

        [TestMethod]
        public void CheckIfExistingWordReturnsTrue()
        {
            Assert.IsTrue(fileReader.DoesWordExist("Spot"));
        }

        [TestMethod]
        public void CheckIfNonExistingWordReturnsFalse()
        {
            Assert.IsFalse(fileReader.DoesWordExist("IUFHSIUDH"));
        }

        [TestMethod]
        public void CheckResultsAreReturnedForWordWhichHasManyWhichDifferByOneIndex()
        {
            Assert.AreNotEqual(0, fileReader.GetWordsWhichDifferByOneIndex("race").Length);
        }

        [TestMethod]
        public void CheckResultsAreReturnedForWordWhichHasNoWordsWhichDifferByOneIndex()
        {
            Assert.AreEqual(0, fileReader.GetWordsWhichDifferByOneIndex("XXXX").Length);
        }
    }
}
