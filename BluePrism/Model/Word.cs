using System.Collections.Generic;

namespace BluePrism.Model
{
    public class Word
    {
        public string word { get; }

        public Word previous { get; set; }

        public List<Word> Next { get; set; }

        public Word(string word, Word next = null, Word previous = null)
        {
            this.word = word;
            Next = new List<Word>();
        }

        public Word GetParent()
        {
            if (previous != null)
                return previous.GetParent();
            return this;
        }
    }
}
