using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;


namespace Project1.Domain.Model
{
    public class ProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.00, 2000000000.00)]
        public decimal? Price { get; set; }

        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        public IEnumerable<InventoryViewModel> Inventory { get; set; }
        public IEnumerable<StoreOrderViewModel> StoreOrder { get; set; }
    }
}
