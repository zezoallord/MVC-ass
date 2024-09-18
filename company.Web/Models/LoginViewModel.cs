using System.ComponentModel.DataAnnotations;

namespace company.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Format for Email")]
      public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)(?:([a-zA-Z\d\W])(?!.*\1)){2,}.{6,}$", ErrorMessage = "Password must contain at least 2 characters, 1 uppercase letter, 1 lowercase letter, 1 number and 1 special character")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    
        
    }
}
