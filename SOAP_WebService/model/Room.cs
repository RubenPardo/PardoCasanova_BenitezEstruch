using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        }

    }

   
}