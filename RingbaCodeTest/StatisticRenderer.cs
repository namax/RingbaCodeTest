using System;
using System.Collections.Generic;
using System.Text;

namespace RingbaCodeTest
{
    class StatisticRenderer
    {
        /// <summary>
        /// A simplest way to render statistic in console
        /// </summary>
        /// <param name="textStatistic"></param>
        public void renderInConsole(TextStatistic textStatistic)
        {
            textStatistic.calculateStatistic();

            foreach (var letter in textStatistic.Letters)
            {
                Console.WriteLine("Letter {0},  repeats {1}", letter.Key, letter.Value);
            }

            Console.WriteLine("Common Letter: {0},  repeats {1}", textStatistic.CommonLetter.Key, textStatistic.CommonLetter.Value);
            Console.WriteLine("Common Word: {0},  repeats {1}", textStatistic.CommonWord.Key, textStatistic.CommonWord.Value);
            Console.WriteLine("Common Prefix: {0},  repeats {1}", textStatistic.CommonPrefix.Key, textStatistic.CommonPrefix.Value);
            Console.WriteLine("Capitalized Letter: {0}", textStatistic.CapitalizedLetter);
        }
    }
}
