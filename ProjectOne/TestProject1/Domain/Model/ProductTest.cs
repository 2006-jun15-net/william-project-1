using Project1.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestProject1.Domain.Model
{
    public class ProductTest
    {

        private readonly Product _product = new Product();

        [Fact]
        public void Name_EmptyValue_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => _product.Name = string.Empty);
        }

        [Fact]
        public void Price_LessThanZero_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => _product.Price = -100.0m);
        }

        [Fact]
        public void ProductHasInitialEmptyInventory()
        {
            Assert.True(_product.Inventory != null);
            Assert.True(_product.Inventory.Count == 0);
        }

        [Fact]
        public void ProductHasInitialEmptyStoreOrder()
        {
            Assert.True(_product.StoreOrder != null);
            Assert.True(_product.StoreOrder.Count == 0);
        }

    }
}
