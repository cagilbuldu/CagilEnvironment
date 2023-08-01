using Microsoft.Build.Framework;

using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace CagilEnvironmentUI.Models
{
    public class RegisterViewModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen kullanıcı adını giriniz!")]
        public string userName { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen mail giriniz!")]
        public string mail { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen şifreyi giriniz!")]
        public string password { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz!")]
        [Compare("password",ErrorMessage = "Şifreler eşleşmiyor, Kontrol edin!")]
        public string passwordConfirm { get; set; }

    }
}
