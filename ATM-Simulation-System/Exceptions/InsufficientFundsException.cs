using System;

namespace Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() 
            : base("Insufficient funds in the account.") { }

        public InsufficientFundsException(string message) 
            : base(message) { }
    }
}