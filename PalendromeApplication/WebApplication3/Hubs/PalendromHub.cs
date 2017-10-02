using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebApplication3.Hubs
{
    
    public class PalendromHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}