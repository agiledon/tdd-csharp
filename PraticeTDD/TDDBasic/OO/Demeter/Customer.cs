using System;
using System.Collections.Generic;
using System.Text;

namespace Zhangyi.PracticeTDD.TDDBasic.OO.Demeter
{
    public class Customer
    {
        private string firstName;
        private string lastName;
        private readonly Wallet myWallet;

        public Customer(string firstName, string lastName, Wallet myWallet)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.myWallet = myWallet;
        }

        public string Name => $"{firstName} {lastName}";

        public Wallet Wallet => this.myWallet;

        public void Pay(double payment)
        {
            Wallet theWallet = this.Wallet;
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
