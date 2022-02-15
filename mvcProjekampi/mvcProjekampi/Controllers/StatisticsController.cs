using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using Context = DataAccessLayer.Concrete.Context;

namespace mvcProjekampi.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics

        Context c = new Context();
        public ActionResult Index()
        {
            var toplamkategori = c.Categories.Count();
            ViewBag.d1 = toplamkategori;

            var yazilimkategori = c.Headings.Count(x => x.HeadingID == 5);
            ViewBag.d2 = yazilimkategori;

            var yazaradiA = c.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.d3 = yazaradiA;

            var enkategori = c.Headings.Max(x => x.Category.CategoryName);
            ViewBag.d4 = enkategori;

            var categorytruefalse = c.Categories.Count(x => x.CategoryStatus == false) ; 
            ViewBag.d5 = categorytruefalse;
        
            return View();
        }
        
        public ActionResult deneme()
        {
            return View();
        }
    }
}