using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebUI.ViewModel
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")] 
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }    

        public string ReturnUrl { get; set; }
    }
}
