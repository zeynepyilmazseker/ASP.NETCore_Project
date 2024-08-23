using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EFSkillDal());
        public IActionResult Index()
        {
          
            var values = skillManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {

            skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }

        //Yetenek Silme İşlemi
      
        public IActionResult DeleteSkill(int id)
        {
            var skill = skillManager.TGetById(id);
            skillManager.TDelete(skill);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
          
            var skill = skillManager.TGetById(id);
            return View(skill);
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
