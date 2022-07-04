namespace NumberToTextSpelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите число");
                string input = Console.ReadLine();
                int number = int.Parse(input);
                var builder = new DigitSpellerBuilder(number);
                builder.BuildMillions().BuildThousands().BuildHundredsDozensSingles();
                var numberSpelled = builder.GetDigitSpelled();
                Console.WriteLine(numberSpelled);
            }
            Console.ReadLine();
        }
    }
}