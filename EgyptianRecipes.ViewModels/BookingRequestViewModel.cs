using System.ComponentModel.DataAnnotations;

namespace EgyptianRecipes.ViewModels
{
    public class BookingRequestViewModel
    {
        [Required(ErrorMessage = "Your Name is required.")]
        [StringLength(100, ErrorMessage = "Title length should be 100 max.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "A phone number is required.")]
        [StringLength(20, ErrorMessage = "Phone number length should be 20 max.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Not a valid phone number")]
        public string CustomerPhoneNumber { get; set; }

        [Required(ErrorMessage = "Your email address is required.")]
        [StringLength(100, ErrorMessage = "Email Address length should be 100 max.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "This email is invalid.")]
        public string CustomerEmail { get; set; }
    }
}
