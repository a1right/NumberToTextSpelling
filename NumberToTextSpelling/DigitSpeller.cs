using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToTextSpelling
{
    public class DigitSpeller
    {
        public int NumberToSpell { get; set; }
        public string HundredsDozensSingles { get; set; }
        public string Thousands { get; set; }
        public string Millions { get; set; }

        public override string ToString() =>
        
            new StringBuilder()
                .Append(Millions)
                .Append(Thousands)
                .Append(HundredsDozensSingles)
                .ToString();
        public void GetNumberToSpell()
        {
            NumberToSpell = int.Parse(Console.ReadLine());
        }
    }
}
