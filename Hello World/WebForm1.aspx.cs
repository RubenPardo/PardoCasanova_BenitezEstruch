using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SQLite;
using System.Data;

namespace Hello_World
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                spResult1.InnerText = "Post backs made";
            }
            else
            {
                spResult1.InnerText = "That was not a postback";
            }
           
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            txtResult1.Text = "Hello World!!";
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            string DBpath = Server.MapPath("items.db");
            string query = "Insert ...";

          

            /*using(SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand(query, conn);

                SQLiteDataAdapter da = new SQLiteDataAdapter();

                da.InsertCommand = command;
                da.InsertCommand.ExecuteNonQuery();// query is a select, the non query is the other operations
            }*/


            // select

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("Select item, price, avaible from furniture", conn);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    foreach (DataRow row in dt.Rows)
                    {
                        txtResult1.Text = row["item"].ToString();
                    }
                }
                   
            }



        }
    }
}