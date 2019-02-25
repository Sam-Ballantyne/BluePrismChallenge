using BluePrism.Model;
using System.Collections.Generic;

namespace BluePrism.Services
{
    public class InputHandler
    {
        private string resultName;

        private string startWord;

        private string endWord;

        private TextFileReader fileReader;

        public InputHandler(string dictionaryName, string resultName, string startWord, string endWord)
        {
            this.resultName = resultName;
            this.endWord = endWord.ToUpper();
            this.startWord = startWord.ToUpper();
            fileReader = new TextFileReader(dictionaryName, 4);
        }

        public string Run()
        {
            if (!CheckWordsExist(startWord, endWord))
            {
                return "The words could not be found in the dictionary";
            }
            if (!CheckWordsAreOfLength(startWord, endWord, 4))
            {
                return "The words are not of length 4";
            }

            var wordMatcher = new WordMatcher(startWord, endWord, fileReader);
            var result = wordMatcher.Run();
            var path = new ShortestPath();
            var shortestPath = path.GetShortestPath(new List<Word>() { result }, endWord);
            var formattedResult = FormatResult(shortestPath);
            SaveToFile(formattedResult);
            return formattedResult;
        }

        private bool CheckWordsExist(string wordOne, string wordTwo)
        {
            return fileReader.DoesWordExist(wordOne) && fileReader.DoesWordExist(wordTwo);
        }

        private bool CheckWordsAreOfLength(string wordOne, string wordTwo, int length)
        {
            if (wordOne.Length == length && wordTwo.Length == length) {
                return true;
            }
            return false;
        }

        private string FormatResult(List<Word>words)
        {
            if (words == null || words.Count == 0)
                return "Solution cannot be found in this dictionary";
            var toReturn = string.Empty;
            foreach (var word in words)
                toReturn += word.word + "\n";

            return toReturn;
        }

        private void SaveToFile(string output)
        {
            System.IO.File.WriteAllText(resultName, output);
        }
    }
}
