using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Project.Controllers
{
    public class WriterUserController : Controller
    {
        WriterUserManager writerUserManager = new WriterUserManager(new EFWriterUserDal());
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
