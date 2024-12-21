// Chiedete all'utente tramite console di inserire una serie di nomi associati a delle età.
// Quando avete tutti i dati, voglio vedere:
// - L'età media
// - Il nome collegato all'età maggiore
// - Il numero di persone con un età superiore alla media
// - L'età più frequente

using System.Globalization;

string digit = "";
Dictionary<string,int> people = new Dictionary<string,int>();
int i =0;
do
{
    Console.WriteLine("What's the name and age of the person " + (i + 1));
    people.Add(Console.ReadLine(), int.Parse(Console.ReadLine()));
    i++;
    Console.WriteLine("\ndigit 'stop' to stop adding people else just press enter");
    digit = Console.ReadLine();
}while (digit != "stop");


int sum = 0;
foreach  (int value in people.Values)
{
    sum += value;
}

var averageAge  = sum / people.Count;
Console.WriteLine("The average age is " +  averageAge);

string oldestPerson = "";
int maxAge = 0;
foreach  (var person in people)
{
    
        if (person.Value > maxAge)
        {
            maxAge = person.Value;
            oldestPerson = person.Key;
        }
        
}

Console.WriteLine("The Oldest person is " + oldestPerson + " with " + maxAge + " age");


string list = "";
foreach (var person in people)
{
        if (person.Value > averageAge)
        {
        list += person.Key + ",\n";

        }
}

Console.WriteLine("The people above the average age is:\n" + list );


foreach (int value in people.Values)
{
    if (value == value)
    {
       
    }
} 