using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Project.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList : ViewComponent
    {
        WriterMessageManager messageManager = new WriterMessageManager(new EFWriterMessageDal());
        public IViewComponentResult Invoke()
        {
            string mail = "admin@gmail.com";
            var values = messageManager.GetListReceiverMessage(mail).Take(3).ToList();
            return View(values);
        }
    }
}
