using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPage.localhost;

namespace WebPage.ClientLogic
{
    public class ClientLogic
    {
        WebService1 wb;
        public ClientLogic()
        {
            wb = new WebService1();
        }
    }
}