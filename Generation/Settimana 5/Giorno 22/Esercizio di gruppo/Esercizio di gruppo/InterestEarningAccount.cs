using System;

namespace Esercizio_di_gruppo
{
    internal class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount(string owner, decimal initialBalance)
            : base(owner, initialBalance) { }
        public override void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            base.MakeWithdrawal(amount, date, note);
            Console.WriteLine("Amount successfully withdrawn.");
        }
        public override void PerformMonthEndTransactions()
        {
            if (Balance > 0)
            {
                var interest = Balance * 0.02m; 
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }
        }
    }
}
