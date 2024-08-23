using System.ComponentModel.DataAnnotations;

namespace Core_Project.Areas.Writer.Models
{
    public class UserChangePasswordViewModel
    {
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        public string ConfirmPassword { get; set; }
    }
}
