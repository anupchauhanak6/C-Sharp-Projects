namespace Models
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        private decimal _balance;
        private string _atmPin;
        public User AccountHolder { get; }
        public BankAccount(string accNum, decimal initialBalance, string pin, User holder)
        {
            AccountNumber = accNum;
            _balance = initialBalance;
            _atmPin = pin;
            AccountHolder = holder;
        }

        // PIN Verification
        public bool ValidatePin(string inputPin)
        {
            return _atmPin == inputPin;
        }

        // get balance
        public decimal GetBalance(decimal amount)
        {
            return _balance;
        }

        // credit amount
        public void Credit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
            }
        }
        
        // debit amount
        public bool Debit(decimal amount)
        {
            if (amount > 0 && _balance >= amount)
            {
                _balance -= amount;
                return true; // Success
            }
            return false; // Insufficient funds or invalid amount
        }
    }
}