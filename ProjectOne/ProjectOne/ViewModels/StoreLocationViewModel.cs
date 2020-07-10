using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectOne.ViewModels
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

