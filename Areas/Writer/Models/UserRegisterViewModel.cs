using System.ComponentModel.DataAnnotations;

namespace Core_Project.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen fotoğraf seçiniz")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen mailinizi giriniz")]
        public string Mail { get; set; }
    }
}
