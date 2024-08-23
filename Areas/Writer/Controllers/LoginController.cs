using Core_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Project.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly SignInManager<WriterUser> _signInManager;
        private readonly UserManager<WriterUser> _userManager;

        public LoginController(SignInManager<WriterUser> signInManager, UserManager<WriterUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, true,true);
               
                if (result.Succeeded)
                {
                    //kullanıcı bilgilerini al
                    var user = await _userManager.FindByNameAsync(p.UserName);

                    //rolü kontrol et
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index","Dashboard");
                    }
                    else
                    {
                        return RedirectToAction("Index","Profile");
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("","Hatalı kullanıcı adı veya şifre");
                }

            }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Login");
            
        }
    }
}

//isPersistent : kullanıcı adını hatırlasın mı ? 


//LoginController sınıfı, oturum açma işlemlerini yönetmek için
//ASP.NET Core Identity'nin SignInManager<WriterUser> sınıfını kullanır.
//Constructor, bu sınıfı Dependency Injection aracılığıyla alır ve _signInManager alanını başlatır,
//böylece sınıfın diğer metotları bu alanı kullanarak oturum açma işlemlerini gerçekleştirebilir.