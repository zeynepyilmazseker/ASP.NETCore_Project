using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Core_Project.ViewComponents.Dashboard
{
    public class TotalBudget : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {

            var portfolios = context.Portfolios.AsEnumerable(); // Verileri bellek içine al
            var totalBudget = portfolios.Sum(x => ConvertPriceToInt(x.Price));

            ViewBag.TotalProjects = portfolios.Count();
            ViewBag.TotalBudget = totalBudget;
            return View();
        }

        private int ConvertPriceToInt(string price)
        {
            var priceString = price.Substring(1,price.Length-1).Trim();
            return Convert.ToInt32(priceString);
        }
    }
}
