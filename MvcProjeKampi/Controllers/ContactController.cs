using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        readonly ContactManager cm = new ContactManager(new EfContactDal());
         ContactValidator cv = new ContactValidator();

        public ActionResult Index()
        {
            var contactvalues = cm.GetContactsList();          
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.ContactgetByID(id);
            return View(contactvalues);
        }

        public PartialViewResult MesssageListMenu()
        {
            return PartialView();
        }
    }
}