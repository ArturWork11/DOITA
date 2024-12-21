using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utility01;

namespace EsercizioConcessionaria
{
    internal interface MetodiIDAO : IDAO
    {
		List<Prodotto> ListaProdottiVecchi();
		string MaxDistanza();
		List<Macchina> AutoSuper();
		List<Moto> Sportive();
		List<Prodotto> Cerca(string categoria);
		Dictionary<string, int> frequenza();
		string CercaPerMarca(string marca);
		string StampaListe(List<Prodotto> array);
		List<Prodotto> TrovaSoluzione(double budgetMensile, int passeggeri);
		List<Macchina> Veloci();
		List<Prodotto> InOrdine();
    }
}
