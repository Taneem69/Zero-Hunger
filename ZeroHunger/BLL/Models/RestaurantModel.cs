using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class RestaurantModel
    {
        public int RId { get; set; }

        [Required(ErrorMessage = "Restaurant name is required")]
        [StringLength(50, ErrorMessage = "Restaurant name cannot exceed 50 characters")]
        public string Rname { get; set; } = null!;

        [Required(ErrorMessage = "Person contacted is required")]
        [StringLength(50, ErrorMessage = "Person contacted cannot exceed 50 characters")]
        public string PersonContacted { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Number { get; set; } = null!;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(50, ErrorMessage = "Address cannot exceed 50 characters")]
        public string Address { get; set; } = null!;
    }
}