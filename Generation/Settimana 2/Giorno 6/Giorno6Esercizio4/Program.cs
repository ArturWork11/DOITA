/*
         * stiamo organizzando una festa ad un amico
         * che compie gli anni 
         * chiedere all'organizzatore della festa
         * il numero di invitati
         * ad ogni invitato chiediamo il nome
         * e avendo definito un budget per il regalo
         * diamo la possibilità ad ognuno di mettere 
         * la somma che desidera
         * 
         * controllando che la somma dei regali non superi il budget
e che quando la soglia è stata raggiunta il programma si stoppi
         */

int Invitati=0, budget = 100, donazione;
string nome,Donazioni="";

Console.WriteLine("Quanti invitati ci sono?");
Invitati=int.Parse(Console.ReadLine());
while (budget>0 && Invitati > 0)
{
    Console.WriteLine("Qual'è il tuo nome?");
    nome = Console.ReadLine();
    Console.WriteLine("Quanti soldi vuoi mettere per il regalo?");
    donazione =int.Parse(Console.ReadLine());
    budget -= donazione;
    Invitati--;
    Donazioni += nome + " " + donazione + "\n"; 
   
}
Console.WriteLine("Le donazioni sono:\n " + Donazioni);
if (budget>0 && Invitati==0)
{
    Console.WriteLine("il budget non è stato raggiunto");
}
else
{
    Console.WriteLine("il budget è stato raggiunto");
}
