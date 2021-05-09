using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPage.localhost;

namespace WebPage
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CTA_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactPage.aspx");
        }

        protected void btnClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("Client.aspx");
        }
    }
}