using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Project.ViewComponents.Dashboard
{
    public class StatisticsDashboard2 : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Portfolios.Count();
            ViewBag.v2 = context.Skills.Count();
            ViewBag.v3 = context.Services.Count();
            return View();
        }
    }
}
