using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectOne.ViewModels
{
    public class InventoryViewModel
    {
        [Required]
        [Range(0, 1_000)]
        public int? Amount { get; set; }

        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Location ID")]
        public int LocationId { get; set; }

        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        public StoreLocationViewModel Location { get; set; } = new StoreLocationViewModel();
        public ProductViewModel Product { get; set; } = new ProductViewModel();
    }
}
