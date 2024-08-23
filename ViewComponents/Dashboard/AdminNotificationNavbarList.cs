using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Project.ViewComponents.Dashboard
{
    
    public class AdminNotificationNavbarList : ViewComponent
    {
        AnnouncementManager manager = new AnnouncementManager(new EFAnnouncementDal());
        public IViewComponentResult Invoke()
        {
            var values = manager.TGetList().OrderByDescending(x => x.ID).Take(3).ToList();
            return View(values);
        }
    }
}
