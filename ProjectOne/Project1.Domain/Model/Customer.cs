﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project1.Domain.Model
{
    public class Customer
    {
        private string _firstName, _lastName;
        
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("First Name must not be empty.");
                }
                _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Last Name must not be empty.");
                }
                _lastName = value;
            }
        }

        public int CustomerId { get; set; }
        
        // Sorta like IDs
        // (empty means they don't want to subscribe to mailing list [stretch goal])
        [EmailAddress]
        public string Email { get; set; }
       // // Not implemented yet
       // public string DefaultLocation { get; set; }



        //public override string ToString()
        //{
        //    return "Customer: " + FirstName + " | " + LastName + " | " + string.Join(",", OrderHistory);
        //}
    }
}





//public int CustomerId { get; set; }
//public string FirstName { get; set; }
//public string LastName { get; set; }
//public string Email { get; set; }

//public virtual ICollection<OrderHistory> OrderHistory { get; set; }
