using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class ProfilController : Controller
    {
        // GET: Profil
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContenManager cm = new ContenManager(new EfContentDal());

        public ActionResult Heading()
        {
            var headinglist = hm.GetHeadingList();
            return View(headinglist);
        }

        public PartialViewResult Index(int id)
        {
            var contentlist = cm.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
    }
}