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
    public partial class Client : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic logic = new Logic();
            User u = new User();
            u.Id = 1;
            u.Type = TypeUser.Client;
            //prueba.Text = logic.getReservationsById(u);

        }
    }
}