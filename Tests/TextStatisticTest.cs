using System;
using Xunit;
using RingbaCodeTest;
using System.Collections.Generic;

namespace Tests
{
    public class TextStatisticTest
    {
        [Fact]
        public void checkIncrementWithoutEntry()
        {
            char[] letters = {'A', 'b', 'c', 'A','b','c', 'D', 'b','e' };
            var stat = new TextStatistic();
            foreach( var letter in letters)
            {
                stat.AddNextChar(letter);
            }
            stat.calculateStatistic();
            Assert.Equal(3, stat.CapitalizedLetter);
            Assert.Equal('b', stat.CommonLetter.Key);
            Assert.Equal(3, stat.CommonLetter.Value);
            Assert.Equal("abc", stat.CommonWord.Key);
            Assert.Equal(2, stat.CommonWord.Value);
            Assert.Equal("ab", stat.CommonPrefix.Key);
            Assert.Equal(2, stat.CommonPrefix.Value);
        }
    }
}
