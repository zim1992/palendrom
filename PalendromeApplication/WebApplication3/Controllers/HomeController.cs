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

        
        
        private static IList<string> _palendroms;
        
        
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