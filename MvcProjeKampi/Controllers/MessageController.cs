using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageMenager mm = new MessageMenager(new EfMessageDal());

        MessageValidator messagevalidator = new MessageValidator();
        [Authorize(Roles ="B")]
        public ActionResult Inbox(string p)
        {
            var messagevalues = mm.GetMessageListInbox(p);

            return View(messagevalues);
        }
        public ActionResult Sendbox(string p)
        {
            var messagesendbox = mm.GetMessageListSendbox(p);
            return View(messagesendbox);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        public ActionResult GetInboxDetails(int id)
        {
            var values = mm.MessagegetByID(id);
            return View(values);
        }

        public ActionResult GetSendboxDetails(int id)
        {
            var values = mm.MessagegetByID(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult result = messagevalidator.Validate(p);
            if (result.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}