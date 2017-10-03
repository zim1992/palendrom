using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using WebApplication3.Hubs;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {

        
        private static IHubContext _hub = GlobalHost.ConnectionManager.GetHubContext<PalendromHub>();
        private static IList<string> _palendroms;
        private int maxValue = 13;
        private int minValue = 4;
        private int sizeOfWord = 0;
        Random randNum = new Random();
        public HomeController()
        {
            if (_palendroms == null)
                _palendroms = new List<string>();
            //Palendrom();
        }
        public void Palendrom()
        {
            while (true)
            {
                sizeOfWord = randNum.Next(minValue, maxValue);
                

            }
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}