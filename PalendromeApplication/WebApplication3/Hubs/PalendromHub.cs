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
        Random rand = new Random();
        public void Update(int MaxValue, int MinValue)
        {
            int value =  rand.Next(MinValue, MaxValue);
            Clients.All.Update(value);
        }
    }
}