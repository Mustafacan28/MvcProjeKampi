using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.ColorClass;
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
        Color color = new Color();
        // GET: Istatıstık
        public ActionResult Istatıstık(Context context)
        {
            //ViewBag.Sorgu4 = context.Headings.GroupBy(x => x.CategoryID).Select(x => new { Value = x.Key, Count = x.Count() }).OrderByDescending(x => x.Count).FirstOrDefault();

            ViewBag.Sorgu1 = context.Categories.Select(x => x.CategoryID).Count();

            ViewBag.Sorgu2 = context.Headings.Where(c => c.CategoryID == 2).Select(c => c.CategoryID).Count();

            ViewBag.Sorgu3 = context.Writers.Where(w => w.WriterName.IndexOf("a") != -1).Count();

            ViewBag.Sorgu4 = context.Headings.GroupBy(x => x.Category.CategoryName).Select(x => new
            { Value = x.Key, Count = x.Count() }).OrderByDescending(x => x.Value).FirstOrDefault().Value;



            var suru = context.Categories.GroupBy(x => x.CategoryStatus).Select(x => new { Value = x.Key, Count = x.Count() }).OrderByDescending(x => x.Value).FirstOrDefault().Value;

            ViewBag.Sorgu5 =  suru;




            return View();
        }
        
    }
}