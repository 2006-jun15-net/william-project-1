using Project1.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestProject1.Domain.Model
{
    public class InventoryTest
    {

        private readonly Inventory _inventory = new Inventory();

        [Fact]
        public void Amount_LessThanZero_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => _inventory.Amount = -10);
        }

        [Fact]
        public void Amount_Null_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => _inventory.Amount = null);
        }


      }
}
