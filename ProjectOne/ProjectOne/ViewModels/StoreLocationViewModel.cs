﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Project1.Domain.Model
{
    public class StoreLocationViewModel
    {
        private string _name;
        private string _address;

        public int LocationId { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if(value.Length > 0)
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Store Name must not be null.");
                }
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                if (value.Length > 0)
                {
                    _address = value;
                }
                else
                {
                    throw new Exception("Address must not be null.");
                }
            }
        }


        public List<InventoryViewModel> Inventory { get; set; } = new List<InventoryViewModel>();
        public List<OrderHistoryViewModel> OrderHistory { get; set; } = new List<OrderHistoryViewModel>();
    }
}



//public int LocationId { get; set; }
//public string Name { get; set; }
//public string Address { get; set; }

//public virtual ICollection<Inventory> Inventory { get; set; }
//public virtual ICollection<OrderHistory> OrderHistory { get; set; }