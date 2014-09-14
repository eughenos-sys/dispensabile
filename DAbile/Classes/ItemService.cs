using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace DAbile.Classes
{
    public class ItemService
    {
        public Item LoadItem(int id)
        {
            database db = new database();
            Item i = null;
            string QueryItems = "SELECT * FROM ITEMS WHERE ID=" + id;

            OleDbConnection conn = db.getConnessione();
            OleDbDataReader reader = db.EseguiReader(QueryItems, conn);
            if (reader.Read())
            {
                i = new Item();
                i.id = Int32.Parse(reader["id"].ToString());
                i.marca = reader["marca"].ToString();
                i.prodotto = reader["prodotto"].ToString();
                i.quanti = reader["quanti"].ToString();
                i.scadenza = reader["scadenza"].ToString();

            }

            reader.Close();
            conn.Close();
            return i;
        }
    
        public int DeleteItem(int _id)
        {
            Data.DB.OleDbDatabase db = new Data.DB.OleDbDatabase();
            string query = "DELETE FROM ITEMS HWERE id=" + _id;
            return db.EseguiNonQuery(query);
        }

        public List<Item> ItemList()
        {
            database db = new database();
            OleDbConnection conn = db.getConnessione();
            List<Item> li = new List<Item>();
            Item i;
            string QueryItems = "SELECT * FROM ITEMS";
            OleDbDataReader reader = db.EseguiReader(QueryItems, conn);
            while (reader.Read())
            {
                i = new Item();
                i.id = Int32.Parse(reader["id"].ToString());
                i.marca = reader["marca"].ToString();
                i.prodotto = reader["prodotto"].ToString();
                i.quanti = reader["quanti"].ToString();
                i.scadenza = reader["scadenza"].ToString();
                if (i.marca != "0") { li.Add(i); }
                
            }
            reader.Close();
            conn.Close();
            return li;
        }

        public int InsertItem(Item i)
        {
            Data.DB.OleDbDatabase db = new Data.DB.OleDbDatabase();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "INSERT INTO ITEMS (marca,prodotto,quanti,scadenza) VALUES (?,?,?,?)";
            cmd.Parameters.AddWithValue("marca", i.marca);
            cmd.Parameters.AddWithValue("prodotto", i.prodotto);
            cmd.Parameters.AddWithValue("quanti", i.quanti);
            cmd.Parameters.AddWithValue("scadenza", i.scadenza);
            return db.EseguiNonQuery(cmd);
        }

        public int UpdateItem(Item i)
        {
            Data.DB.OleDbDatabase db = new Data.DB.OleDbDatabase();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "UPDATE ITEMS SET marca=?, prodotto=?, quanti=?, scadenza=? WHERE id=?";
            cmd.Parameters.AddWithValue("marca", i.marca);
            cmd.Parameters.AddWithValue("prodotto", i.prodotto);
            cmd.Parameters.AddWithValue("quanti", i.quanti);
            cmd.Parameters.AddWithValue("scadenza", i.scadenza);
            cmd.Parameters.AddWithValue("id", i.id);
            return db.EseguiNonQuery(cmd);
        }
    }
}