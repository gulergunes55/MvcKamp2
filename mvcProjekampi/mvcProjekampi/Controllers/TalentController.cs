using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcProjekampi.Controllers
{
    public class TalentController : Controller
    {
        // GET: Talent
        TalentManager tln = new TalentManager(new EfTalentDal());
        public ActionResult Index()
        {
            var talas= tln.GetList();
            return View(talas);
        }

        public ActionResult TalentCart()
        {
            var talas = tln.GetList();
            return View(talas);
        }

        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(Talent talent)
        {
            tln.TalentAdd(talent);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTalent(int id)
        {
            var result = tln.GetByID(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateTalent(Talent talent)
        {
            tln.TalentUpdate(talent);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTalent(int id)
        {
            var result = tln.GetByID(id);
            tln.TalentDelete(result);
            return RedirectToAction("Index");
        }

    }

    }
