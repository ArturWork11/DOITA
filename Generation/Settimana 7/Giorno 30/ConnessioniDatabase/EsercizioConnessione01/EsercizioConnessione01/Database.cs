﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioConnessione01
{
    internal class Database
    {
        private SqlConnection Connection { get; set; }

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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"\nQUERY ERRATA: \n{query}\n");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico \n{ex.Message}");
                return false;
            }
            finally 
            {
                Connection.Close();
            }
        }

        public List<Dictionary<string, string>> Read(string query)
        {
            List<Dictionary<string, string>> ris = new List<Dictionary<string, string>>();

            Connection.Open();
            SqlCommand cmd = new SqlCommand (query, Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Dictionary<string, string> row = new Dictionary<string, string>();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    row.Add(dr.GetName(i).ToLower(), dr.GetValue(i).ToString());
                }
                ris.Add(row);
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