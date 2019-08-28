using System;
using System.Collections.Generic;
using System.Text;

namespace Zhangyi.PraticeTDD.TDDBasic.OO.Demeter
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
    }
}
