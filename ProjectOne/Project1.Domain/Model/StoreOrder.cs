﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project1.Domain.Model
{
    public class StoreOrder
    {
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
                    throw new ArgumentException("Amount must not be null.");
                }
            }
        }
        [Required]
        //[Key, Column(Order = 0)]
        public int ProductId { get; set; }
        [Required]
        //[Key, Column(Order = 1)]
        [Key]
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