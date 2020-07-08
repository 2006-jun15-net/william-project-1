﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain.Model
{
    public class OrderHistoryViewModel
    {
        private DateTime _date;
        private TimeSpan _time;

        public DateTime Date
        {
            get => _date;
            set
            {
                if (value == null)
                    throw new Exception("Order Date must not be null.");
                else
                    _date = value;
            }
        }

        public TimeSpan Time
        {
            get => _time;
            set
            {
                if (value == null)
                    throw new Exception("Order Time must not be null.");
                else
                    _time = value;
            }
        }


        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? LocationId { get; set; }

        public CustomerViewModel Customer { get; set; } = new CustomerViewModel();
        public StoreLocationViewModel Location { get; set; } = new StoreLocationViewModel();
        public List<StoreOrderViewModel> StoreOrder { get; set; } = new List<StoreOrderViewModel>();

        //public override string ToString()
        //{
        //    string productsString = string.Join(",", Products);
        //    return "Order: " + productsString + " | " + Store + " | " + Time;
        //}
    }
}





//public int OrderId { get; set; }
//public DateTime Date { get; set; }
//public TimeSpan Time { get; set; }
//public int? CustomerId { get; set; }
//public int? LocationId { get; set; }

//public virtual Customer Customer { get; set; }
//public virtual StoreLocation Location { get; set; }
//public virtual ICollection<StoreOrder> StoreOrder { get; set; }