using System.ComponentModel.DataAnnotations;

namespace AspNetCoreAuth.Web.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Display(Name ="Remember me?")]
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}
