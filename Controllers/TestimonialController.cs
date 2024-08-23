using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDal());
        public IActionResult Index()
        {
            var values = testimonialManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var values = testimonialManager.TGetById(id);
            testimonialManager.TDelete(values);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var values = testimonialManager.TGetById(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var values = testimonialManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial p)
        {
            testimonialManager.TUpdate(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial p)
        {
            testimonialManager.TAdd(p);
            return RedirectToAction("Index","Testimonial");
        }

    }
}
