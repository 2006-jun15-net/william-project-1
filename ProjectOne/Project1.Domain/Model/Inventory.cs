using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain.Model
{
    public class Inventory
    {
        public int Id { get; set; }

        private int? _amount;
        public int? Amount
        {
            get => _amount;
            set
            {
                if(value < 0)
                {
                    throw new Exception("Took too many products from inventory or isolation level was too weak.");
                }

                _amount = value ?? throw new Exception("Inventory amount cannot be null.");
            }
        }

        public int LocationId { get; set; }
        public int ProductId { get; set; }

        public StoreLocation Location { get; set; } = new StoreLocation();
        public Product Product { get; set; } = new Product();
    }
}



//public int? Amount { get; set; }
//public int LocationId { get; set; }
//public int ProductId { get; set; }
//public virtual StoreLocation Location { get; set; }
//public virtual Product Product { get; set; }