using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Script.Serialization;
using CasinoDataMVC.App_Start;
using CasinoDataMVC.DataProcessing;
using CasinoDataMVC.Models;
using Newtonsoft.Json;

namespace CasinoDataMVC.Controllers
{
    public class VendorsDataController : Controller
    {
        private MongoContext mongoDbContext;
        private csvTo2dArray _csvTo2DArray = new csvTo2dArray();
        

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
        
        [System.Web.Mvc.HttpGet]
        public JsonResult uploadCSV(string path)
        {
            Console.WriteLine("Path: " + path);
            return Json(_csvTo2DArray.csvToArray(path), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult getFiles()
        {
            string[] filePaths = Directory.GetFiles(@"C:\Cummins_Export_Files\", "*.csv",
                SearchOption.TopDirectoryOnly);
            return Json(filePaths, JsonRequestBehavior.AllowGet);
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