using System;
using Esercizio_di_gruppo;

Console.OutputEncoding = System.Text.Encoding.UTF8;

IBank bank = new Bank();
string filePath = "../../../Dati.txt";
bank.LoadAccountsFromFile(filePath);

MenuIniziale:
Console.WriteLine("--==- 🏦 Welcome to Generation Bank 🏦 -==--");
#region Menù iniziale
BankAccount loggedInAccount = null;
while (loggedInAccount == null)
{
    Console.WriteLine("\n\n----==----\nChoose an option:" +
                      "\n1] Create new account 👤" +
                      "\n2] Login 👤" +
                      "\n3] Exit 🚪\n");
    string choice1 = Console.ReadLine();
    switch (choice1)
    {
        case "1":
            bank.CreateNewAccount();
            break;
        case "2":
            Console.WriteLine("Insert Account Number");
            var accountNumber = Console.ReadLine();
            loggedInAccount = bank.Login(accountNumber);
            break;
        case "3":
            return;
        default:
            Console.WriteLine("❓ This option doesn't exist ❓\n");
            break;
    }
}
#endregion

#region Menù 2
bool exit = false;
while (!exit)
{
    Console.WriteLine("\n----==----\n" +
                      "Choose an option:" +
                      "\n1] Bank Account info ⓘ" +
                      "\n2] Balance 💰 " +
                      "\n3] Transaction history 🕑" +
                      "\n4] Deposit ⇈ " +
                      "\n5] Withdraw ⇊ " +
                      "\n6] Reload ⟳ " +
                      "\n7] Close Account 🗑" +
                      "\n8] Main Menu 🚪" +
                      "\n9] Exit 🚪\n" +
                      "----==----");
    string choice2 = Console.ReadLine();
    switch (choice2)
    {
        case "1":
            bank.DisplayAccountData(loggedInAccount);
            break;
        case "2":
            bank.DisplayAccountBalance(loggedInAccount);
            break;
        case "3":
            bank.DisplayAccountHistory(loggedInAccount);
            break;
        case "4":
            if (loggedInAccount is GiftCardAccount)
            {
                Console.WriteLine(" ⛔ Deposits are not allowed for Gift Card Accounts. Please use the reload option.");
            }
            else
            {
                try
                {
                    bank.MakeDeposit(loggedInAccount);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⛔ Deposit not allowed");
                }
            }
            break;

        case "5":
            try
            {
                bank.MakeWithdrawal(loggedInAccount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⛔ Withdrawal not allowed");
            }
            break;
        case "6":
            if (loggedInAccount is GiftCardAccount giftCardAccount)
            {
                Console.Write("Enter the amount to reload: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal reloadAmount))
                {
                    giftCardAccount.Reload(reloadAmount);
                }
                else
                {
                    Console.WriteLine("⛔ Invalid amount.");
                }
            }
            else
            {
                Console.WriteLine("\n⛔ This operation is only available for Gift Card Accounts.");
            }
            break;
        case "7":
            if (loggedInAccount is GiftCardAccount giftAccount)
            {
                giftAccount.CloseAccount();
                exit = true;
                goto MenuIniziale; //GOTO 
            }
            else
            {
                Console.WriteLine("⛔ This operation is only available for Gift Card Accounts.");

            }
            break;
        case "8":
            Console.WriteLine("See you soon! 👋");
            exit = true;
            goto MenuIniziale; //GOTO 
            break;
        case "9":
            Console.WriteLine("Goodbye! 👋");
            exit = true;
            break;
        default:
            Console.WriteLine("❓ Unknown Command ❓");
            break;
    }
}

// Perform month-end transactions for all accounts
bank.PerformMonthEndForAllAccounts();
#endregion