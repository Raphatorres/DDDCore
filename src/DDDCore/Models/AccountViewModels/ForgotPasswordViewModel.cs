using System.ComponentModel.DataAnnotations;

namespace DDDCore.Presentation.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
