/* 2.creare un programma che calcoli il prezzo del biglietto per entrare al cinema
   . chiedere all'utente la sua età, la sua residenza e la sua professione
   . se è minorenne o a più di 65 anni il prezzo viene scontato del 50%
   . se è uno studente o un insegnante il prezzo viene scontato di 4 euro
   . se è residente a Torino entra gratis
   . di base il prezzo è 15 euro
   fornire all'utente il prezzo per lui più conveniente */

// UTILIZZANDO SOLO OPERATORI TERNARI

double prezzo = 15;
double eta;
string residenza, professione, RispostaEta, NomeUtente;

Console.WriteLine("Buongiorno come ti chiami?");
NomeUtente = Console.ReadLine();
Console.WriteLine("Buongiorno " + NomeUtente + ", quanti anni hai?");
RispostaEta = Console.ReadLine();
eta = double.Parse(RispostaEta);
Console.WriteLine("dove sei residente?");
residenza = Console.ReadLine();
Console.WriteLine("che lavoro fai?");
professione = Console.ReadLine();

prezzo = (eta<18 || eta>65) ? prezzo / 2 : prezzo; 
prezzo = (professione == "studente" || professione == "insegnante") ? prezzo - 4 : prezzo;
prezzo = (residenza == "torino") ?  prezzo = 0 : prezzo;
Console.WriteLine("il prezzo del tuo biglietto è " + prezzo + " Euro");

