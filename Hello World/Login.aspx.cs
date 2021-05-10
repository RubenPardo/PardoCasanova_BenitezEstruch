using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPage.ClientLogic;
using System.Data.SqlClient;
using System.Web.Security;
using WebPage.localhost;

namespace WebPage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated && Session["role"] == TypeUser.Client.ToString())
                {
                    Response.Redirect("Client.aspx");
                }
                else if (HttpContext.Current.User.Identity.IsAuthenticated && Session["role"] == TypeUser.Recepcionist.ToString())
                {
                    Response.Redirect("Receptionist.aspx");
                }
            }
            else
            {
                if (!Page.IsPostBack)
                {

                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User u = new User();
            Logic logic = new Logic();
            u = logic.getUserByCredentials(txtUserName.Value, txtUserPass.Value);

            if(u!= null)
            {
                
                Session["id"] = u.Id;
                Session["name"] = u.Name;
                Session["role"] = u.Type.ToString();
                Session.Timeout = 20;

                if (u.Type == TypeUser.Client)
                {
                    FormsAuthentication.SetAuthCookie(txtUserName.Value, true);
                    Response.Redirect("Client.aspx");
                }
                else if(u.Type == TypeUser.Recepcionist)
                {
                    FormsAuthentication.SetAuthCookie(txtUserName.Value, true);
                    Response.Redirect("Receptionist.aspx");
                }
                else
                {
                    Warninglogin.Text = "Please enter a valid username and password";
                }
            }
        }
    }
}