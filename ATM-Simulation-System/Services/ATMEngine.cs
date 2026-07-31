using System;
using System.IO.Pipelines;
using Exceptions;
using Interfaces;
using Models;
using Transactions;
using UI;

namespace Services
{
    public class ATMEngine : IATMEngine
    {
        // Dummy Account
        private readonly BankAccount[] _accounts;
        private BankAccount? _currentAccount;

        // UI Helper
        private readonly MenuDisplay _menuDisplay;
        private readonly InputReader _inputReader;

        public ATMEngine()
        {
            _menuDisplay = new MenuDisplay();
            _inputReader = new InputReader();

            // seed Dummy data
            User user1 = new User("U101", "Rahul Sharma", "9876543210");
            User user2 = new User("U102", "Priya Verma", "9123456789");

            _accounts = new BankAccount[]
            {
                new BankAccount("ACC1001", 10000.00m, "1234", user1),
                new BankAccount("ACC1002", 5000.00m, "4321", user2)
            };
        }

        public void Start()
        {
            _menuDisplay.ShowWelcome();
            bool isAuthenticated = false;

            while (!isAuthenticated)
            {
                string accNum = _inputReader.ReadString("Enter Account Number: ");
                string pin = _inputReader.ReadString("Enter 4-Digit pin: ");

                if (AuthenticateUser(accNum, pin))
                {
                    isAuthenticated = true;
                    _menuDisplay.ShowMessage($"\nLogin Successful! Welcome, {_currentAccount!.AccountHolder.Name}.");
                    ShowMenu();
                }
                else
                {
                    _menuDisplay.ShowError("Authentication Failed! Invalid Account Number or PIN.\n");
                }
            }
        }

        public bool AuthenticateUser(string accountNumeber, string pin)
        {
            foreach (var account in _accounts)
            {
                if (account.AccountNumber == accountNumeber && account.ValidatePin(pin))
                {
                    _currentAccount = account;
                    return true;
                }
            }
            return false;
        }

        public void ShowMenu()
        {
            // First check user is logged in or not
            if (_currentAccount == null)
            {
                _menuDisplay.ShowError("No active session found. Please log in first.");
                return;
            }

            bool isRunning = true;

            while (isRunning)
            {
                _menuDisplay.ShowMainMenu();
                int choice = _inputReader.ReadInt("Select an option (1-4): ");

                switch (choice)
                {
                    case 1:
                        _menuDisplay.ShowMessage($"Your current balance is: ₹{_currentAccount.GetBalance()}");
                        break;
                    case 2:
                        decimal depositAmount = _inputReader.ReadDecimal("Enter amount to deposit: ");
                        ProcessTransaction(new DepositTransaction(depositAmount));
                        break;

                    case 3:
                        decimal withdrawAmount = _inputReader.ReadDecimal("Enter amount to withdraw: ");
                        ProcessTransaction(new WithdrawTransaction(withdrawAmount));
                        break;
                    case 4:
                        _menuDisplay.ShowMessage("Thank You for using ATM. GoodBye!");
                        isRunning = false;
                        break;
                    default:
                        _menuDisplay.ShowError("Invalid choice! Please select between 1 and 4.");
                        break;
                }
            }
        }

        public void ProcessTransaction(ITransaction transaction)
        {
            // First check user is logged in or not
            if (_currentAccount == null)
            {
                _menuDisplay.ShowError("No active session found. Please log in first.");
                return;
            }

            try
            {
                bool success = transaction.Execute(_currentAccount);

                if (success)
                {
                    _menuDisplay.ShowSuccess("Transaction executed successfully!");
                    _menuDisplay.ShowMessage($"Updated Balance: ₹{_currentAccount.GetBalance()}");
                }
            }
            catch (InsufficientFundsException ex)
            {
                _menuDisplay.ShowError($"Transaction Failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                _menuDisplay.ShowError($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}