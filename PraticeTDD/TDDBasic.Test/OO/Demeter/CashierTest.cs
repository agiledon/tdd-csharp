using Xunit;
using Zhangyi.PracticeTDD.TDDBasic.OO.Demeter;

namespace Zhangyi.PracticeTDD.TDDBasic.Test.OO.Demeter
{
    public class CashierTest
    {
        [Fact]
        public void Should_subtract_money_if_money_is_enough()
        {
            // given
            Cashier cashier = new Cashier();
            Wallet wallet = new Wallet(100.0);
            Customer customer = new Customer("Bruce", "Zhang", wallet);

            // when
            cashier.Charge(customer, 50.0);

            // then
            Assert.Equal(50.0, customer.Wallet.TotalMoney);
        }

        [Fact]
        public void Should_throw_exception_if_money_is_not_enough()
        {
            Cashier cashier = new Cashier();
            Wallet wallet = new Wallet(100.0);
            Customer customer = new Customer("Bruce", "Zhang", wallet);

            Assert.Throws<NotEnoughMoneyException>(() => cashier.Charge(customer, 150.0));
        }
    }
}
