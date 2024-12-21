using System;

namespace Esercizio_di_gruppo
{
    internal class GiftCardAccount : BankAccount
    {
        private DateTime _lastDepositDate;
        public GiftCardAccount(string owner, decimal initialBalance)
            : base(owner, initialBalance)
        {
            // Deposito iniziale
            _lastDepositDate = DateTime.Now;
        }
        // Rimuoviamo la possibilità di usare MakeDeposit direttamente dall'esterno
        private new void MakeDeposit(decimal amount, DateTime date, string note)
        {
            base.MakeDeposit(amount, date, note);
        }
        public void Reload(decimal amount)
        {
            try
            {
                if (DateTime.Now.Month == _lastDepositDate.Month)
                {
                    Console.WriteLine("Account can only be reloaded once per month at the end of the month.");
                    return;
                }

                // Assicurarsi che la ricarica avvenga solo alla fine del mese
                if (DateTime.Now.Day != DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                {
                    Console.WriteLine("Recharge allowed only at the end of the month.");
                    return;
                }

                MakeDeposit(amount, DateTime.Now, "Monthly reload");
                _lastDepositDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Search Error: {ex.Message}");
            }
        }

        public override void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            base.MakeWithdrawal(amount, date, note);
            Console.WriteLine("Amount successfully withdrawn.");
        }
        public void CloseAccount()
        {
            try
            {
                MakeWithdrawal(Balance, DateTime.Now, "Close account");
                var bank = new Bank();
                bank.RemoveAccount(this);
                Console.WriteLine("Account closed and balance withdrawn.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in account Deletion");
            }
        }
        public override void PerformMonthEndTransactions()
        {
            // Le ricariche sono consentite solo una volta al mese alla fine del mese
            if (DateTime.Now.Day == DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
            {
                // Possiamo eventualmente aggiungere un'azione di ricarica automatica mensile qui, se necessario
                Console.WriteLine("It's the end of the month, you can reload your Gift Card.");
            }
        }
    }
}
