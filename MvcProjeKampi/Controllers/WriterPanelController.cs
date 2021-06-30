using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writervalidator = new WriterValidator();
        Context c = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["WriterMail"];
            id= c.Writers.Where(x => x.WriterMail == p).Select(x => x.WriterID).FirstOrDefault();
            var writer = wm.GetByID(id);
            return View(writer);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            ValidationResult result = writervalidator.Validate(p);
            if (result.IsValid)
            {
                wm.WriterUptade(p);
                return RedirectToAction("WriterProfile");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.PropertyName);
                }
            }
            return View();
        }

        int writerinfo;
        public ActionResult MyHeading(string p)
        {
            
            p = (string)Session["WriterMail"];
            writerinfo = c.Writers.Where(x => x.WriterMail == p).Select(x => x.WriterID).FirstOrDefault();
            var result = hm.GetWriterParameterList(writerinfo);
            return View(result);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = cm.GetCategoryList()
               .Select(x => new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.src = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writerinfo;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int p =1)
        {
            var headings = hm.GetHeadingList().ToPagedList(p,4);
            return View(headings);
        }
    }
}