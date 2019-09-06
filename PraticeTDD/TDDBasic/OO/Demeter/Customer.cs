using System;
using System.Collections.Generic;
using System.Text;

namespace Zhangyi.PracticeTDD.TDDBasic.OO.Demeter
{
    public class Customer
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly Wallet myWallet;

        public Customer(string firstName, string lastName, Wallet myWallet)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.myWallet = myWallet;
        }

        public string Name => $"{firstName} {lastName}";

        public double TotalMoney()
        {
            return myWallet.TotalMoney;
        }

        public void Pay(double payment)
        {
            if (myWallet.IsEnough(payment))
            {
                myWallet.SubtractMoney(payment);
            }
            else
            {
                throw new NotEnoughMoneyException("Money is not enough");
            }
        }
    }
}
