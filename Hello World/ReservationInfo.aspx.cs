using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebPage.ClientLogic;
using WebPage.localhost;

namespace WebPage
{
    public partial class CreateReservation : System.Web.UI.Page
    {

        Room[] roomsAvailabes;
        User[] users;
        Logic logic;
        bool isModify;
        Reservation r;

        protected void Page_Load(object sender, EventArgs e)
        {
            logic = new Logic();
            


            isModify = Request.QueryString["isModify"] != null;

            
            roomsAvailabes = logic.getRoomsAvailble();
            users = logic.getAllClient();
            bindRoomSelect();
            bindUserSelect();

            if (isModify)
            {
                HtmlButton btnDelete = new HtmlButton();
                btnDelete.Attributes.Add("runat", "server");
                btnDelete.InnerText = "Delete";
                btnDelete.ServerClick += onDeleteReservation;
                btnForms.Controls.Add(btnDelete);

                bindForm();
                btnForm.Text = "Update Reservation";
            }

            

            

        }

        protected void onDeleteReservation(object sender, EventArgs e)
        {
            
            Logic l = new Logic();
            if (l.deleteReservation(r))
            {
                Response.Redirect("Receptionist.aspx");
            }
            else
            {
                lblRes.Text = "Erro when Deleting";
            }
           
            

        }

        private void bindForm()
        {
            r = new Reservation();
            Room room = new Room();
            HttpCookie reservation = Request.Cookies["reservation"];

            r.Id = int.Parse(reservation["r-id"]);
            r.IdClient = int.Parse(reservation["r-idClient"]);
            r.IdRecepcionist = int.Parse(reservation["r-idRecepcionist"]);
            room.ID = int.Parse(reservation["r-idRoom"]);
            r.Room = room;
            r.Nights = int.Parse(reservation["r-night"]);
            r.Name = reservation["r-name"];
            r.ArrivalDate = reservation["r-arrivalDate"];

            txtName.Value = r.Name;
            txtNights.Value = r.Nights.ToString();
            txtDate.Value = r.ArrivalDate;
            slctRoom.Value = r.Room.ID.ToString();
            slctUser.Value = r.IdClient.ToString();


        }

        protected void onSumbitForm(object sender, EventArgs e)
        {
            string name = txtName.Value;
            string nights = txtNights.Value;
            string date = txtDate.Value;
            string idRoom = slctRoom.Value;
            string idClient = slctUser.Value;

            // chcek form

            Reservation r = new Reservation();
            r.IdRecepcionist = 2;// cambiar a por el user
            r.Name = name;
            r.ArrivalDate = date;
            r.Nights = int.Parse(nights);

            Room room = new Room();
            room.ID = int.Parse(idRoom);
            r.Room = room;

            r.IdClient = int.Parse(idClient);

            if (isModify)
            {
                if (logic.updateReservation(r))
                {
                    lblRes.Text = "Updated Correctly";
                }
                else
                {
                    lblRes.Text = "Error when updating";
                }
            }
            else
            {
                if (logic.createReservation(r))
                {
                    lblRes.Text = "Created correctly";
                }
                else
                {
                    lblRes.Text = "Error when creating";
                }
            }
            
            




        }

        private void bindUserSelect()
        {
            if (users.Length == 0)
            {
                ListItem l = new ListItem();
                l.Value = "-1";
                l.Text = "There are no users";
                slctUser.Items.Add(l);
                slctUser.Disabled = true;
            }

            foreach (User u in users)
            {
                ListItem l = new ListItem();
                l.Value = u.Id.ToString();
                l.Text = u.Name;
                slctUser.Items.Add(l);
            }
        }

        private void bindRoomSelect()
        {
            if(roomsAvailabes.Length == 0)
            {
                ListItem l = new ListItem();
                l.Value = "-1";
                l.Text = "There are no rooms available right now";
                slctRoom.Items.Add(l);
                slctRoom.Disabled = true;
            }

            foreach(Room r in roomsAvailabes)
            {
                ListItem l = new ListItem();
                l.Value = r.ID.ToString();
                l.Text = r.Name;
                slctRoom.Items.Add(l);
            }
        }
    }
}