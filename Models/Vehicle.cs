using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VMS_Hisham_El_Shiraida.Models
{
    [Table("VehicleInfo")]
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "Make is required.")]
        [StringLength(50, ErrorMessage = "Make cannot exceed 50 characters.")]
        [Display(Name = "Make")]
        public string Make { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vehicle type is required.")]
        [Display(Name = "Vehicle Type")]
        public VehicleType Type { get; set; }

        [Required(ErrorMessage = "Purchase date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Purchase Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1990, 2027, ErrorMessage = "Year must be between 1990 and 2027.")]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(1, 500000, ErrorMessage = "Price must be between $1 and $500,000.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }
    }
}
