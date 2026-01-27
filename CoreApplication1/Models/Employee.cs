
using System.ComponentModel.DataAnnotations;

namespace CoreApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public String Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@+[na]+.+[com]+$", ErrorMessage = "Invalid Email")]

        [Display(Name="Office Email")]
        public string Email { get; set; }

        [Required]
        public Dept? Department { get; set; }

        public String? PhotoPath1 { get; set; }


    }
}






