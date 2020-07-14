using Project1.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestProject1.Domain.Model
{

    public class CustomerTest
    {
        private readonly Customer _customer = new Customer();

        [Fact]
        public void FirstName_EmptyValue_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => _customer.FirstName = string.Empty);
        }


        [Fact]
        public void LastName_EmptyValue_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => _customer.LastName = string.Empty);
        }
    }
}
