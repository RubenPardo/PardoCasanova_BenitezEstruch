using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Data.SQLite;
using System.Data;

namespace SOAP_WebService
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string pruebaSQL()
        {
            string DBpath = Server.MapPath("db.db");
            string query = "Insert ...";
            string a = "---";


            // select

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("Select * from User", conn);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    foreach (DataRow row in dt.Rows)
                    {
                        a += row["email"].ToString() + "-";
                        a += row["password"].ToString() + "\n";
                    }
                }

            }

            return a;
        }
    }
}
