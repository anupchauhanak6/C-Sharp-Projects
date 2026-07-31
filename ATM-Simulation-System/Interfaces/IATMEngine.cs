namespace Interfaces
{
    public interface IATMEngine
    {
        /// <summary>
        /// initialize the system and start the flow of application
        /// </summary>
        void Start();

        /// <summary>
        /// throw the user's Account Number and Pin to verify
        /// </summary>
        /// <param name="accountNumebr">inputs from user's account number</param>
        /// <param name="pin">inputs from user's pin</param>
        /// <returns>return True if credentials are true, otherwise false</returns>
        bool AuthenticateUser(string accountNumebr, string pin);

        /// <summary>
        /// it render the Interactive Menu options (Deposit, Withdraw, Balance) on user screen
        /// </summary>
        void ShowMenu();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction">Polymorphic transaction object (ITransaction)</param>
        void ProcessTransactioin(ITransaction transaction);
    }
}