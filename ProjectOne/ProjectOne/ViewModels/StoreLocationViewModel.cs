using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project1.Domain.Model
{
    public class StoreLocationViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; }


        public IEnumerable<InventoryViewModel> Inventory { get; set; }
        public IEnumerable<OrderHistoryViewModel> OrderHistory { get; set; }
    }
}

