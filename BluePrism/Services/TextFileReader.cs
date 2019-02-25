using System.Linq;

namespace BluePrism.Services
{
    public class TextFileReader
    {
        private string fileName;

        private string[] words;

        public TextFileReader(string fileName, int wordLength)
        {
            this.fileName = fileName;
            words = System.IO.File.ReadAllLines(this.fileName).Where(x => x.Length == wordLength).ToArray();
        }

        public bool DoesWordExist(string word)
        {
            foreach (var line in words)
            {
                if (line.ToUpper() == word.ToUpper())
                    return true;
            }
            return false;
        }

        public string[] GetWordsWhichDifferByOneIndex(string word)
        {
            var wordWrapped = new WordChecker(word);
            var result = words.Where(x => wordWrapped.CheckIfDiffersByOneIndex(x)==true);
            return result.ToArray();
        }
    }
}
