using System.ComponentModel.DataAnnotations;

namespace Meaar5.Models
{
    public class FacultyMembers
    {
        [Key]
        [Required]
        public string FacultyId { get; set; } = "";
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
