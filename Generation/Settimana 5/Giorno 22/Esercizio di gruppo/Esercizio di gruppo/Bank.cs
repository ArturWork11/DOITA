using System;
using System.Collections.Generic;
using System.IO;

namespace Esercizio_di_gruppo
{
    public class Bank : IBank
    {
        public static List<BankAccount> Accounts { get; } = new List<BankAccount>();
        public List<Transaction> Transactions { get; } = new List<Transaction>();
        public void LoadAccountsFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                var accountType = parts[0];
                var owner = parts[1];
                var initialBalance = decimal.Parse(parts[2]);
                BankAccount account = null;
                if (accountType == "LineOfCreditAccount" && parts.Length == 4)
                {
                    var creditLimit = decimal.Parse(parts[3]);
                    account = new LineOfCreditAccount(owner, initialBalance, creditLimit);
                }
                else if (accountType == "GiftCardAccount")
                {
                    account = new GiftCardAccount(owner, initialBalance);
                }
                else if (accountType == "InterestEarningAccount")
                {
                    account = new InterestEarningAccount(owner, initialBalance);
                }
                if (account != null)
                {
                    AddAccount(account);
                }
            }
        }
        public void CreateNewAccount()
        {
            try
            {
                Console.WriteLine("Select account type:");
                Console.WriteLine("1. Line of Credit Account");
                Console.WriteLine("2. Gift Card Account");
                Console.WriteLine("3. Interest Earning Account");
                Console.Write("Choose an option: ");
                var accountTypeChoice = Console.ReadLine();
                Console.Write("Write the name of the owner of the account: ");
                var owner = Console.ReadLine();

                Console.WriteLine("Insert your Balance: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal initialBalance))
                {
                    Console.WriteLine("Balance not valid");
                    return;
                }

                if (initialBalance < 0)
                {
                    Console.WriteLine("Initial balance must be positive");
                    return;
                }

                BankAccount newAccount = null;
                switch (accountTypeChoice)
                {
                    case "1":
                        Console.WriteLine("Please insert your credit limit: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal creditLimit))
                        {
                            Console.WriteLine("Credit limit not valid");
                            return;
                        }
                        newAccount = new LineOfCreditAccount(owner, initialBalance, creditLimit);
                        break;
                    case "2":
                        newAccount = new GiftCardAccount(owner, initialBalance);
                        break;
                    case "3":
                        newAccount = new InterestEarningAccount(owner, initialBalance);
                        break;
                    default:
                        Console.WriteLine("Account type not valid");
                        return;
                }
                Accounts.Add(newAccount);
                Console.WriteLine($"Account created successfully! Account number: {newAccount.Number}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Troubles creating new account: {ex.Message}");
            }
        }
        public void AddAccount(BankAccount account)
        {
            Accounts.Add(account);
        }
        public void RemoveAccount(BankAccount account)
        {
            try
            {
                Accounts.Remove(account);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error found in account deletion: {ex.Message}");
            }
        }
        public BankAccount Login(string accountNumber)
        {
            var account = DataAccount(accountNumber);
            if (account != null)
            {
                Console.WriteLine("Successfully logged in");
                return account;
            }
            else
            {
                Console.WriteLine("Invalid account number");
                return null;
            }
        }
        public BankAccount DataAccount(string numberAccount)
        {
            foreach (var account in Accounts)
            {
                if (account.Number == numberAccount)
                {
                    return account;
                }
            }
            return null;
        }
        public void DisplayAccountData(BankAccount account)
        {
            if (account != null)
            {
                Console.WriteLine($"Account number: {account.Number}");
                Console.WriteLine($"Owner: {account.Owner}");
                Console.WriteLine($"Balance: {account.Balance:C}\n      ");
            }
            else
            {
                Console.WriteLine("Account not found, the account number may be wrong.");
            }
        }
        public decimal Balance(string accountNumber)
        {
            var account = DataAccount(accountNumber);
            return account != null ? account.Balance : 0;
        }
        public void DisplayAccountBalance(BankAccount account)
        {
            if (account != null)
            {
                Console.WriteLine($"\nBalance: {account.Balance:C}\n     ");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }
        public string GetAccountHistory(string accountNumber)
        {
            var account = DataAccount(accountNumber);
            return account != null ? account.GetAccountHistory() : "Transactions history not found";
        }
        public void DisplayAccountHistory(BankAccount account)
        {
            if (account != null)
            {
                var history = account.GetAccountHistory();
                Console.WriteLine($"Transaction history {account.Number}:");
                Console.WriteLine(history);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
        public void MakeDeposit(string accountNumber, decimal amount, DateTime date, string note)
        {
            var account = DataAccount(accountNumber);
            account?.MakeDeposit(amount, date, note);
        }
        public void MakeDeposit(BankAccount account)
        {
            if (account != null)
            {
                Console.Write("Please enter the deposit amount: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Invalid deposit amount.");
                    return;
                }
                Console.Write("Please leave a note: ");
                var note = Console.ReadLine();
                account.MakeDeposit(amount, DateTime.Now, note);
                Console.WriteLine("Amount successfully deposited");
            }
            else
            {
                Console.WriteLine("Account not found");
            }
        }
        public void MakeWithdrawal(string accountNumber, decimal amount, DateTime date, string note)
        {
            var account = DataAccount(accountNumber);
            account?.MakeWithdrawal(amount, date, note);
        }
        public void MakeWithdrawal(BankAccount account)
        {
            if (account != null)
            {
                Console.Write("Please enter the withdraw amount: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Withdraw amount not valid.");
                    return;
                }
                Console.Write("Please leave a note: ");
                var note = Console.ReadLine();
                account.MakeWithdrawal(amount, DateTime.Now, note);
            }
            else
            {
                Console.WriteLine("Account not found");
            }
        }
        public void PerformMonthEndForAllAccounts()
        {
            foreach (var account in Accounts)
            {
                account.PerformMonthEndTransactions();
            }
        }
    }
}
