using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult PartialSideBar()
        {

            return PartialView();
        }

        public PartialViewResult Footer()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }


        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult NavigationPartial()
        {
            return PartialView();
        }

        public PartialViewResult NewSideBar()
        {
            return PartialView();
        }
    }
}
