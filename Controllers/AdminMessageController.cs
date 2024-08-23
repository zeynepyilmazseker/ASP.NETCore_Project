using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDal());
       

        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = writerMessageManager.GetListReceiverMessage(p);
            return View(values);
        }

        public IActionResult SenderMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = writerMessageManager.GetListSenderMessage(p);
            return View(values);
        }

        public IActionResult AdminReceiverMessageDetails(int id)
        {
            var message = writerMessageManager.TGetById(id);
            return View(message);
        }

        public IActionResult AdminSenderMessageDetails(int id)
        {
            var message = writerMessageManager.TGetById(id);
            return View(message);
        }

        public IActionResult AdminReceiverMessageDelete(int id)
        {
            var message = writerMessageManager.TGetById(id);
            writerMessageManager.TDelete(message);
            return RedirectToAction("ReceiverMessageList");
        }

        public IActionResult AdminSenderMessageDelete(int id)
        {
            var message = writerMessageManager.TGetById(id);
            writerMessageManager.TDelete(message);
            return RedirectToAction("SenderMessageList");
        }
        [HttpGet]
        public IActionResult AdminSendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult  AdminSendMessage(WriterMessage p)
        {
          
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.SenderMail = "admin@gmail.com";
            p.SenderName = "Admin";
            Context context = new Context();
            var namesurname = context.Users.Where(x => x.Email == p.ReceiverMail).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = namesurname;
            writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }
    }
}

