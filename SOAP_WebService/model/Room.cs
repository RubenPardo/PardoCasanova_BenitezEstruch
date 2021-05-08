using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAP_WebService.controller;

namespace SOAP_WebService.model
{
    public class Room
    {
        public int ID { get; set; }
        public string TypeRoom { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public bool Available { get; set; }

        public Room()
        {

        }
        
        public Room(int id, string typeRoom,string name, string description,float price, bool available)
        {
            ID = id;
            TypeRoom = typeRoom;
            Name = name;
            Description = description;
            Price = price;
            Available = available;

        }

        public Room(System.Data.DataRow row)
        {
            ID = int.Parse(row[BDNames.ROOM_ID].ToString());
            TypeRoom = row[BDNames.ROOM_TYPE].ToString();
            Name = row[BDNames.ROOM_NAME].ToString();
            Description = row[BDNames.ROOM_DESCRIPTION].ToString();
            Price = float.Parse(row[BDNames.ROOM_PRICE].ToString());
            Available = row[BDNames.ROOM_AVAILABLE].ToString() == "1";
        }

    }

   
}