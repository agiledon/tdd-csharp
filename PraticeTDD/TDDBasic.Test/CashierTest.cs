using System;
using Xunit;
using Zhangyi.PraticeTDD.TDDBasic.OO.Demeter;

namespace TDDBasic.Test
{
    public class CashierTest
    {
        [Fact]
        public void Should_substract_money_if_money_is_enough()
        {
            Cashier cashier = new Cashier();
            Wallet wallet = new Wallet(100.0);
            Customer customer = new Customer("Bruce", "Zhang", wallet);

            cashier.Charge(customer, 50.0);

            Assert.Equal(50.0, customer.Wallet.TotalMoney);
        }
    }
}
