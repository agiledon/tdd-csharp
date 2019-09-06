using System;
using System.Collections.Generic;
using System.Text;

namespace Zhangyi.PracticeTDD.TDDBasic.OO.Demeter
{
    public class Cashier
    {
        public void Charge(Customer myCustomer, double payment)
        {
            myCustomer.Pay(payment);
        }
    }
}
