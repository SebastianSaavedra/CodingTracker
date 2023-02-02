using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class UserInput
    {
        private static string? input;
        public int GetNumber(string msg)
        {
            Console.WriteLine(msg);
            input = Console.ReadLine();

            if (!int.TryParse(input, out int result) || string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("An error ocurred while reading your input, please use valid characters/values.");
                return GetNumber(msg);
            }

            return result;
        }

        public string GetText(string msg)
        {
            Console.WriteLine(msg);
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("An error ocurred while reading your input, please use valid characters/values.");
                return GetText(msg);
            }

            return input;
        }
    }
}
