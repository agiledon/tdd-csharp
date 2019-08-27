using System;
using System.Collections.Generic;
using System.Text;

namespace Zhangyi.PraticeTDD.TDDBasic.OO.Demeter
{
    class Cashier
    {
        public void Charge(Customer myCustomer, double payment)
        {
            Wallet theWallet = myCustomer.Wallet;
            if (theWallet.TotalMoney > payment)
            {
                theWallet.SubtractMoney(payment);
            }
            else
            {
                throw new NotEnoughMoneyException("Money is not enough");
            }
        }
    }
}
