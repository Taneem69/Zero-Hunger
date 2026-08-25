using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class EmployeeModel
    {
        public int EId { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [StringLength(50, ErrorMessage = "Employee name cannot exceed 50 characters")]
        public string Ename { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;
    }
}