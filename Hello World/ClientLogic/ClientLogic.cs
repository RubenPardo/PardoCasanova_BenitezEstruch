using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPage.localhost;

namespace WebPage.ClientLogic
{
    public class ClientLogic
    {
        private WebService1 wb;
        public ClientLogic()
        {
            wb = new WebService1();
        }

        public void prueba()
        {
            wb.getRooms(true).Select(r =>
            {
                return r;
            });
        }

    }
}