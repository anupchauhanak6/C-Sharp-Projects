using System;
using Interfaces;
using Models;

namespace ATM.ConsoleApp.Services.Transactions
{
    public class DepositTransaction : ITransaction
    {
        public decimal Amount { get; }

        public DepositTransaction(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
            Amount = amount;
        }

        public bool Execute(BankAccount account)
        {
            if (account == null) return false;

            account.Credit(Amount);
            return true;
        }
    }
}