using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPage.ClientLogic;
using WebPage.localhost;

namespace WebPage
{
    public partial class Receptionist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Logic logic = new Logic();
                User u = new User();
                u.Id = 2;
                u.Type = TypeUser.Recepcionist;
                pruebaRcp.Text = logic.getReservationsById(u);
            }
        }

        public void MyFunction(object sender, EventArgs e)
        {
            Console.WriteLine("FUNCION");
        }

        protected void btnReservation_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateReservation.aspx");
        }
    }
}