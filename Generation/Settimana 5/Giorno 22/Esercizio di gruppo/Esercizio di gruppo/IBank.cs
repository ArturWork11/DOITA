namespace Esercizio_di_gruppo
{
    public interface IBank
    {
        void LoadAccountsFromFile(string filePath);
        void CreateNewAccount();
        void AddAccount(BankAccount account);
        public void RemoveAccount(BankAccount account);
        BankAccount Login(string accountNumber);
        BankAccount DataAccount(string accountNumber);
        void DisplayAccountData(BankAccount account);
        string GetAccountHistory(string numberAccount);
        void DisplayAccountHistory(BankAccount account);
        decimal Balance(string numberAccount);
        void DisplayAccountBalance(BankAccount account);
        void MakeDeposit(string accountNumber, decimal amount, DateTime date, string note);
        void MakeDeposit(BankAccount account);
        void MakeWithdrawal(string accountNumber, decimal amount, DateTime date, string note);
        void MakeWithdrawal(BankAccount account);
        public void PerformMonthEndForAllAccounts();
    }
}
