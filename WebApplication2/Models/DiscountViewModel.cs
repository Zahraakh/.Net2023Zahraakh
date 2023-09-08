using System;
using System.ComponentModel.DataAnnotations;

public class Discount
{
    public int ID { get; set; }  // Unique identifier for the discount.

    [Required(ErrorMessage = "Discount Code is required.")]
    [StringLength(20, ErrorMessage = "Discount Code cannot exceed 20 characters.")]
    public string DiscountCode { get; set; }

    [Required(ErrorMessage = "Percentage is required.")]
    [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100.")]
    public decimal Percentage { get; set; }

    [Required(ErrorMessage = "Start Date is required.")]
    [DataType(DataType.Date)]
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End Date is required.")]
    [DataType(DataType.Date)]
    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }
}
