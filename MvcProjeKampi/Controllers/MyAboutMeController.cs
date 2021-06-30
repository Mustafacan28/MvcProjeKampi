using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MyAboutMeController : Controller
    {
        // GET: MyAboutMe
        AboutMeManager abm = new AboutMeManager(new EfAboutMeDal());

        public ActionResult MyPage()
        {
            var value = abm.GetAboutMelist(); 
            return View(value);
        }
    }
}