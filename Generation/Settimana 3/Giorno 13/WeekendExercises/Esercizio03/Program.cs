//Esercizio03_Iterazione_Selezione
/* Programma banca on-line ...versione con PIN
		* Partendo da un bilancio (capitale) di 15.000 �
		* creare un menu da permettere al correntista di fare le seguenti operazioni
		*  - bilancio 
		*  - deposito
		*  - storico operazioni
*/

int PIN = 0;
double balance = 15000;
string transactionHistory = "Transaction history: \n+15000$";
int digit = 0;

Console.WriteLine("Welcome back! Please enter your PIN to login in your bank account");


do
{
	PIN = int.Parse(Console.ReadLine());
	if (PIN == 9900)
	{

		do
		{
			Console.WriteLine("Bank account: \nDigit 1 to see your balance \nDigit 2 to deposit cash \nDigit 3 to see your transaction history");
			digit = int.Parse(Console.ReadLine());
			switch (digit)
			{
				case 1:
					Console.WriteLine($"Your Balance is: {balance}");
					break;
				case 2:
					Console.WriteLine("How much you want deposit?");
					double deposit = double.Parse(Console.ReadLine());
					balance += deposit;
					transactionHistory += $"\n +{deposit}$";
					break;
				case 3:
					Console.WriteLine($"Here is your \n{transactionHistory}");
					break;
				case 0:
					Console.WriteLine("Goodbye!");
					break;
				default:
					Console.WriteLine("Wrong Digit, try again");
					break;
			}
		} while (digit != 0);


	}
	else
	{
		Console.WriteLine("Wrong PIN, try again");
	}

} while (PIN!=9900);
