using Models;

namespace Interfaces
{
    public interface ITransaction
    {
        /// <summary>
        /// It execute a specific transaction login on given account
        /// </summary>
        /// <param name="account">to perform transaction on this account</param>
        /// <returns>return True if transaction was success, oterwise return False</returns>
        bool Execute(BankAccount account);
    }
}