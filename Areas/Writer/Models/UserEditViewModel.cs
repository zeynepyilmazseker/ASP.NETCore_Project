using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core_Project.Areas.Writer.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen fotoğraf seçiniz")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Lütfen fotoğraf seçiniz")]
        public IFormFile Image {  get; set; }

       
  

       
    }
}
