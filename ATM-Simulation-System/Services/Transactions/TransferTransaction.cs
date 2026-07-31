using Exceptions;
using Interfaces;
using Models;

namespace Transactions
{
    public class TransferTransaction : ITransaction
    {
        public decimal Amount { get; }
        public BankAccount TargetAccount { get; }

        public TransferTransaction(decimal amount, BankAccount targetAccount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Transfer amount must be greater than zero.");
            }
            Amount = amount;
            TargetAccount = targetAccount ?? throw new ArgumentNullException(nameof(targetAccount), "Target account cannot be null.");
        }

        public bool Execute(BankAccount sourceAccount)
        {
            if (sourceAccount == null) return false;

            // Sender ke pass sufficient funds hain ya nahi check karein
            if (sourceAccount.GetBalance() < Amount)
            {
                throw new InsufficientFundsException($"Transfer failed! Insufficient balance of ₹{sourceAccount.GetBalance()}.");
            }

            // Sender ke account se deduct aur Target account me credit
            bool isDebited = sourceAccount.Debit(Amount);
            if (isDebited)
            {
                TargetAccount.Credit(Amount);
                return true;
            }

            return false;
        }
    }
}