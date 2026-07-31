using System;
using Services;
using static System.Console;

class Program
{
    public static void Main(string[] args)
    {
            // Creating an instance of the ATM engine.
            ATMEngine atmEngine = new ATMEngine();

            // Triggering the application flow.
            atmEngine.Start();
    }
}