//Creare la classe Entity astratta che avrà i campi:
//     int id, string nominativo, string dob 
//e avrà i metodi:
//    ToString()
//  abstract double CostoMensile()

//Creare la classe Bracciante, figlia di Entity, con i campi:
//    int annilavoro, double costoorario, int oregiornaliere, bool vittoalloggio. 
//Avrà i metodi:
//     ToString()
//   CostoMensile() che verrà concretizzato come segue:
//            -> il costo di ogni Bracciante è pari al costoorario * oregiornaliere * X 
//                dove X vale Y + (annilavoro / 10) 
//                e Y vale 10 se vittoalloggio è true, altrimenti vale 20

//Creare la classe Animale, figlia di Entity, con i campi:
//     string razza, int nzampe, string tipoalimentazione
//Avrà i metodi:
//     ToString()
//   CostoMensile() verrà concretizzato come segue ->
//                    il costo di ogni animale parte da 3, a cui aggiungiamo: 
//                        0.5 se è una gallina,
//                        7 se è un cavallo,
//                        12 se è una mucca,
//                        8 se è altro 
//                    a questo andiamo ad aggiungere 4 se come tipo alimentazione ha “carnivoro”. 
//     Nel set di razza controllare che l’animale sia uno tra “gallina”, “cavallo”, “mucca”, “toro” altrimenti impostarlo automaticamente a “mucca”.

//Successivamente creare un file con i vari oggetti

//Creare la classe aggregatrice Fattoria, che conterà una lista di oggetti Entity. 
//Creare il solito costruttore. 
//Infine i seguenti metodi:
//> string ElencoAnimali()
//> string ElencoBraccianti()
//> double CostoMensileBraccianti()
//> double CostoMensileMucche()
//> double CostoMensileAnimali()
//> double CostoMensileAnimali(string razza)
//> double CostoMensileTotale()
//> string ElencoBraccianti(int COM)->braccianti che hanno un costo orario < COM
//> string BracciantePiuCostoso()
//> string RazzaPiuCostosa()

//In un Program testare i vari metodi mano a mano che vengono scritti

using Esercizio02;
string path = "../../../Data.txt";
Farm farm = new Farm(path);
string type = "";
double price = 0;
string digit = "";
do
{
    Console.WriteLine("\n\nHello! Welcome to our Farm! \ndigit a number to select what you want to see \n1. A list of our Animals \n2. A list of our farm workers \n3. The total monthly cost of our farm workers \n4. The total monthly cost of our cows \n5. The total monthly cost of our animals \n6. The monthly cost of the type of animal you want \n7. The total monthly cost of our animals and farm workers \n8. The list of farm worker that the cost per month is less than the the price you set \n9. The most expensive farm worker \n10. The most expensive type of animal \n0. exit the program");
    digit = Console.ReadLine();
    switch (digit)
    {
        case "1":
            Console.WriteLine(farm.ListAnimal());
            break;
        case "2":
            Console.WriteLine(farm.ListFarmWorker());
            break;
        case "3":
            Console.WriteLine("\nThe total farm workers monthly cost is " + farm.FarmWorkerMonthlyCost() + "\n");
            break;
        case "4":
            Console.WriteLine("\nThe total cows monthly cost is " + farm.CowMonthlyCost() + "\n");
            break;
        case "5":
            Console.WriteLine("\nThe total animals monthly cost is " + farm.AnimalMonthlyCost() + "\n");
            break;
        case "6":
            Console.WriteLine("\nOf which type of animal do you want to see the monthly cost?");
            type = Console.ReadLine();
            Console.WriteLine("\n" + farm.AnimalTypeMonthlyCost(type) + "\n");
            break;
        case "7":
            Console.WriteLine("\nThe total monthly cost is " + farm.TotalMonthlyCost() + "\n");
            break;
        case "8":
            Console.WriteLine("Below which price do you want to see the farm workers monthly cost?");
            price = double.Parse(Console.ReadLine());
            Console.WriteLine($"\nThe farm worker/s that cost monthly below {price} is/are :" + farm.FarmWorkerUserCost(price) + "\n");
            break;
        case "9":
            Console.WriteLine("\nThe most expensive farm worker is: " + farm.ExpensiveFarmWorker() + "\n");
            break;
        case "10":
            Console.WriteLine("\nThe most expensive type of animal is " + farm.ExpensiveType() + "\n");
            break;
        case "0":
            Console.WriteLine("\nGoodbye and Thank you!");
            break;
        default:
            Console.WriteLine("\nThe digit is wrong, try again!");
            break;
        }
    }

} while (digit != "0");








Console.ReadLine();
