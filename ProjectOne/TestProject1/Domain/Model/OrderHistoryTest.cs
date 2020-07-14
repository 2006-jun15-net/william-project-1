using Project1.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestProject1.Domain.Model
{
    public class OrderHistoryTest
    {

        private readonly OrderHistory _orderHistory = new OrderHistory();

        //Date is a non-nullable type, so value != null in domain object won't happen
        [Fact]
        public void Date_Has_Correct_DateTime()
        {
            var date = DateTime.Now.Date;

            _orderHistory.Date = date;
            Assert.True(date == _orderHistory.Date);
        }

        [Fact]
        public void Time_Has_Correct_TimeOfDay()
        {
            var time = DateTime.Now.TimeOfDay;

            _orderHistory.Time = time;
            Assert.True(time == _orderHistory.Time);
        }

    }
}
