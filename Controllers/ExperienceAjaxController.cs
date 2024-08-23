using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Project.Controllers
{
    public class ExperienceAjaxController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceDal());
        public IActionResult Index()
        {
           return View();
        }

        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetById(int ExperienceID)
        {
            var experience = experienceManager.TGetById(ExperienceID);
            var values = JsonConvert.SerializeObject(experience);
            return Json(values);
        }

        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetById(id);
            experienceManager.TDelete(values);
            return NoContent();
        }

        //[FromBody] özniteliği, gelen veriyi HTTP isteğinin gövdesinden alır
        //ve bu veriyi bir model nesnesine bağlar. 
        [HttpPost]
        public IActionResult UpdateExperience([FromBody] Experience p)
        {
            // ID ile mevcut kaydı bul
            var existingExperience = experienceManager.TGetById(p.ExperienceID);

            if (existingExperience == null)
            {
                return NotFound("Kayıt bulunamadı.");
            }

            // Mevcut kaydı güncelle
            existingExperience.Name = p.Name;
            existingExperience.Date = p.Date;

            experienceManager.TUpdate(existingExperience);

            return Json(existingExperience);
        }
    }
}
