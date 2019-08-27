using System;

namespace Zhangyi.PraticeTDD.TDDBasic.OO.Demeter
{
    internal class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException()
        {
        }

        public NotEnoughMoneyException(string message) : base(message)
        {
        }

        public NotEnoughMoneyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}