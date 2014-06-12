using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseConverter
{
    class Program
    {
        static void Main(string[] args)
        {  
            do
            {
                Console.WriteLine("Enter value to convert, or 'q' to quit: ");
                string convertValue = Console.ReadLine();

                if (convertValue == "q")
                {
                    Console.WriteLine("Bye");
                    Environment.Exit(0);
                }

                Console.WriteLine("Enter base of this value: ");
                double baseCurrentValue = 0;
                Double.TryParse(Console.ReadLine(), out baseCurrentValue);

                Console.WriteLine("Enter base that this value should be converted to: ");
                Double baseNewValue = 0;
                Double.TryParse(Console.ReadLine(), out baseNewValue);

                // Convert the inputted value to base 10.
                double base10Total = 0;
                double posPower = 0;
                char[] origValue = convertValue.Reverse<char>().ToArray<char>();
                double value = 0;

                foreach (char num in origValue)
                {
                    base10Total += ConvertToDecimal(num) * Math.Pow(baseCurrentValue, posPower);
                    posPower += 1;
                }

                // Convert the base 10 value to the desired base.
                List<char> newValue = new List<char>();

                while (base10Total >= 1)
                {
                    newValue.Add(ConvertToChar((char)(base10Total % baseNewValue)));
                    base10Total = Math.Floor(base10Total / baseNewValue);
                }

                newValue.Reverse();

                Console.WriteLine(String.Format("Converted value is: "));

                foreach (char newNum in newValue)
                {
                    if (char.IsLetter(newNum)) // Dealing with an alpha character.
                    {
                        Console.Write(newNum.ToString());
                    }
                    else
                    {
                        Console.Write(Int32.Parse(newNum.ToString()));
                    }
                }

                Console.Write(" [Base={0}]", baseNewValue.ToString());
                Console.WriteLine("\n");
            }
            while (1 == 1);
        }

        public static int ConvertToDecimal(char alpha)
        {
            switch (alpha)
            {
                case 'A':
                    return 10;
                case 'B':
                    return 11;
                case 'C':
                    return 12;
                case 'D':
                    return 13;
                case 'E':
                    return 14;
                case 'F':
                    return 15;
                default:
                    return Int32.Parse(alpha.ToString());
            }
        }

        public static char ConvertToChar(int num)
        {
            switch (num)
            {
                case 10:
                    return 'A';
                case 11:
                    return 'B';
                case 12:
                    return 'C';
                case 13:
                    return 'D';
                case 14:
                    return 'E';
                case 15:
                    return 'F';
                default:
                    return char.Parse(num.ToString());
            }
        }
    }
}
