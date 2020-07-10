using System;
using Xunit;
using ProjectOne.ViewModels;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly CustomerViewModel _customer = new CustomerViewModel();

        [Fact]
        public void TestFirstNameNull()
        {
            Assert.True( _customer.FirstName == null);
        }
    }
}
