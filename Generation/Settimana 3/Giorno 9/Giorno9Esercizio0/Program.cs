string[] RigheFile = File.ReadAllLines("../../../medici.txt");
string[] nome = new string[RigheFile.Length];
int[]anni = new int[RigheFile.Length];
string[] reparto = new string[RigheFile.Length];
int[]interventi = new int[RigheFile.Length];
int[] interventiRiusciti = new int[RigheFile.Length];

for (int i  = 0; i < RigheFile.Length; i++)
{
    nome[i] = RigheFile[i].Split(',')[0];
    Console.Write(nome[i]);
    anni[i] = int.Parse(RigheFile[i].Split(',')[1]);
    reparto[i] = RigheFile[i].Split(',')[2];
    interventi[i] = int.Parse(RigheFile[i].Split(',')[3]);
    interventiRiusciti[i] = int.Parse(RigheFile[i].Split(',')[4]);
}

int[] stipendio = new int[RigheFile.Length];

for (int i=0; i < RigheFile.Length; i++)
{
    switch (reparto[i])
    {
        case "chirurgia":
            stipendio[i]=1500;
            break;
        case "pediatria":
            stipendio[i]=2000;
            break;
        case "anatomia":
            stipendio[i]=1200;
            break;
        default:
            stipendio[i]=1700;
            break;

            
    }
    stipendio[i] += anni[i] * (reparto[i] == "pediatria" ? 100 : 50);
    stipendio[i] += interventiRiusciti[i] * 10;
    stipendio[i] -= (interventi[i] - interventiRiusciti[i]) * 20; 
}