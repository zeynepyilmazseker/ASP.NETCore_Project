using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
       ServiceManager serviceManager = new ServiceManager(new EFServiceDal());
        [HttpGet]
        public IActionResult Index()
        {
          
            var values = serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
         
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteService(int id)
        {
            var experience = serviceManager.TGetById(id);
            serviceManager.TDelete(experience);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var experience = serviceManager.TGetById(id);
            return View(experience);
        }

        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");

        }



    }
}
