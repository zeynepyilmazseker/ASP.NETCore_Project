using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using DataAccessLayer.Concrete;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Core_Project.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDal());
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            p = user.Email;
            var values = writerMessageManager.GetListReceiverMessage(p);
            return View(values);
        }

        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            p = user.Email;
            var values = writerMessageManager.GetListSenderMessage(p);
            return View(values);
        }

  
        [Route("ReceiverMessageDetails/{id}")]
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage message = writerMessageManager.TGetById(id);
            return View(message);
        }

        [Route("SenderMessageDetails/{id}")]
        public IActionResult SenderMessageDetails(int id)
        {
            WriterMessage message = writerMessageManager.TGetById(id);
            return View(message);
        }
        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {

            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage message)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = user.Email;
            string name = user.Name + " " + user.Surname;
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.SenderMail = mail;
            message.SenderName = name;
            Context context = new Context();
            var namesurname = context.Users.Where(x => x.Email == message.ReceiverMail).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            message.ReceiverName = namesurname;
            writerMessageManager.TAdd(message);
            return RedirectToAction("SenderMessage");
        }
    }
}
