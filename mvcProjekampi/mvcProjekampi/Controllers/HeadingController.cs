﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcProjekampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager vm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value =x.CategoryID.ToString()
                                                  }).ToList() ;


            List<SelectListItem> valuewriter = (from x in vm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName+" "+x.WriterSurName,
                                                    Value=x.WriterID.ToString()
                                                }).ToList();
            
            ViewBag.vlc = valuecategory;
            ViewBag.vm = valuewriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }
       [HttpGet]
       public ActionResult EditHeading (int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valuecategory;
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {

            var headingvalue = hm.GetByID(id);
            //headingvalue.HeadingStatues = false;
            /*=headingvalue.HeadingStatues == false ? headingvalue.HeadingStatues = true : headingvalue.HeadingStatues = false;*/

            hm.HeadingDelete(headingvalue);
            return RedirectToAction("Index");
        }


    }
}