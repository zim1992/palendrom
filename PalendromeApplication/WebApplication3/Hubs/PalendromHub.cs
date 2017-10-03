using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebApplication3.Hubs
{
    public class PalendromHub : Hub
    {
        public void Update(int value)
        {
            Clients.All.Update(value);
        }
    }
}