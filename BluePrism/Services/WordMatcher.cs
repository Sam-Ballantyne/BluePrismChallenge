using System.Collections.Generic;
using System.Linq;
using BluePrism.Model;

namespace BluePrism.Services
{
    public class WordMatcher
    {
        private TextFileReader fileReader;

        private string startWord;

        private string endWord;

        public WordMatcher(string startWord, string endWord, TextFileReader fileReader)
        {
            this.startWord = startWord.ToUpper();
            this.endWord = endWord.ToUpper();
            this.fileReader = fileReader;
        }

        public int[] GetMismatchIndexes(string word)
        {
            var result = new List<int>();
            for (int x = 0; x < word.Length; x++)
            {
                if (word.ToUpper()[x] != endWord.ToUpper()[x])
                    result.Add(x);
            }
            return result.ToArray();
        }

        public Word Run()
        {
            var startWord = CompleteWords(new Word(this.startWord));
            return startWord;
        }

        private List<string> GetNextMatches(string word)
        {
            var mismatches = GetMismatchIndexes(word);
            var matches = fileReader.GetWordsWhichDifferByOneIndex(word);
            var bestMatches = new List<string>();
            foreach (var match in matches)
            {
                if (!(GetMismatchIndexes(match).Length >= mismatches.Length))
                    bestMatches.Add(match);
            }
            if (bestMatches.Count > 0)
            {
                int min = bestMatches.Min(x => GetMismatchIndexes(x).Length);
                return bestMatches.Where(x => GetMismatchIndexes(x).Length == min).ToList();
            }
            return new List<string>();
        }

        private Word CompleteWords(Word word)
        {
            var matches = GetNextMatches(word.word);
            if (matches.Count > 0)
            {
                foreach (var match in matches)
                {
                    var newWord = new Word(match.ToUpper(), null, word);
                    word.Next.Add(newWord);
                    CompleteWords(newWord);
                }
            }
            return word.GetParent();
            
        }
    }
}
