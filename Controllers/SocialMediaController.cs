using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        SocialMediaManager mediaManager = new SocialMediaManager(new EFSocialMediaDal());
        public IActionResult Index()
        {
            var values = mediaManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var values = mediaManager.TGetById(id);
            mediaManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var values = mediaManager.TGetById(id);
            return View(values);
        }


        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia p)
        {
            mediaManager.TUpdate(p);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            socialMedia.Status = true;
            mediaManager.TAdd(socialMedia);
            return RedirectToAction("Index");
        }
    }
}
