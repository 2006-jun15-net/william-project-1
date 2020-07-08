﻿using System;
using System.Collections.Generic;
using System.IO;


namespace Project1.Domain.Model
{
    public class ProductViewModel
    {
        private string _name;
        private decimal? _price;

        public string Name
        {
            get=>_name;
            set
            {
                if (value.Length > 0)
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Product Name must not be null.");
                }
            }
        }

        public decimal? Price
        {
            get => _price;
            set
            {
                if(value >= 0.00m)
                {
                    _price = value;
                }
                else
                {
                    throw new Exception("Product Price must not be null.");
                }
            }
        }

        public int ProductId { get; set; }

        public List<InventoryViewModel> Inventory { get; set; } = new List<InventoryViewModel>();
        public List<StoreOrderViewModel> StoreOrder { get; set; } = new List<StoreOrderViewModel>();
        //public override string ToString()
        //{
        //    return "Product: " + Name + "=" + Cost.ToString("C2");
        //}
    }
}


//public int ProductId { get; set; }
//public string Name { get; set; }
//public decimal? Price { get; set; }

//public virtual ICollection<Inventory> Inventory { get; set; }
//public virtual ICollection<StoreOrder> StoreOrder { get; set; }
