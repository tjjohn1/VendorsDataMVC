using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using CasinoDataMVC.App_Start;

namespace CasinoDataMVC.Controllers
{
    public class VendorsDataController : Controller
    {
        private MongoContext mongoDbContext;

        public VendorsDataController()
        {
            mongoDbContext = new MongoContext();
        }

        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult ProcessCSV()
        {
            return View();
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