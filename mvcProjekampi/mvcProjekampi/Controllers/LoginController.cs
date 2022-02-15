using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace mvcProjekampi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
         AdminManager abm = new AdminManager(new EfAdminDal());
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
      
        [HttpPost]
       
        public ActionResult Index(Admin p)
        {
            string sifre= sıfrele.MD5Olustur(p.AdminPasword);
            Context c = new Context();
            
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPasword == sifre);
            if(adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        //public ActionResult Index2()
        //{
        //    return Content(sıfrele.MD5Olustur("123"));
        //}

    }
}