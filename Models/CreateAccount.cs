using System.ComponentModel.DataAnnotations;

namespace Meaar5.Models
{
    public class CreateAccount
    {
        [Required(ErrorMessage = "Please Enter Your First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]

        // This ensures the email ends with @taibahu.edu.sa
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@taibahu\.edu\.sa$", ErrorMessage = "Please use Taibah university email (@taibahu.edu.sa)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
