using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
using System;
using System.Threading.Tasks;

namespace Core_Project.ViewComponents.Contact
{
    public class SendMessage : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EFMessageDal());

        [HttpGet]
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
