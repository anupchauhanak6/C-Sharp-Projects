using Exceptions;
using Interfaces;
using Models;

namespace Transactions
{
    public class WithdrawTransaction : ITransaction
    {
        public decimal Amount { get; }

        public WithdrawTransaction(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }
            Amount = amount;
        }

        public bool Execute(BankAccount account)
        {
            if (account == null) return false;

            // Insufficient balance check
            if (account.GetBalance() < Amount)
            {
                throw new InsufficientFundsException($"Cannot withdraw ₹{Amount}. Current balance is ₹{account.GetBalance()}.");
            }

            return account.Debit(Amount);
        }
    }
}