namespace BluePrism.Services
{
    public class WordChecker
    {
        public string startWord { get; }

        public WordChecker(string startWord)
        {
            this.startWord = startWord.ToUpper();
        }

        public bool CheckIfDiffersByOneIndex(string word)
        {
            var diff = 0;
            if (word.Length == startWord.Length)
            {
                for (var i = 0; i < word.Length; i++)
                {
                    if (word.ToUpper()[i] != startWord.ToUpper()[i])
                        diff++;
                }
            }
            if (diff == 1)
                return true;
            return false;
        }
    }
}