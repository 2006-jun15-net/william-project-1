using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectOne.ViewModels
{
    public class OrderHistoryViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Customer ID")]
        public int? CustomerId { get; set; }

        [Display(Name = "Location ID")]
        public int? LocationId { get; set; }

        public CustomerViewModel Customer { get; set; }
        public StoreLocationViewModel Location { get; set; }
        public IEnumerable<StoreOrderViewModel> StoreOrder { get; set; }
    }
}
