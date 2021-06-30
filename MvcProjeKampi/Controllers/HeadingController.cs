using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.ColorClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        
       
        public ActionResult Index()
        { 
            var headingvalues = hm.GetHeadingList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = cm.GetCategoryList().Select(x => new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            List<SelectListItem> valuewriter = wm.GetList().Select(x => new SelectListItem { Text = x.WriterName + " " + x.WriterSurName , Value = x.WriterID.ToString() }).ToList();
            ViewBag.vlw = valuewriter;
            ViewBag.vlc = valuecategory;
            return View();
        }

        [HttpPost] 
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {          
            List<SelectListItem> valuecategory = cm.GetCategoryList().Select(_ => new SelectListItem { Text = _.CategoryName, Value = _.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valuecategory;
            var headingvalue = hm.GetByID(id);
            return View(headingvalue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUptade(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeletedHeading(int id)
        {
            
            var headingvalues = hm.GetByID(id);      
            if (headingvalues.HeadingStatus == false)
            {
                headingvalues.HeadingStatus = true;
            }
            else if (headingvalues.HeadingStatus == true)
            {
                headingvalues.HeadingStatus = false;
            }
            hm.HeadingDelete(headingvalues);
            return RedirectToAction("Index");
        }
        public ActionResult HeadingReport()
        {
            var heading = hm.GetHeadingList();
            return View(heading);
        }
    }
}