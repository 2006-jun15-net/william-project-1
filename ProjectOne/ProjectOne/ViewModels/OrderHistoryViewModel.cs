using Project1.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectOne.ViewModels
{
    public class OrderHistoryViewModel
    {
        [Required]
        public DateTime DateAndTime { get; set; }

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
