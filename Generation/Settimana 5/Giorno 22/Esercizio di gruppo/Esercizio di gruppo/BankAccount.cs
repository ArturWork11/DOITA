using System;
using System.Collections.Generic;

namespace Esercizio_di_gruppo
{
    public abstract class BankAccount
    {
        private static int s_accountNumberSeed = 1234567890;
        protected readonly List<Transaction> _allTransactions = new List<Transaction>(); // Modifica da private a protected

        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        protected decimal _minimumBalance;
        public BankAccount(string owner, decimal initialBalance)
            : this(owner, initialBalance, 0) { }
        public BankAccount(string owner, decimal initialBalance, decimal minimumBalance)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial balance must be positive");
            }
            Owner = owner;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;
            _minimumBalance = minimumBalance;
        }
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            _allTransactions.Add(deposit);
        }
        public virtual void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            _allTransactions.Add(withdrawal);
        }
        public string GetAccountHistory()
        {
            string report = "Date\t\tAmount\t\tNote\n";
            foreach (var item in _allTransactions)
            {
                report += $"{item.Date.ToShortDateString()}\t{item.Amount:C}\t{item.Notes}\n";
            }
            return report;
        }
        public abstract void PerformMonthEndTransactions();
    }
}
