// Dovremo gestire una serie di Veicoli che si dividono in Automobili e Moto
// Per ogni classe modello scrivere il metodo ToString(), prezzo() e altro se ci viene in mente
// Scrivere una classe aggregatrice con i metodi: ListaCompleta(), ListaMoto(), ListaAuto()

//campi Veicolo: marca, modello, colore, immatricolazione
//metodi Veicolo: ToString(),Prezzo()->di base ritorna 1000 

//campi Moto:passeggero, bauletti, cruiseControl
//metodi Moto: ToString(), Prezzo()->perte dal prezzo base e a seconda della marca aumenta di valore. Se ducati incrementa di 5000€,
//se harley davidson di 8000, se kawasaki di 5500.
//Inoltre se ha il posto per il passeggero aumenta di 1000 altrimenti di 500,
//se ha il cruisecontrol aumenta di 2000 altrimenti di 100 e aggiungere 100€ per ogni bauletto

//campi Automobile: porte, optional, optional
//metodi Automobile:ToString(),  Prezzo()->parte dal prezzo di base e aumenta a seconda della marca. 
//Se fiat aumenta di 10.000, altrimenti aumenta di 20.000. Se ha 3 porte aumentare di 3000, 
//se 5 porte aumentare di 5000, altrimenti di 1000. Se ha gli optional aumentare di 3500 altrimenti di 1500. 
//Se ha il ruotino aumentare di 2000, altrimenti di 1000.
//Epoca() -> se immatricolata prima del 2000 è d'epoca alrimenti non lo è

//Concessionario campi:
//List<Veicolo> veicoli
//Concessionario metodi:
//ListaMoto(),ListaAuto(),Storici()->tutte le auto d'epoca,MotoCare()-< tutte le moto più costose

using EsercizioPolimorfismo;
using System.Globalization;

const string path = "../../../VehicleData.txt";
string digit = "";
CarShowroom carShowroom = new CarShowroom(path);

do
{
    Console.WriteLine("\nWhich Category do you want to see? \nDigit 1 to see all the vehicle avaible \nDigit 2 to see all the cars available \nDigit 3 to see all the motorcycles availaable \nDigit 4 to see all the vintage cars \nDigit 5 to see the most expensive motorcycles \nDigit 0 to exit\n");
    digit = Console.ReadLine();

    switch (digit)
    {
        case "1":
            Console.WriteLine(carShowroom.ListFull());
            break;
        case "2":
            Console.WriteLine(carShowroom.CarList());
            break;
        case "3":
            Console.WriteLine(carShowroom.MotorcycleList());
            break;
        case "4":
            Console.WriteLine(carShowroom.VintageCars());
            break;
        case "5":
            Console.WriteLine(carShowroom.ExpensiveMotorcycles());
            break;
        case "0":
            Console.WriteLine("Thank you, goodbye!");
            break;
        default:
            break;
    }
} while (digit != "0");

