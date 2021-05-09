using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
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

        public HtmlGenericControl getReservationsById(User u, HttpResponse response)
        {
            bool isClient = u.Type == TypeUser.Client;

            HtmlGenericControl divPadre = new HtmlGenericControl("div");
            divPadre.Attributes.Add("class", "div-reservation-list");

            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.Attributes.Add("class", "ul-reservation-list");

            divPadre.Controls.Add(ul);

            Reservation[] reservations = wb.getReservationByID(u.Id, false);
            if(reservations.Length != 0)
            {
                foreach (Reservation r in reservations)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes.Add("class", "li-reservation-list");

                    ul.Controls.Add(li);

                    HtmlGenericControl img = new HtmlGenericControl("img");
                    img.Attributes.Add("src", r.Room.UrlPhoto);
                    HtmlGenericControl name = new HtmlGenericControl("h4");
                    name.InnerText = r.Room.Name;
                    HtmlGenericControl description = new HtmlGenericControl("p");
                    description.InnerText = r.Room.Description;
                    HtmlGenericControl divCheckIn = new HtmlGenericControl("div");

                    li.Controls.Add(img);
                    li.Controls.Add(name);
                    li.Controls.Add(description);
                    li.Controls.Add(divCheckIn);

                    HtmlGenericControl h4Checkin = new HtmlGenericControl("h4");
                    h4Checkin.InnerText = "Check in";
                    h4Checkin.Attributes.Add("class", "reservation-list-check-in");
                    HtmlGenericControl pCheckin = new HtmlGenericControl("p");
                    pCheckin.InnerText = r.ArrivalDate + " / " + r.Nights + " Nights";

                    divCheckIn.Controls.Add(h4Checkin);
                    divCheckIn.Controls.Add(pCheckin);

                    HtmlGenericControl divPrice = new HtmlGenericControl("div");
                    divPrice.Attributes.Add("class", "reservation-price");
                    divPrice.InnerText = r.Room.Price;

                    li.Controls.Add(divPrice);


                    if (u.Type == TypeUser.Recepcionist)
                    {
                        HtmlGenericControl divButtons = new HtmlGenericControl("div");
                        divButtons.Attributes.Add("class", "reservation-logic");
                        HtmlButton btnUpdate = new HtmlButton();
                        btnUpdate.Attributes.Add("runat", "server");
                        btnUpdate.InnerText = "BTN";
                        btnUpdate.ServerClick += (object senderObject, EventArgs eventArgs) =>
                        {
                            callbackUpdateReservation(r, response);
                        };

                        divButtons.Controls.Add(btnUpdate);
                        li.Controls.Add(divButtons);

                    }




                }
            }
            else
            {
                HtmlGenericControl p = new HtmlGenericControl("p");
                p.InnerText = "There are no reservations";
                divPadre.Controls.Add(p);
            }

            
            return divPadre;
        }

        public bool deleteReservation(Reservation r)
        {
            return wb.delateReservation(r.Id);
        }

        public void callbackUpdateReservation(Reservation r, HttpResponse response)
        {

            HttpCookie reservation = new HttpCookie("reservation");
            reservation["r-id"] = r.Id.ToString();
            reservation["r-idClient"] = r.IdClient.ToString();
            reservation["r-idRecepcionist"] = r.IdRecepcionist.ToString();
            reservation["r-idRoom"] = r.Room.ID.ToString();
            reservation["r-name"] = r.Name;
            reservation["r-arrivalDate"] = r.ArrivalDate.ToString();
            reservation["r-night"] = r.Nights.ToString();
            response.Cookies.Add(reservation);

            response.Redirect("ReservationInfo.aspx?isModify="+true);
        }

        public User[] getAllClient()
        {
            return wb.getAllClient();
        }

        public bool createReservation(Reservation r)
        {
            return wb.createReservation(r);
        }

        public bool updateReservation(Reservation r)
        {
            return wb.updateReservation(r);
        }

    }

  
}