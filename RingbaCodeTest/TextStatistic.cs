using System;
using System.Collections.Generic;
using System.Text;

namespace RingbaCodeTest
{
    public class TextStatistic
    {
        /// <summary>
        /// Calculate all letters
        /// </summary>
        public Dictionary<char, int> Letters { get; set; }

        /// <summary>
        /// Calculate all words
        /// </summary>
        private Dictionary<string, int> words = new Dictionary<string, int>();

        /// <summary>
        /// Calculate all prefexis
        /// </summary>
        private Dictionary<string, int> prefixes = new Dictionary<string, int>();

        /// <summary>
        /// Buffer to concatenate chars to a string. 
        /// </summary>
        private StringBuilder word = new StringBuilder("", 20);

        /// <summary>
        /// Calculate how many capitalized letter
        /// </summary>
        public int CapitalizedLetter { get; set; }

        /// <summary>
        /// Contain common letter item after calculating statistic
        /// </summary>
        public KeyValuePair<char, int> CommonLetter { get; set; }

        /// <summary>
        /// Contain common word item after calculating statistic
        /// </summary>
        public KeyValuePair<string, int> CommonWord { get; set; }

        /// <summary>
        /// Contain common prefix item after calculating statistic
        /// </summary>
        public KeyValuePair<string, int> CommonPrefix { get; set; }

        public TextStatistic()
        {
            Letters = new Dictionary<char, int>();
            CapitalizedLetter = 0;
        }

        /// <summary>
        /// Adding a next char for analize
        /// </summary>
        /// <param name="letter">Next letter from a text file or string</param>
        public void AddNextChar(char letter)
        {
            ProcessWords(letter);
            IncForCapitalizedLetter(letter);
            IncrementForExistKey(Letters, letter);
        }

        /// <summary>
        /// Calculate common words and prefix
        /// </summary>
        /// <param name="letter"></param>
        protected void ProcessWords(char letter)
        {
            if (CapitalizedLetter > 0 && char.IsUpper(letter))
            {
                var wordAsString = word.ToString();
                if (wordAsString.Length > 2)
                {
                    IncrementForExistKey(prefixes, wordAsString.Substring(0, 2));
                }
                IncrementForExistKey(words, wordAsString);
                word.Clear();
            }
            word.Append(char.ToLower(letter));
        }

        /// <summary>
        /// counting capitalized letters
        /// </summary>
        /// <param name="letter"></param>
        protected void IncForCapitalizedLetter(char letter)
        {
            if (char.IsUpper(letter))
            {
                CapitalizedLetter++;
            }
        }

        /// <summary>
        /// Increment value of an item in a dictionary. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        protected void IncrementForExistKey<T>(IDictionary<T, int> dict, T key)
        {
            int value = 0;
            if (dict.TryGetValue(key, out value))
            {
                dict[key]++;
            }
            else
            {
                dict.Add(key, 1);
            }
        }


        /// <summary>
        /// Travers a dictionary and find an item with max value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dict"></param>
        /// <returns></returns>
        protected KeyValuePair<T, int> CalculateMaxValue<T>(IDictionary<T, int> dict)
        {
            KeyValuePair<T, int> max = new KeyValuePair<T, int>();
            foreach (var item in dict)
            {
                if (item.Value > max.Value)
                {
                    max = item;
                }
            }
            return max;
        }

        /// <summary>
        /// Calculate Statistic about text
        /// </summary>
        public void calculateStatistic()
        {
            CommonLetter = CalculateMaxValue(Letters);
            CommonWord = CalculateMaxValue(words);
            CommonPrefix = CalculateMaxValue(prefixes);
        }
    }
}
