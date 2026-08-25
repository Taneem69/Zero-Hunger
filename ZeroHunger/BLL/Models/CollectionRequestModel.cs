using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class CollectionRequestModel
    {
        public int RequestId { get; set; }

        [Required(ErrorMessage = "Restaurant is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid restaurant")]
        public int RId { get; set; }

        [Required(ErrorMessage = "Employee is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid employee")]
        public int EId { get; set; }

        [Required(ErrorMessage = "Food description is required")]
        [StringLength(50, ErrorMessage = "Food description cannot exceed 50 characters")]
        public string FoodDescription { get; set; } = null!;

        [Range(0.01, double.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Request date is required")]
        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "Preserve until date is required")]
        public DateTime PreserveUntil { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } = null!;

        [Required(ErrorMessage = "Collection time is required")]
        public DateTime CollectionTime { get; set; }
    }
}