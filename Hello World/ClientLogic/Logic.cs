using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using WebPage.localhost;

namespace WebPage.ClientLogic
{
    public class Logic
    {
        private WebService1 wb;
        public Logic()
        {
            wb = new WebService1();
        }

        public Room[] getRoomsAvailble()
        {
            return wb.getRooms(true);
        }

        public string getReservationsById(User u)
        {
            bool isClient = u.Type == TypeUser.Client;
            StringBuilder htmlBuilder = new StringBuilder();

            Reservation[] reservations = wb.getReservationByID(u.Id, isClient);
            htmlBuilder.AppendLine("<div class='div-reservation-list'>");
            if(reservations.Length == 0)
            {
                htmlBuilder.AppendLine("You don't have any reservation");
            }
            else
            {
                htmlBuilder.AppendLine("<ul class='ul-reservation-list'> <li class='li-reservation-list'> ");
                foreach (Reservation r in reservations)
                {
                    htmlBuilder.AppendLine("<img src='"+r.Room.UrlPhoto+ "' />");
                   
                    htmlBuilder.AppendLine("<h3>" + r.Name + "</h3>");
                    htmlBuilder.AppendLine("<h4>" + r.Room.Name  + "</h4>");
                    htmlBuilder.AppendLine("<p>" + r.Room.Description + "</p>");
                    htmlBuilder.AppendLine("<div> <h4 class='reservation-list-check-in'>Check in</h4><p>"+
                        r.ArrivalDate+" / "+ r.Nights + " Nights</p></div> ");
                    htmlBuilder.AppendLine("<div class='reservation-price'>" + r.Room.Price + "</div>");
                    
                    if(u.Type == TypeUser.Recepcionist)
                    {
                        htmlBuilder.AppendLine("<div class='reservation-logic'>");
                        htmlBuilder.AppendLine("<button  runat='server' text='Button' onclick='MyFunction' OnClientClick='return false;'>Button</Button>");
                        
                        htmlBuilder.AppendLine("</div>");
                    }

                }
                htmlBuilder.AppendLine("</ul> </li> ");
            }
           
            htmlBuilder.AppendLine("</div>");
            return htmlBuilder.ToString();
        }

        public User[] getAllClient()
        {
            return wb.getAllClient();
        }

        public bool createReservation(Reservation r)
        {
            return wb.createReservation(r);
        }

        private void MyFunction(object sender, EventArgs e)
        {
            Console.WriteLine("Xdddd");
        }
    }

  
}