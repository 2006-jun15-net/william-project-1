using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Domain.Model
{
    public class StoreOrder
    {
        public int Id { get; set; }

        private int? _amount;

        public int? Amount
        {
            get => _amount;
            set
            {
                if (value > -1)
                {
                    _amount = value;
                }
                else
                {
                    throw new Exception("Amount must not be null.");
                }
            }
        }

        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}



//public partial class StoreOrder
//{
//    public int? Amount { get; set; }
//    public int ProductId { get; set; }
//    public int OrderId { get; set; }

//    public virtual OrderHistory Order { get; set; }
//    public virtual Product Product { get; set; }
//}