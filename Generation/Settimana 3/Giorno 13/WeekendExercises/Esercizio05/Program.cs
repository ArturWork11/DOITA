//Esercizio05_Iterazione
// Siete i proprietari di un bar
// Stampare all'utente il vostro listino prezzi (Caffè -> 1.10 Acqua -> 1.50)
// Permettete all'utente di scegliere cosa vuole comprare.
// Stampare poi in console lo scontrino con tutto quello che ha scelto, i loro prezzi e il
// prezzo finale da pagare.
// Se la spesa supera i 25 euro, fare uno sconto del 5% su prezzo finale.
// Se l'utente prende più di 6 cose diverse scontare del 10% il prezzo finale.
// Potete cumulare gli sconti

string order = "";
string check = "\n\n\tFLAMINGO BAR CHECK\n";
double totalPrice = 0;
int itemOrdered = 0;
Console.WriteLine("Welcome at the Flamingo bar! here is the menu");
Console.WriteLine("\n\tMenu \n\n\tDrinks \nCoffee  \t1.10$ \nWater   \t1.50$ \nHot Chocolate   2.00$ \n\n\t Food \nBrioche \t1.20$ \nSandwich   \t3.50$ \nPiece of cake   2.50$ ");
Console.WriteLine("What do you order? tell me 'stop' when you want to stop ordering");

do
{
    order = Console.ReadLine();
    switch (order.ToLower())
    {
        case "coffee":
            check += "\nCoffee  \t1.10$\n";
            totalPrice += 1.10;
            itemOrdered++;
            break;
        case "water":
            check += "\nWater   \t1.50$\n";
            itemOrdered++;
            totalPrice += 1.50;
            break;
        case "hot chocolate":
            check += "\nHot Chocolate   2.00$\n";
            totalPrice += 2.00;
            itemOrdered++;
            break;
        case "brioche":
            check += "\nBrioche \t1.20$\n";
            totalPrice += 1.20;
            itemOrdered++;
            break;
        case "sandwich":
            check += "\nSandwich   \t3.50$\n";
            totalPrice += 3.50;
            itemOrdered++;
            break;
        case "piece of cake":
            check += "\nPiece of cake   2.50$\n";
            totalPrice += 2.50;
            itemOrdered++;
            break;
    }

} while (order.ToLower() != "stop");

if (totalPrice > 25)
{
    totalPrice -= (totalPrice / 100) * 5;
}

if (itemOrdered > 6)
{
    totalPrice -= (totalPrice / 100) * 10;
}

check += $"Total Price  \t{totalPrice}";
Console.WriteLine($"thank you for ordering! here it is your check! {check}");
    
