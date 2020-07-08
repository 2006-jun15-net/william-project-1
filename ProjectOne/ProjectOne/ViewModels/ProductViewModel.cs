using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Project1.Domain.Model
{
    public class ProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.00, 1_000_000_000.00)]
        public decimal? Price { get; set; }

        [Display(Name = "ID")]
        public int Id { get; set; }

        public IEnumerable<InventoryViewModel> Inventory { get; set; }
        public IEnumerable<StoreOrderViewModel> StoreOrder { get; set; }
    }
}
