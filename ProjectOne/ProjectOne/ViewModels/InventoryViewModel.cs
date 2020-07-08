using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project1.Domain.Model
{
    public class InventoryViewModel
    {
        [Required]
        [Range(0, 1000)]
        public int? Amount { get; set; }

        [Display(Name = "Location ID")]
        public int LocationId { get; set; }

        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        public StoreLocationViewModel Location { get; set; } = new StoreLocationViewModel();
        public ProductViewModel Product { get; set; } = new ProductViewModel();
    }
}


