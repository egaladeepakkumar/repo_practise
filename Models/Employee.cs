using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace WebApplication1.models
{
    public class Employee
    {
       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "invalid email")]
        public string Email { get; set; }
    }
}
