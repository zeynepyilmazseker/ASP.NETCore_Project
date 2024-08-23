using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactSubplaceController : Controller
    {
        ContactManager contactManager = new ContactManager(new EFContactDal());
        public IActionResult Index()
        {
            var values = contactManager.TGetById(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contactManager.TUpdate(contact);
            return RedirectToAction("Index","Default");   
        }
    }
}
