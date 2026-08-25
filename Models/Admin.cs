using System.ComponentModel.DataAnnotations;

namespace Meaar5.Models
{
    public class Admin
    {
        [Key]
        public string AdminId { get; set; } = "";
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}