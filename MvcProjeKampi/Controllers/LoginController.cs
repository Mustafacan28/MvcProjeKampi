using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.SecurityHash;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        LoginManager lm = new LoginManager(new EfLoginDal());
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterLoginDal());

        public ActionResult NullPage()
        {

            return Content(HashAndSalt.CreatePasswordHash("sero"));
        }
         [HttpGet]
        public ActionResult LoginPage()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult LoginPage(Admin p, Admin y)
        {
            string password = HashAndSalt.CreatePasswordHash(y.AdminPassword);
            //Context c = new Context();
            //var admin = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            var admin = lm.GetBy(p.AdminUserName,password);
            if (admin != null)
            {
                
                FormsAuthentication.SetAuthCookie(admin.AdminUserName, false);
                Session["AdminUserName"] = admin.AdminUserName;
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                return View("LoginPage");
            }
           
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {  
            
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p, Writer y)
        {
            string password = HashAndSalt.CreatePasswordHash(y.WriterPassword);
            var writer = wlm.GetWriterLogin(p.WriterMail, password);
            if (writer != null)
            {
                FormsAuthentication.SetAuthCookie(writer.WriterMail, false);
                Session["WriterMail"] = writer.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
           
        }
    }
}