using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using WebApplication3.Hubs;

namespace WebApplication3.Controllers
{
    public class PalendromController : Controller
    {
        IHubContext _hub = GlobalHost.ConnectionManager.GetHubContext<PalendromHub>();
        private int maxValue = 13;
        private int minValue = 4;
        private int sizeOfWord = 0;
        Random randNum = new Random();
        public AsyncController Palendrom()
        {
            while (true)
            {
                sizeOfWord = randNum.Next(minValue, maxValue);
                _hub.Clients.All.update(sizeOfWord);


            }
        }
        public async void BackEndCalculations() {
        }
    }
}