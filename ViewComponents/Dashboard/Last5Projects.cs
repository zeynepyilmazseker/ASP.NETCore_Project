using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Project.ViewComponents.Dashboard
{
    public class Last5Projects : ViewComponent
    {
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            var values = context.Portfolios.OrderByDescending(x=> x.PortfolioID).Take(5).ToList();
            return View(values);
        }
    }
}
