using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConnessioniDatabase
{
    //DAO-> sta per data access object
    //se inizia con DAO significa che le classi hanno il compito di gestire gli scambi di informazioni sta vs e sql

    internal class DAOLibri
    {
        private Database db;

        public DAOLibri()
        {
            db = new Database();

        }

        public List<Entity> Read() //metodo che legga i record della tabella libri e li trasformo in oggetti
        {
            List<Entity> ris = new();

            // STEP 1: APRO LA CONNESSIONE   
            db.connection.Open();

            // STEP 2: scrivere la richiesta per il DBMS (query)
            string query = "SELECT * FROM Libri"; 

            // STEP 3: Creare il messaggero che presa la richiesta, percorra la connessione e la porti al DBMS
            SqlCommand cmd = new SqlCommand(query, db.connection);  

            // STEP 4: Faremo eseguire al DBMS la richiesta e poi acquisiremo la risposta calcolata
            SqlDataReader dr = cmd.ExecuteReader();

            //step 5: esamino la risposta del DBMS e la trasformo in quello che mi serve
            //        (in questo caso significa trasformare i dati in oggetti Entity e salvarli nella lista ris)
            while (dr.Read())
            {
                Entity e = new Libro(
                                        dr.GetInt32(0),//id
                                        dr.GetString(1),//titolo
                                        dr.GetString(2),//autore
                                        dr.GetString(3),//genere
                                        dr.GetInt32(4)  //anno_pubblicazione
                                    );
                ris.Add(e);
            }

            // STEP 6: Chiudo il DataReader e la connessione
            dr.Close();
            db.connection.Close(); //una volta aperta bisogna chiuderla

            return ris;

        }

        // Scrivere un metodo che restituisca i libri usciti dal 2000 in poi
        public List<Entity> LibriDal2000() 
        {
            List<Entity> ris = new List<Entity>();
            db.connection.Open();
            string query = "SELECT * \r\nFROM Libri \r\nWHERE anno_pubblicazione >= 2000;"; 
            SqlCommand cmd = new SqlCommand(query,db.connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Entity e = new Libro(
                                         dr.GetInt32(0),
                                         dr.GetString(1),
                                         dr.GetString(2),
                                         dr.GetString(3),
                                         dr.GetInt32(4)
                                     );
                ris.Add(e);
            }
            dr.Close();
            db.connection.Close(); 
            return ris;
        }
        // Scrivere un metodo che restituisca tutti i libri di un autore a scelta dall'utente
        public List<Entity> LibriAutoreUser(string autore) 
        {
            List<Entity> ris = new List<Entity> ();
            db.connection.Open();
            string query = $"SELECT * \r\nFROM Libri\r\nWHERE Autore = '{autore}';";
            SqlCommand cmd = new SqlCommand(query,db.connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                Entity e = new Libro(
                                        dr.GetInt32(0),
                                        dr.GetString(1),
                                        dr.GetString(2),
                                        dr.GetString(3),
                                        dr.GetInt32(4)

                                    );
                ris.Add(e);

            }
            dr.Close(); 
            db.connection.Close();  
            return ris;
        }
    }
}
