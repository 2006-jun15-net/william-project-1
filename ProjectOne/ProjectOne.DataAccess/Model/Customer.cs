using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectOne.DataAccess.Model
{
    public partial class Customer
    {
        public Customer()
        {
            OrderHistory = new HashSet<OrderHistory>();
        }

        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
    }
}
