using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

namespace Data.DB
{
    public class OleDbDatabase : IDisposable
    {
        protected string dbPath;
        protected string dbUser;
        protected string dbPass;
        protected string dbConnString;


        public OleDbDatabase()
        {
            this.dbPath = ConfigurationManager.AppSettings["OleDbPath"];
            this.dbConnString = ConfigurationManager.AppSettings["OleDbConnectionString"];
            this.dbUser = ConfigurationManager.AppSettings["OleDbUser"];
            this.dbPass = ConfigurationManager.AppSettings["OleDbPassword"];
        }

        public OleDbConnection getConnessione()
        {
            try
            {
                string strConn = this.dbConnString + System.Web.HttpContext.Current.Server.MapPath("~") + this.dbPath + ";";

                if (!String.IsNullOrEmpty(this.dbUser))
                    strConn += "User Id=" + this.dbUser + ";";

                if (!String.IsNullOrEmpty(this.dbPass))
                    strConn += "Password=" + this.dbPass + ";";

                OleDbConnection con = new OleDbConnection(strConn);

                return con;
            }
            catch (OleDbException ex)
            {
                //Gestione dell'errore
                //Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool checkConnessione()
        {
            using (OleDbConnection conn = this.getConnessione())
            {
                try
                {
                    conn.Open();

                    if (conn.State != ConnectionState.Open)
                    {
                        return false;
                    }
                    return true;
                }
                catch (OleDbException ex)
                {
                    return false;
                }
            }
        }

        public void CaricaDataTable(string query, DataTable dt)
        {
            try
            {
                OleDbConnection conn = this.getConnessione();
                OleDbDataAdapter adp = new OleDbDataAdapter(query, conn);
                adp.Fill(dt);
            }
            catch (OleDbException exSql)
            {
                throw new Exception("Carica Data Table Exception", exSql);
            }
        }

        public void CaricaDataTable(OleDbCommand _command, DataTable _dt)
        {
            try
            {
                _command.Connection = this.getConnessione();
                OleDbDataAdapter adp = new OleDbDataAdapter(_command);
                adp.Fill(_dt);
            }
            catch (OleDbException exSql)
            {
                throw new Exception("Carica Data Table Exception", exSql);
            }
        }


        public OleDbDataReader CaricaDataReader(string query, OleDbConnection connessione)
        {
            try
            {
                OleDbCommand sql = new OleDbCommand(query, connessione);
                connessione.Open();
                OleDbDataReader toReturn = sql.ExecuteReader();
                return toReturn;
            }
            catch (OleDbException exSql)
            {
                throw new Exception("Carica Data Reader Exception", exSql);
            }
            finally { connessione.Close(); }
        }

        /// <returns>Restituisce il numero delle righe modificate</returns>
        public int EseguiNonQuery(OleDbCommand cmd)
        {OleDbConnection conn = this.getConnessione();
        try
        {
            cmd.Connection = conn;
            conn.Open();
            return cmd.ExecuteNonQuery();

        }
        finally { conn.Close(); }
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
            long totMem = System.GC.GetTotalMemory(false);
        }

        public int EseguiNonQuery(string sql)
        {
            using (OleDbConnection conn = this.getConnessione())
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    conn.Open();
                    return cmd.ExecuteNonQuery();

                }
                catch (OleDbException exSql)
                {
                    throw new Exception("EseguiScalar Exception", exSql);
                }
                finally
                { conn.Close(); }
           
        }

        internal OleDbDataReader CaricaDataReader(string querypagina)
        {
            throw new NotImplementedException();
        }
    }
}