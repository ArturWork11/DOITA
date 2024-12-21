using System;

namespace Esercizio_di_gruppo
{
    internal class LineOfCreditAccount : BankAccount
    {
        private readonly decimal _creditLimit;
        public LineOfCreditAccount(string owner, decimal initialBalance, decimal creditLimit)
            : base(owner, initialBalance, -creditLimit) // Imposta il saldo minimo al limite di credito negativo
        {
            _creditLimit = creditLimit;
        }
        public override void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
                }

                decimal potentialBalance = Balance - amount;
                bool isOverdrawn = potentialBalance < 0;
                bool isMoreThanHalfCreditUsed = potentialBalance < -_creditLimit / 2;

                if (isOverdrawn && isMoreThanHalfCreditUsed)
                {
                    amount += 20m; // Aggiunge una commissione di 20 solo se è stato utilizzato almeno il 50% del credito
                }

                if (potentialBalance < _minimumBalance)
                {
                    throw new InvalidOperationException("Insufficient funds including credit limit.");
                }

                var withdrawal = new Transaction(-amount, date, note);      //Mat: -amount --> amount
                _allTransactions.Add(withdrawal);
                Console.WriteLine("Amount successfully withdrawn.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Withdrawal error");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Withdrawal error");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error during the withdrawal: {ex.Message}");
            }

        }
        public override void PerformMonthEndTransactions()
        {
            if (Balance > 0)
            {
                var interest = Balance * 0.02m; // Aggiunge un interesse del 2% sul saldo positivo
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }
            // Se il saldo è negativo, non accade nulla
        }
    }
}
