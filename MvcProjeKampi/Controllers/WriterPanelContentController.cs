using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContenManager cm = new ContenManager(new EfContentDal());
        Context c = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
           
            p =(string)Session["WriterMail"];
            var result = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = cm.GetListByWriter(result);
            return View(values);                                  
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {

            string mail = (string)Session["WriterMail"];
            var info = c.Writers.Where(x => x.WriterMail == mail).Select(x => x.WriterID).FirstOrDefault();
            p.ContentDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = info;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return View("MyContent");
        }
    }
}