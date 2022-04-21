using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcProjekampi.Controllers
{
    public class WriterPanelMesajController : Controller
    {
        // GET: WriterPanelMesaj
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        //Context c = new Context();
        public ActionResult Inbox()
        {
           string p = (string)Session["WriterMail"];
            //var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public PartialViewResult MessageMenu()

        {
            string p = (string)Session["WriterMail"];
            
          

            var sendMail = mm.GetListSendbox(p).Count();
            ViewBag.d2 = sendMail;

            var receiverMail = mm.GetListInbox(p).Count();
            ViewBag.d3 = receiverMail;

            var ReadMail = mm.GetReadList(p).Count();
            ViewBag.d4 = ReadMail;

            var unReadMail = mm.GetUnReadList(p).Count();
            ViewBag.d5 = unReadMail;

            var trashMail = mm.GetListTrash().Count();
            ViewBag.d6 = trashMail;
            return PartialView();
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var valuesend = mm.GetByID(id);
            return View(valuesend);
        }

        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = sender;
                p.MessageDate = DateTime.Now.ToShortDateString();
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();


        }
    }
}