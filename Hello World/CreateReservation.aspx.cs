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
    public partial class CreateReservation : System.Web.UI.Page
    {

        Room[] roomsAvailabes;
        User[] users;
        Logic logic;


        protected void Page_Load(object sender, EventArgs e)
        {
            logic = new Logic();
            
            if (!IsPostBack)
            {
                roomsAvailabes = logic.getRoomsAvailble();
                users = logic.getAllClient();
                bindRoomSelect();
                bindUserSelect();
            }

            

        }

        

        protected void onCreateReservation(object sender, EventArgs e)
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

            
            if (logic.createReservation(r)) {
                lblRes.Text = "Creada";
            }
            else
            {
                lblRes.Text = "Error al crear";
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