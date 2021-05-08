using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Data.SQLite;
using System.Data;
using SOAP_WebService.controller;
using SOAP_WebService.model;

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
        public User getUserByCredentials(string email, string password)
        {
            string DBpath = Server.MapPath(BDNames.BD_NAME);

            User res = new User();


            // select

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("Select * from " 
                    + BDNames.USER_TABLE 
                    + " WHERE "
                    + BDNames.USER_EMAIL+ "=@email " 
                    +"AND " 
                    + BDNames.USER_PASSWORD + "=@pass", conn);
                // prepared statment
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@pass", password);
                command.Prepare();

                Console.WriteLine(command.CommandText);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    foreach (DataRow row in dt.Rows)
                    {
                        res = new User(row);
                    }
                }

            }

            return res;
        }
    }
}
