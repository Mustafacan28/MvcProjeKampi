using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.IstatıstıkConroller
{
    public class IstatıstıkController : Controller
    {

        // GET: Istatıstık
        public ActionResult Istatıstık(Context context)
        {
            //ViewBag.Sorgu4 = context.Headings.GroupBy(x => x.CategoryID).Select(x=>new { Value = x.Key, Count = x.Count() }).OrderByDescending(x=>x.Count).FirstOrDefault();
            
            ViewBag.Sorgu1 = (from categories in context.Categories select categories.CategoryID).Count();

            ViewBag.Sorgu2 = context.Categories.Where(c=>c.CategoryName == "Dizi").Count();

            ViewBag.Sorgu3 = context.Writers.Where(w=>w.WriterName.IndexOf("a") != -1).Count();

            ViewBag.Sorgu4 = (from heading in context.Headings group heading by heading.CategoryID into h select new TestGroupClass { Key = h.Key, Count = h.Count() }).OrderByDescending(x => x.Count).FirstOrDefault();


            ViewBag.Sorgu5 = (from categories in context.Categories select categories.CategoryStatus == true).Count();
            



            return View();
        }
        
    }
}