using System;

namespace UI
{
    public class InputReader
    {
        public string ReadString(string prompt)
        {
            string? input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input cannot be empty. Please try again.");
                    Console.ResetColor();
                }
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        public int ReadInt(string prompt)
        {
            int result;
            string input = ReadString(prompt);

            while (!int.TryParse(input, out result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid number! Please enter a valid integer.");
                Console.ResetColor();
                input = ReadString(prompt);
            }

            return result;
        }

        public decimal ReadDecimal(string prompt)
        {
            decimal result;
            string input = ReadString(prompt);

            while (!decimal.TryParse(input, out result) || result <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid amount! Please enter a valid positive number.");
                Console.ResetColor();
                input = ReadString(prompt);
            }

            return result;
        }
    }
}