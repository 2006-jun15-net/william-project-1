using Project1.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestProject1.Domain.Model
{
    public class StoreLocationTest
    {

        private readonly StoreLocation _storeLocation = new StoreLocation();


        //in domain class, if(value.Length > 0) will NPE, change to if(value?.Length > 0)
        [Fact]
        public void Name_Empty_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => _storeLocation.Name = null);
        }


        //in domain class, if(value.Length > 0) will NPE, change to if(value?.Length > 0)
        [Fact]
        public void Address_Empty_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => _storeLocation.Address = null);
        }

    }
}
