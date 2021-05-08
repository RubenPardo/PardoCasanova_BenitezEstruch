using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_WebService.controller
{
    public class BDNames
    {

        public static string BD_NAME = "db.db";

        // user table ----------------------------------------
        public static string USER_TABLE = "User";

        public static string USER_ID = "id";
        public static string USER_EMAIL = "email";
        public static string USER_PASSWORD = "password";
        public static string USER_NAME = "userName";
        public static string USER_TYPE = "typeUser";

        // reservation table ----------------------------------------
        public static string RESERVATION_TABLE = "Reservation";

        public static string RESERVATION_ID_CLIENT = "idClient";
        public static string RESERVATION_ID_RECEPCIONIST = "idRecepcionist";
        public static string RESERVATION_ID_ROOM = "idRoom";
        public static string RESERVATION_NAME = "reservationName";
        public static string RESERVATION_ARRIVAL_DATE = "arrivalDate";
        public static string RESERVATION_NIGHTS = "reservationNights";

        // room table ----------------------------------------
        public static string ROOM_TABLE = "Room";

        public static string ROOM_ID = "id";
        public static string ROOM_NAME = "roomName";
        public static string ROOM_TYPE = "typeRoom";
        public static string ROOM_DESCRIPTION = "roomDescription";
        public static string ROOM_AVAILABLE = "available";
        public static string ROOM_PRICE = "available";
    }
}