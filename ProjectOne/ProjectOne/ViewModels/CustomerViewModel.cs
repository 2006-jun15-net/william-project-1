using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project1.Domain.Model
{
    public class CustomerViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Display(Name = "ID")]
        public int Id { get; set; }
        
        // (empty means they don't want to subscribe to mailing list [stretch goal])
        [Required]
        [EmailAddress]
        public string Email { get; set; }
       // // Not implemented yet
       // public string DefaultLocation { get; set; }

        public IEnumerable<OrderHistoryViewModel> OrderHistory { get; set; }
    }
}
