using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility01;

namespace EsercizioConcessionaria
{
    internal class DAOMacchine : IDAO 
    {
        private IDatabase db;
        private DAOMacchine()
        {
            db = new Database("Concessionaria");
        }
        private static DAOMacchine instance = null;
        public static DAOMacchine GetInstance()
        {
            if (instance == null)
                instance = new DAOMacchine();
            return instance;
        }
        public bool Create(Entity e)
        {
            return db.Update($"INSERT INTO Macchine (id, cilindrata, velocitaMax, postiMacchina)\r\n" +
                             $"VALUES " +
                             $"({(((Macchina)e).Id != null ? ((Macchina)e).Id : "null")} ," +
                             $" {((Macchina)e).Cilindrata}, " +
                             $" {((Macchina)e).VelocitaMax}, " +
                             $" {((Macchina)e).PostiMacchina}); ");
        }

        public bool Delete(int id)
        {
            return db.Update($"DELETE FROM Macchine WHERE id = {id};");
        }

        public Entity Find(int id)
        {
            var riga = db.ReadOne($"SELECT * FROM Macchine WHERE id = {id};");
            if (riga != null)
            {
                Entity e = new Macchina();
                e.FromDictionary(riga);

                return e;
            }
            else
                return null;
        }

        public List<Entity> Read()
        {
            List<Entity> list = new List<Entity>();
            var righe = db.Read($"SELECT * FROM Macchine;");
            foreach (var riga in righe)
            {
                Entity e = new Macchina();
                e.FromDictionary(riga);

                list.Add(e);
            }
            return list;
        }

        public bool Update(Entity e)
        {
       
           return db.Update($"UPDATE Macchine SET " +
                            $"id = {(((Macchina)e).Id != null ?  ((Macchina)e).Prodotto.Id : "null")}," +
                            $"cilindrata = {((Macchina)e).Cilindrata}, " +
                            $"velocitaMax = {((Macchina)e).VelocitaMax}, " +
                            $"postiMacchina = {((Macchina)e).PostiMacchina}, " +
                            $"WHERE id = {e.Id};");
        }

        public List<Macchina> AutoSuper()
        {
            List<Macchina> list = new List<Macchina>();
            var righe = db.Read($"SELECT p.id AS ProdottoId, m.id , p.categoria,p.marca,p.affittabile,p.annoImmatricolazione,p.consumoMedioAKM,p.capienzaSerbatoio,m.cilindrata,m.velocitaMax,m.postiMacchina\r\nFROM Prodotti p join Macchine m\r\nON m.id = p.id\r\nWHERE categoria = 'macchina';");
            foreach (var riga in righe)
            {
                Entity e = new Macchina();
                e.FromDictionary(riga);
                if (((Macchina)e).Potente())
                    list.Add((Macchina)e);

               
            }

            foreach (var riga in list)
                Console.WriteLine(riga.ToString());

            return list;
        }

        public List<Macchina> Veloci()
        {
            
            Console.WriteLine("Inserisci la velocita minima di cui vuoi vedere le macchine");
            int velocita = int.Parse(Console.ReadLine());
            List<Macchina> autoVeloci = new();
            var righe = db.Read($"SELECT p.id AS ProdottoId, m.id, p.categoria,p.marca,p.affittabile,p.annoImmatricolazione,p.consumoMedioAKM,p.capienzaSerbatoio,m.cilindrata,m.velocitaMax,m.postiMacchina\r\nFROM Prodotti p join Macchine m\r\nON m.id = p.id\r\nWHERE categoria = 'macchina' AND velocitaMax > {velocita};");
            foreach (var riga in righe)
            {
                Entity e = new Macchina();
                e.FromDictionary(riga);

                   
                autoVeloci.Add((Macchina)e);
                
            }

            foreach (var riga in autoVeloci)
                 Console.WriteLine(riga.ToString());

            return autoVeloci;
        }

        
    }
    
}
