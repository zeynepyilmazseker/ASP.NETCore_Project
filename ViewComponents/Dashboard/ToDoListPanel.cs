using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Project.ViewComponents.Dashboard
{
    public class ToDoListPanel : ViewComponent
    {
        ToDoListManager toDoListManager = new ToDoListManager(new EFToDoListDal());
        public IViewComponentResult Invoke()
        {
            var values = toDoListManager.TGetList().Where(x => x.Status == true).OrderByDescending(x => x.ID).Take(5).ToList();
            return View(values);
        }
    }
}
