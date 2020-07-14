using Project1.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestProject1.Domain.Model
{
    public class StoreOrderTest
    {

        private readonly StoreOrder _storeOrder = new StoreOrder();

        [Fact]
        public void Amount_LessThanZero_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => _storeOrder.Amount = -1000);
        }

    }
}
