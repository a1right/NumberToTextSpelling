using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToTextSpelling
{
    public class DigitSpellerBuilder : IDigitSpellerBuilder
    {
        private DigitSpeller _speller;
        private int _numberToSpell;
        public DigitSpellerBuilder (int numberToSpell)
        {
            _speller = new();
            _numberToSpell = numberToSpell;
        }

        public IDigitSpellerBuilder BuildMillions()
        {
            int millions = _numberToSpell / 1000000;
            if (millions > 0)
                _speller.Millions = SpellThreeDigitNumbers(millions, AddNameOfMillionNumberGrade);
            return this;
        }
        public IDigitSpellerBuilder BuildThousands()
        {
            int thousands = _numberToSpell % 1000000 / 1000;
            if (thousands > 0)
                _speller.Thousands = SpellThreeDigitNumbers(thousands, AddNameOfThousandNumberGrade);
            return this;
        }
        public IDigitSpellerBuilder BuildHundredsDozensSingles()
        {
            int hundreds = _numberToSpell % 1000;
            _speller.HundredsDozensSingles = SpellThreeDigitNumbers(hundreds, AddRoubles);
            return this;
        }
        public DigitSpeller GetDigitSpelled()
        {
            DigitSpeller digitSpeller = _speller;
            return digitSpeller;
        }

        private string AddNameOfMillionNumberGrade(int lastDigit, int dozensWithSingles)
        {
            if (dozensWithSingles < 10 || dozensWithSingles > 19)
            {
                if (lastDigit == 0 || lastDigit >= 5 && lastDigit <= 9)
                    return "миллионов";
                if (lastDigit == 1)
                    return "миллион";
                if (lastDigit > 1 && lastDigit < 5)
                    return "миллиона";
            }
            else
                return "миллионов";
            return string.Empty;
        }
        private string AddNameOfThousandNumberGrade(int lastDigit, int dozensWithSingles)
        {
            if (dozensWithSingles < 10 || dozensWithSingles > 19)
            {
                if (lastDigit == 0 || lastDigit >= 5 && lastDigit <= 9)
                    return "тысяч";
                if (lastDigit == 1)
                    return "тысяча";
                if (lastDigit > 1 && lastDigit < 5)
                    return "тысячи";
            }
            else
                return "тысяч";
            return string.Empty;
        }
        private string AddRoubles(int lastDigit, int dozens)
        {
            if (dozens < 10 || dozens > 19)
            {
                if (lastDigit == 0 || lastDigit >= 5 && lastDigit <= 9)
                    return "рублей";
                if (lastDigit == 1)
                    return "рубль";
                if (lastDigit > 1 && lastDigit < 5)
                    return "рубля";
            }
            else
                return "рублей";
            return string.Empty;
        }

        private string SpellThreeDigitNumbers(int number, Func<int, int, string> addNameOfGrade )
        {
            string result = string.Empty;
            int hundredsDigit = number / 100 * 100;
            if (hundredsDigit > 0)
                result += (HundredsWordsEnum)hundredsDigit + " ";
            int dozensWithSingles = number - hundredsDigit;
            int lastDigit = dozensWithSingles % 10;
            int dozens = dozensWithSingles - lastDigit;
            if (dozensWithSingles > 10 && dozensWithSingles < 20)
                result += (SmallDigitWordsEnum)dozensWithSingles + " ";
            else
            {
                if (dozens > 0)
                    result += (SmallDigitWordsEnum)dozens + " ";
                if (lastDigit > 0)
                    result += (SmallDigitWordsEnum)lastDigit + " ";
            }
            result += addNameOfGrade(lastDigit, dozensWithSingles);
            result += " ";
            return result;
        }

    }
}
