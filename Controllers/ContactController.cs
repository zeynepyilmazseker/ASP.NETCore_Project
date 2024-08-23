using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EFMessageDal());
        public IActionResult Index()
        {
            var values = messageManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteContact(int id)
        {
            var message = messageManager.TGetById(id);
            messageManager.TDelete(message);
            return RedirectToAction("Index");

        }

        public IActionResult ContactDetails(int id)
        {
            var message = messageManager.TGetById(id);
            return View(message);
        }

       
    }
}
