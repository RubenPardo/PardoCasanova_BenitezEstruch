using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows;
using WebPage.ClientLogic;
using WebPage.localhost;

namespace WebPage
{
    public partial class Receptionist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            createDynamicListReservations();
        }

        private void createDynamicListReservations()
        {
            Logic l = new Logic();
            User u = new User();
            u.Id = 2;
            u.Type = TypeUser.Recepcionist;
            HtmlGenericControl content = l.getReservationsById(u, Response);
            pruebaRcp.Controls.Add(content);
        }


        protected void btnReservation_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReservationInfo.aspx");
        }
    }
}