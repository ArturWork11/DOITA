using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnessioniDatabase
{
    //Questa classe ha un solo compito: accedere al server utile, significa creare una connesione tra il Back-End(.NET) e il DBMS (SQL server)
    internal class Database
    {
        // Dato che .NET e SQL sono due linguaggi che non hanno nulla in comune tra loro, ci serve necessariamente qualcosa che funga da traduttore.
        // Per questo compito dobbiamo scaricare nel progetto un pacchetto nu.GET (cioè una libreria).
        // All'interno di questa libreria avremo tutti gli strumenti utili per far dialogare SQL con .NET e viceversa, in modo che possano capirsi e scambiarsi informazioni.

        // PASSAGGI
        // 1) Click sulla voce Progetto -> Gestisci pacchetti nu.get
        // 2) Nella pagina che si apre andare su sfoglia e cercare nella barra di ricerca "system.data.sqlclient"
        // 3) Cliccare sulla voce trovata e click sul bottone installa
        // 4) Accettare tutto l'accettabile, se va tutto bene troverete il pacchetto nella voce Dipendenze -> Pacchetti del vostro progetto.

        //NB: Ogni pacchetto vale solo per il progetto in cui lo scaricate 

        // CAMPI
        // Questo campo mi serve per sapere dove trovare il server del DBMS di turno
        private string server = "ARTUZPC";
        // Questo campo mi serve per sapere a quale DB accedere ai tanti sul server
        private string nomeDB = "LibreriaDOITA14";

        // Facoltativi: si usano solo se richiesti in fase di accesso al DBMS
        //private string username;
        //private string password;

        // Questo campo mi serve per creare la connessione tra BE e DBMS
        public SqlConnection connection;


        // PROPERTIES
        public SqlConnection Connection { get => connection; set => connection = value; }
        
        // COSTRUTTORE
        public Database()
        {
            // Stringa di connessione è:
            string stringaConnesione = $"Data Source={server};Initial Catalog={nomeDB};Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
            // Nel caso in cui si usino user/password per accedere la stringa sarà
            // string stringaConnessione $"Server={server};Database={nomeDB};User Id={user}:Password={password}";

            Connection = new SqlConnection(stringaConnesione);
        }
    }
}
