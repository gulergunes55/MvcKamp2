using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcProjekampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidatior cv = new ContactValidatior();
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            string p = (string)Session["AdminUserName"];

            
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {

           

            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult ContactPartial()
        {
            string p = (string)Session["AdminUserName"];
            var contact = cm.GetList().Count();
            ViewBag.d1 = contact;

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





            return PartialView( );
        }
    }
}