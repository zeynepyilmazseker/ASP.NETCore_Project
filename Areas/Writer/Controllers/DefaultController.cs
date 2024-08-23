using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    [Authorize]
    
    public class DefaultController : Controller
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDal());
        public IActionResult Index()
        {
            var list = announcementManager.TGetList();
            return View(list);
        }

        [HttpGet]
        public IActionResult AnnouncementDetails(int id)
        {
            Announcement announcement = announcementManager.TGetById(id);
            return View(announcement);
        }
    }
}
