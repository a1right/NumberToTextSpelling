using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToTextSpelling
{
    public interface IDigitSpellerBuilder
    {
        
        IDigitSpellerBuilder BuildHundredsDozensSingles();
        IDigitSpellerBuilder BuildThousands();
        IDigitSpellerBuilder BuildMillions();
        public DigitSpeller GetDigitSpelled();
        
    }
}
