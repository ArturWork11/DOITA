//Esercizo 2:
//      CONSEGNA
// Dovete calcolare la media di uno studente.
// Chiedete allo studente il nome, il voto di Italiano, Matematica, Informatica, Storia
// Voglio vedere stampata: 
// > la media dello studente con il suo nome (Es: Pino media 5.5)
// > se la media delle materia scientifiche supera l'8 stampare "Futuro Ingegniere"
// > se la media delle materie umanistiche è sopra il 6 stampare "Futuro Cassiere",
// > se la media totale è superiore al 9 stampare solo "Dottore" altrimenti stampare "riprova a studiare"
// > l'esito finale (si viene promossi solo se la media è maggiore o uguale a 6 e ci sono
//    al massimo 2 insufficienze) (ES Pino esito BOCCIATO) 

    string nome,futur,esito;
double votoIta, votoMate, votoInfo, votoStoria, media,insufficienze = 0,MediaUm,MediaS ;

Console.WriteLine("Buongiorno studente, qual'è il tuo nome?");
nome=Console.ReadLine();
Console.WriteLine("Buongiorno studente, qual'è il tuo voto di Italiano?");
votoIta=double.Parse(Console.ReadLine());
Console.WriteLine("Buongiorno studente, qual'è il tuo voto di Matematica?");
votoMate=double.Parse(Console.ReadLine()); 
Console.WriteLine("Buongiorno studente, qual'è il tuo voto di Informatica?");
votoInfo=double.Parse(Console.ReadLine());
Console.WriteLine("Buongiorno studente, qual'è il tuo voto di Storia?");
votoStoria=double.Parse(Console.ReadLine());

insufficienze += (votoMate < 6) ? 1 : 0;
insufficienze = (votoStoria < 6) ? insufficienze + 1 : insufficienze;
insufficienze = (votoInfo < 6) ? insufficienze + 1 : insufficienze;
insufficienze = (votoIta < 6) ? insufficienze + 1 : insufficienze;
MediaS = (votoInfo + votoMate)/ 2;
MediaUm = (votoStoria+votoIta)/ 2;
media = (votoIta + votoInfo + votoStoria + votoMate);
futur = (MediaS>9) ? "Dottore" : (MediaUm > 8) ? "Futuro Ingegniere" : (MediaUm > 6) ? "Futuro cassiere" : "riprova a studiare";
esito = (media > 6) && (insufficienze <=2) ? "PROMOSSO" : "BOCCIATO";

Console.WriteLine("La media dello studente " + nome + " è " + media);
Console.WriteLine(futur);
Console.WriteLine("l'esito finale dello studente " + nome + " è " + esito);


