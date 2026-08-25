using System.ComponentModel.DataAnnotations;

namespace Meaar5.Models
{
    public class CourcesData
    {
        // كل البيانات الخاصة بالكورسات بتكون هنا
        
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string CourseCode { get; set; } = "";

        [Required]
        public string CourseName { get; set; } = "";

        public int CreditHours { get; set; }
    }

}
