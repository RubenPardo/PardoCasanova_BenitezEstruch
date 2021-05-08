using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAP_WebService.controller;

namespace SOAP_WebService.model
{
    public class User
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public TypeUser Type { get; set; }

        public User() {
            Type = TypeUser.NotFound;
        }

        public User(int id,string email, string password, string name, TypeUser type ) {
            Id = id;
            Email = email;
            Password = password;
            Name = name;
            Type = type;
        
        }

        public User(System.Data.DataRow row)
        {
            Id = int.Parse(row[BDNames.USER_ID].ToString());
            Email = row[BDNames.USER_EMAIL].ToString();
            Password = row[BDNames.USER_PASSWORD].ToString();
            Name = row[BDNames.USER_NAME].ToString();
            Type = (TypeUser) int.Parse(row[BDNames.USER_TYPE].ToString());

        }

    }

    public enum TypeUser
    {
        Client = 1,
        Recepcionist = 2,
        NotFound
    }
}