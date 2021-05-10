using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
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
            if (HttpContext.Current.User.Identity.IsAuthenticated && Session["role"] == TypeUser.Recepcionist.ToString())
            {
                createDynamicListReservations();
            }
            else
            {
                FormsAuthentication.SignOut();
                Session.Clear();  
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
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

        private void LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();  // This may not be needed -- but can't hurt
            Session.Abandon();

            // Clear authentication cookie
            HttpCookie rFormsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            rFormsCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(rFormsCookie);

            // Clear session cookie 
            HttpCookie rSessionCookie = new HttpCookie("ASP.NET_SessionId", "");
            rSessionCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(rSessionCookie);

            Response.Redirect("Login.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            LogOff();
        }
    }
}