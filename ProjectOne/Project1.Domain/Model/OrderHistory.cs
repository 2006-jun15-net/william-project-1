using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project1.Domain.Model
{
    public class OrderHistory
    {

        private DateTime _date;
        private TimeSpan _time;

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value != null ? value : DateTime.Now.Date;
            }
        }

        public TimeSpan Time
        {
            get => _time;
            set
            {
                _time = value != null ? value : DateTime.Now.TimeOfDay;
            }
        }

        [Key]
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? LocationId { get; set; }

        public Customer Customer { get; set; }
        public StoreLocation Location { get; set; }
        public List<StoreOrder> StoreOrder { get; set; }

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