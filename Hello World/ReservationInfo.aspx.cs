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
        Reservation r = new Reservation();

        protected void Page_Load(object sender, EventArgs e)
        {
            logic = new Logic();


            isModify = Request.QueryString["isModify"] != null;

            if (!IsPostBack)
            {

                roomsAvailabes = logic.getRoomsAvailble();
                users = logic.getAllClient();
                bindRoomSelect();
                bindUserSelect();

                if (isModify)
                {
                    
                    bindForm();

                }
            }
            if (isModify)
            {
                addButtonModify();
            }
        }

        private void addButtonModify()
        {
            HttpCookie reservation = Request.Cookies["reservation"];
            r.Id = int.Parse(reservation["r-id"]);

            HtmlButton btnDelete = new HtmlButton();
            btnDelete.Attributes.Add("runat", "server");
            btnDelete.InnerText = "Delete Reservation";
            btnDelete.ServerClick += onDeleteReservation;

            HtmlButton btnUpdate = new HtmlButton();
            btnUpdate.Attributes.Add("runat", "server");
            btnUpdate.InnerText = "Update Reservation";
            btnUpdate.ServerClick += onUpdate;

            btnForm.Visible = false;

            btnForms.Controls.Add(btnUpdate);
            btnForms.Controls.Add(btnDelete);
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

        protected void onUpdate(object sender, EventArgs e)
        {
            // chcek form
            r.IdRecepcionist = 2;// cambiar a por el user
            r.Name = txtName.Value;
            r.ArrivalDate = txtDate.Value;
            r.Nights = int.Parse(txtNights.Value);


            Room room = new Room();
            room.ID = int.Parse(slctRoom.Value);
            r.Room = room;

            r.IdClient = int.Parse(slctUser.Value);

            if (logic.updateReservation(r))
            {
                lblRes.Text = "Updated Correctly";
                Response.Redirect("Receptionist.aspx");
            }
            else
            {
                lblRes.Text = "Error when updating";
            }
        }

        protected void onSumbitForm(object sender, EventArgs e)
        {


            // chcek form
            r.IdRecepcionist = 2;// cambiar a por el user
            r.Name = txtName.Value;
            r.ArrivalDate = txtDate.Value;
            r.Nights = int.Parse(txtNights.Value);

            Room room = new Room();
            room.ID = int.Parse(slctRoom.Value);
            r.Room = room;

            r.IdClient = int.Parse(slctUser.Value);


            if (logic.createReservation(r))
            {
                lblRes.Text = "Created correctly";
            }
            else
            {
                lblRes.Text = "Error when creating";
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
            if (roomsAvailabes.Length == 0)
            {
                ListItem l = new ListItem();
                l.Value = "-1";
                l.Text = "There are no rooms available right now";
                slctRoom.Items.Add(l);
                slctRoom.Disabled = true;
            }

            foreach (Room r in roomsAvailabes)
            {
                ListItem l = new ListItem();
                l.Value = r.ID.ToString();
                l.Text = r.Name;
                slctRoom.Items.Add(l);
            }
        }
    }


}