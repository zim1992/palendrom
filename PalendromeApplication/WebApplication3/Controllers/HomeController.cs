using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using WebApplication3.Hubs;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        IHubContext _hub = GlobalHost.ConnectionManager.GetHubContext<PalendromHub>();
        private int maxValue = 13;
        private int minValue = 4;

        private string[] PalendromArray = new string[20];
        private string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "u", "t", "v", "w", "x", "y", "z" };
        Random randNum = new Random();

        private static IList<string> _palendroms;

        public string[] PalendromWord { get; private set; }

        public HomeController()
        {
            if (_palendroms == null)
                _palendroms = new List<string>();
            

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