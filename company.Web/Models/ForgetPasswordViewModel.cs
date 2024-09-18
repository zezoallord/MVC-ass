using System.ComponentModel.DataAnnotations;

namespace company.Web.Models
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Format for Email")]
        public string Email { get; set; }
    }
}
