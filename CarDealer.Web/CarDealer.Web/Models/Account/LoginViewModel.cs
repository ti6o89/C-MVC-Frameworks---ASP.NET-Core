using System.ComponentModel.DataAnnotations;

namespace CarDealer.Web.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
