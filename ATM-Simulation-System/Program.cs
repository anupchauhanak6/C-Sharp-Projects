using System;
using Services;
using static System.Console;

class Program
{
    public static void Main(string[] args)
    {
        // ATM Engine ka instance create kar rahe hain
            ATMEngine atmEngine = new ATMEngine();

            // Application flow ko trigger kar rahe hain
            atmEngine.Start();
    }
}