using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCrud
{
    internal class Database
    {
        private SqlConnection Connection { get; set; }

        // PARAMETRI OPZIONALI
        // Sono parametri che possono essere inseriti dall'utente o meno in base alla necessità.
        // Nel nostro esempio potremo chiamare questo costruttore in 2 modi:
        //      1) Database("Libreria") -> in questo caso nomeDB sarà "Libreria" mentre server sarà "ARTUZPC"
        //      2) Database("Libreria","Mio") -> In questo caso nomeDB sarà "Libreria" mentre server sarà "Mio"
        public Database(string nomeDB, string server = "ARTUZPC")
        {
            Connection = new SqlConnection($"Data Source={server};Initial Catalog={nomeDB};Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        }

        public bool Update(string query)
        {
            try
            {
                Connection.Open();

                SqlCommand cmd = new SqlCommand(query, Connection);
                int affette = cmd.ExecuteNonQuery();

                return affette > 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"\nQUERY ERRATA: \n{query}\n");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Errore generico \n{e.Message}");
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<Dictionary<string, string>> Read(string query)
        {
            List<Dictionary<string, string>> ris = new();

            Connection.Open();
            SqlCommand cmd = new SqlCommand(query, Connection);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Dictionary<string, string> riga = new();

                for (int i = 0; i < dr.FieldCount; i++)
                {
                    riga.Add(dr.GetName(i).ToLower(), dr.GetValue(i).ToString());

                    // SINTASSI NUOVA
                    // dr.FieldCount -> restituisce il numero di colonne presenti nella tabella risultante
                    // dr.GetName() --> restituisce il nome della colonna nella posizione passata come parametro
                    // dr.GetValue() -> rstituisce il valore della cella nella posizione passata come parametro



                }
                ris.Add(riga);
            }
            Connection.Close();
            return ris;
        }

        public Dictionary<string, string> ReadOne(string query)
        {
            try
            {
                return Read(query)[0];
            }
            catch
            {
                return null;
            }
        }
    }
}
