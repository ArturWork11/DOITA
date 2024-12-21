string[] medici;
int stipendioTot = 0;
double stipendioMedioTot = 0.0f;
int nPediatri = 0;
int stipendioTotPediatri = 0;
double stipendioMedioPediatri = 0.0f;

Console.WriteLine("Quanti medici vuoi inserire?");
int nMedici = int.Parse(Console.ReadLine());
medici = new string[nMedici]; //nMedici = medici.Length

for (int i = 0; i < medici.Length; i++)
{
    string nome;
    int anniEsperienza;
    string reparto;
    int nInterventi;
    int nInterventiRiusciti;

    int nInterventiFalliti;

    int stipendio = 0;

    Console.WriteLine("\n------------------------------------");
    Console.WriteLine($"Medico {i + 1}");
    Console.Write("Nome: ");
    nome = Console.ReadLine();

    Console.Write("Anni esperienza: ");
    anniEsperienza = int.Parse(Console.ReadLine());

    Console.Write("Reparto: ");
    reparto = Console.ReadLine();

    Console.Write("Numero interventi totali: ");
    nInterventi = int.Parse(Console.ReadLine());

    Console.Write("Numero interventi riusciti: ");
    nInterventiRiusciti = int.Parse(Console.ReadLine());

    nInterventiFalliti = nInterventi - nInterventiRiusciti;

    switch (reparto.ToLower())
    {
        case "anatomia":
            stipendio = 1300 + (50*anniEsperienza) + (10*nInterventiRiusciti) - (50*nInterventiFalliti);
            break;
        case "chirurgia":
            stipendio = 1500 + (50 * anniEsperienza) + (10 * nInterventiRiusciti) - (50 * nInterventiFalliti);
            break;

        case "pediatria":
            stipendio = 2000 + (100 * anniEsperienza) + (10 * nInterventiRiusciti) - (20 * nInterventiFalliti);
            nPediatri++;
            stipendioTotPediatri += stipendio;
            break;

        default:
            stipendio = 1700 + (50 * anniEsperienza) + (10 * nInterventiRiusciti) - (50 * nInterventiFalliti);
            break;
    }

    stipendioTot += stipendio;

    //medici[i] = $"Nome: {nome}" +
    //            $"\nReparto: {reparto}" +
    //            $"\nAnni esperienza: {anniEsperienza}" +
    //            $"\nNome: {reparto}" +
    //            $"\nNumero interventi toali: {nInterventi}" +
    //            $"\nNumero interventi riusciti: {nInterventiRiusciti}" +
    //            $"\nStipendio: {stipendio}";

    //per accedere agli elementi della stringa, li salvo con un format preciso
    //nome,reparto,anniEsperienza,interventiTot,interventiRiusciti,stipendio
    medici[i] = $"{nome},{reparto},{anniEsperienza},{nInterventi},{nInterventiRiusciti},{stipendio}";


}//fine for


if (nMedici > 0)
{
    //il cast serve a convertire "forzatamente" un tipo in un altro TRONCA IL DECIMALE, NON APPROSSIMA
    stipendioMedioTot = (double)stipendioTot / nMedici;
}

if (nPediatri > 0)
{
    stipendioMedioPediatri = (double)stipendioTotPediatri / nPediatri;
}


Console.WriteLine("===============================");

Console.WriteLine(
    $"\nNumero medici totale:  {nMedici}" +
    $"\nStipendio totale:  {stipendioTot}" +
    $"\nStipendio medio:  {stipendioMedioTot}" +
    $"\nNumero pediatri {nPediatri}" +
    $"\nStipendio medio pediatri: {stipendioMedioPediatri}"
    );


for (int i = 0; i < nMedici; i++)
{
    Console.WriteLine("\n-----------------------------------");
    string[] infoMedico = medici[i].Split(",");

    //    nome,reparto,anniEsperienza,interventiTot,interventiRiusciti,stipendio
    Console.WriteLine($"Nome: {infoMedico[0]}\nStipendio: {infoMedico[5]}");

}
