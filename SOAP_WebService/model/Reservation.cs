using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAP_WebService.controller;

namespace SOAP_WebService.model
{
    public class Reservation
    {

        public int IdClient { get; set; }
        public int IdRecepcionist { get; set; }
        public Room Room { get; set; }
        public string Name { get; set; }
        public string ArrivalDate { get; set; }
        public int Nights { get; set; }

        public Reservation() { }

        public Reservation(int vC, int vR, Room room,string name, string date, int nights)
        {
            IdClient = vC;
            IdRecepcionist = vR;
            Room = room;
            Name = name;
            ArrivalDate = date;
            Nights = nights;

        }

        public Reservation(System.Data.DataRow row)
        {
            
            IdRecepcionist = int.Parse(row[BDNames.RESERVATION_ID_RECEPCIONIST].ToString());
            IdClient = int.Parse(row[BDNames.RESERVATION_ID_CLIENT].ToString());
            Nights = int.Parse(row[BDNames.RESERVATION_NIGHTS].ToString());
            Name = row[BDNames.RESERVATION_NAME].ToString();
            ArrivalDate = row[BDNames.RESERVATION_ARRIVAL_DATE].ToString();

            Room = new Room(
                 int.Parse(row[BDNames.RESERVATION_ID_ROOM].ToString()),
                 row[BDNames.ROOM_TYPE].ToString(),
                 row[BDNames.ROOM_NAME].ToString(),
                 row[BDNames.ROOM_DESCRIPTION].ToString(),
                 float.Parse(row[BDNames.ROOM_PRICE].ToString()),
                 row[BDNames.ROOM_AVAILABLE].ToString() == "1"
            );
        }
    }
}