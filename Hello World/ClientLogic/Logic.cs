﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
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

        public void getRoomsAvailble()
        {
            wb.getRooms(true).Select(r =>
            {
                return r;
            });
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

                }
                htmlBuilder.AppendLine("</ul> </li> ");
            }
           
            htmlBuilder.AppendLine("</div>");
            return htmlBuilder.ToString();
        }

    }
}