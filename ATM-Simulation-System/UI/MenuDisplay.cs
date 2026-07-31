using System;

namespace UI
{
    public class MenuDisplay
    {
        public void ShowWelcome()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("    WELCOME TO ATM SIMULATION SYSTEM    ");
            Console.WriteLine("========================================");
            Console.WriteLine();
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("              MAIN MENU                 ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Exit");
            Console.WriteLine("----------------------------------------");
        }

        public void ShowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[SUCCESS]: {message}");
            Console.ResetColor();
        }

        public void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR]: {message}");
            Console.ResetColor();
        }
    }
}