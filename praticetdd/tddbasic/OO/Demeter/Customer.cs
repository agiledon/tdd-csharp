using System;
using System.Collections.Generic;
using System.Text;

namespace Zhangyi.PraticeTDD.TDDBasic.OO.Demeter
{
    class Customer
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

        public string Name
        {
            get { return string.Format("{0} {1}", firstName, lastName); }
        }

        public Wallet Wallet
        {
            get { return myWallet; }
        }
    }
}
