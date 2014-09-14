using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DAbile.Classes
{
    public class database
    {
        protected string dbPath;
        protected string dbUser;
        protected string dbPass;
        protected string dbConnString;
        public database()
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
            {return null;}
        }
        public OleDbDataReader EseguiReader(string _query, OleDbConnection conn)
        {
            conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = _query;
                cmd.Connection = conn;
                return cmd.ExecuteReader();
       }
        public bool AggiornaDB(string _query)
        {OleDbConnection conn = this.getConnessione();
        try
        {
            OleDbCommand upd = new OleDbCommand(_query, conn);
            if (conn.State != ConnectionState.Open)
            upd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        finally {conn.Close();}
        }

        public int InserisciDB(string _query)
        {
            using (OleDbConnection conn = this.getConnessione())
                try
                {
                    OleDbCommand ins = new OleDbCommand(_query, conn);
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    ins.ExecuteNonQuery();

                    string sql = "SELECT @@IDENTITY;";
                    object result;

                    ins.CommandText = sql;
                    result = ins.ExecuteScalar();
                    return Int32.Parse(result.ToString());
                }
                catch (System.Exception)
                                     {return 0;}
                finally {conn.Close();}
        }
    }
}