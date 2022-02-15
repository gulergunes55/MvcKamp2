using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcProjekampi.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        ImageFileManager ifm = new ImageFileManager(new EfImagesfileDal());
        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }
    }
}