using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Employees
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(1000, 1000000, ErrorMessage = "Salary must be between 1,000 and 1,000,000.")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(500, ErrorMessage = "Address can't be longer than 500 characters.")]
        public string Address { get; set; }
    }
}
