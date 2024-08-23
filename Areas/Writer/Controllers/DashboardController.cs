using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core_Project.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        
        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult>  Index()
        {
            var user =await _userManager.FindByNameAsync(User.Identity.Name);
            var mail = user.Email;
            ViewBag.NameSurname = user.Name + " " + user.Surname;

            //WEATHER API
            string api = "85118cb30871b324b788396d8f6d49e5";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=London&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument document = XDocument.Load(connection);
            ViewBag.weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

 
            //İSTATİSTİKLER
            Context context = new Context();
            ViewBag.TotalAccount = context.Users.Count();
            ViewBag.MessageCount = context.WriterMessages.Where(x => x.ReceiverMail.Equals(mail)).Count();
            ViewBag.NotificationCount = context.Announcements.Count();
            ViewBag.SkillCount = context.Skills.Count();
            return View();

            
            

        }
    }
}
