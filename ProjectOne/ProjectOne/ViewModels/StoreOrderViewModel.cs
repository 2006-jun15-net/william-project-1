using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectOne.ViewModels
{
    public class StoreOrderViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Range(0, 1_000_000_000)]
        public int? Amount { get; set; }

        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
    }
}

