using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportivi
{
    //Classe aggregatore che gestisce i dati e le istanze di tutti gli sportivi che leggerò
    internal class Federazione
    {
        //Per CONVENZIONE si dichiarano le liste nella classe
        public List<Calciatori> calciatori;
        public List<Tennisti> tennisti;
        public List<Nuotatore> nuotatori;
        public List<Pugile> pugili;
        public List<Pilota> piloti;


        public Federazione(string pathToFile)
        {
            //e si inizializzano nel costruttore --> Inizializzo le liste
            calciatori = new List<Calciatori>();
            tennisti = new List<Tennisti>();
            nuotatori = new List<Nuotatore>();
            pugili = new List<Pugile>();
            piloti = new List<Pilota>();

            //chiamo il metodo per popolare le liste leggendo il file
            CaricaDati(pathToFile);
        }

        public void CaricaDati(string pathToFile)
        {
            string[] righeFile = File.ReadAllLines(pathToFile);

            for (int i = 0; i < righeFile.Length; i++)
            {
                string[] info = righeFile[i].Split(',');
                switch (info[0].ToLower())
                {
                    case "calciatore":
                        Calciatori calciatore = new Calciatori(info[1], info[2], double.Parse(info[3]), int.Parse(info[4]), info[5], info[6]);
                        calciatori.Add(calciatore);
                        break;
                    case "tennista":
                        Tennisti tennista = new Tennisti(info[1], info[2], double.Parse(info[3]), info[4], info[5].ToLower() == "true");  //bool.Parse(info[5])
                        tennisti.Add(tennista);
                        break;
                    case "nuotatore":
                        nuotatori.Add(new Nuotatore(info[1], info[2], double.Parse(info[3]), info[4]));
                        break;
                    case "pugile":
                        pugili.Add(new Pugile(info[1], info[2], double.Parse(info[3]), int.Parse(info[4])));
                        break;
                    case "pilota":
                        piloti.Add(new Pilota(info[1], info[2], double.Parse(info[3]), info[4], info[5]));
                        break;
                }

                //fine switch

            }
        }
        public string StampaListe(string categoria)
        {
            string ris = "";
            switch (categoria)
            {
                case "calciatore":
                    foreach (Calciatori elemento in calciatori)
                    {
                        ris += elemento.Scheda() + "\n\n";
                    }
                    break;
                case "tennista":
                    foreach (Tennisti elemento in tennisti)
                    {
                        ris += elemento.Scheda() + "\n\n";
                    }
                    break;
                case "nuotatore":
                    foreach (Nuotatore elemento in nuotatori)
                    {
                        ris += elemento.Scheda() + "\n\n";
                    }
                    break;
                case "pugile":
                    foreach (Pugile elemento in pugili)
                    {
                        ris += elemento.Scheda() + "\n\n";
                    }
                    break;
                case "pilota":
                    foreach (Pilota elemento in piloti)
                    {
                        ris += elemento.Scheda() + "\n\n";
                    }
                    break;
            }
            return ris;
        }
        public string SportiviGiovani(int minEta = 18, int maxEta = 28)
        {
            
            string ris = "";
            foreach (Calciatori elemento in calciatori)
            {
                if (elemento.Eta >= minEta && elemento.Eta <= maxEta)
                {
                    ris += elemento.Scheda() + "\n\n";
                }
            }
            foreach (Tennisti elemento in tennisti)
            {
                if(elemento.Eta >= minEta && elemento.Eta <= maxEta)
                {
                    ris += elemento.Scheda() + "\n\n";
                }
            }
            foreach (Nuotatore elemento in nuotatori)
            {
                if (elemento.Eta >= minEta && elemento.Eta <= maxEta)
                {

                    ris += elemento.Scheda() + "\n\n";
                }
            }

            foreach (Pugile elemento in pugili)
            {
                if (elemento.Eta >= minEta && elemento.Eta <= maxEta)
                {
                    ris += elemento.Scheda() + "\n\n";

                }
            }

            foreach (Pilota elemento in piloti)
            {
                if (elemento.Eta >= minEta && elemento.Eta <= maxEta)
                {
                    ris += elemento.Scheda() + "\n\n";

                }
            }
            return ris;
        }

        public string RicercaNome(string nomeUtente, string cognomeUtente)
        {

            string ris = "";
            foreach (Calciatori elemento in calciatori)
            {
                if (elemento.Nome == nomeUtente && elemento.Cognome == cognomeUtente)
                {
                    ris += elemento.Scheda() + "\n\n";
                }
            }
            foreach (Tennisti elemento in tennisti)
            {
                if (elemento.Nome == nomeUtente && elemento.Cognome == cognomeUtente)
                {
                    ris += elemento.Scheda() + "\n\n";
                }
            }
            foreach (Nuotatore elemento in nuotatori)
            {
                if (elemento.Nome == nomeUtente && elemento.Cognome == cognomeUtente)
                {

                    ris += elemento.Scheda() + "\n\n";
                }
            }

            foreach (Pugile elemento in pugili)
            {
                if (elemento.Nome == nomeUtente && elemento.Cognome == cognomeUtente)
                {
                    ris += elemento.Scheda() + "\n\n";

                }
            }

            foreach (Pilota elemento in piloti)
            {
                if (elemento.Nome == nomeUtente && elemento.Cognome == cognomeUtente)
                {
                    ris += elemento.Scheda() + "\n\n";

                }
            }
            return ris;
        }

        public string MediaEta()
        {

            string ris = "";
            double EtaTotCalciatori = 0;
            double EtaTotTennisti = 0;
            double EtaTotNuotatori = 0;
            double EtaTotPugili = 0;
            double EtaTotPiloti = 0;

            foreach (Calciatori elemento in calciatori)
            {
                EtaTotCalciatori += elemento.Eta; 
            }
            foreach (Tennisti elemento in tennisti)
            {
                EtaTotTennisti += elemento.Eta;
                
            }
            foreach (Nuotatore elemento in nuotatori)
            {
                EtaTotNuotatori += elemento.Eta;
            }

            foreach (Pugile elemento in pugili)
            {
                EtaTotPugili += elemento.Eta;
            }

            foreach (Pilota elemento in piloti)
            {
                EtaTotPiloti += elemento.Eta;
            }
            ris = $"L'età media dei calciatori è {EtaTotCalciatori / calciatori.Count} \nL'età media dei tennisti è {EtaTotTennisti / tennisti.Count} \nL'età media dei nuotatori è {EtaTotNuotatori / nuotatori.Count} \nL'età media dei pugili è {EtaTotPugili / pugili.Count} \nL'eta media dei piloti è {EtaTotPiloti / piloti.Count}";
            return ris;
        }
    }
}
