using BusinessLayer.Concrete;

using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Project.ViewComponents.Dashboard
{
    public class Messages : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EFMessageDal());
        public IViewComponentResult Invoke()
        {
            var values = messageManager.TGetList();

            
            return View(values);  
        }
    }
}
