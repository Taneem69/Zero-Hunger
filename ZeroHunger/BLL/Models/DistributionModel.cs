using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class DistributionModel
    {
        public int DId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invalid collection request")]
        public int RequestId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invalid employee")]
        public int EId { get; set; }

        [Required(ErrorMessage = "Distribution date is required")]
        public DateTime DistributionDate { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Distributed quantity must be greater than 0")]
        public decimal QuantityDistributed { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(50, ErrorMessage = "Location cannot exceed 50 characters")]
        public string Location { get; set; } = null!;
    }
}