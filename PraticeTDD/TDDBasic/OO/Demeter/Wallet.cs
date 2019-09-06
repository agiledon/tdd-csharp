namespace Zhangyi.PracticeTDD.TDDBasic.OO.Demeter
{
    public class Wallet
    {
        public Wallet(double totalMoney)
        {
            TotalMoney = totalMoney;
        }

        public double TotalMoney { get; private set; }

        public void AddMoney(double deposit)
        {
            TotalMoney += deposit;
        }

        public void SubtractMoney(double debit)
        {
            TotalMoney -= debit;
        }

        public bool IsEnough(double payment)
        {
            return TotalMoney > payment;
        }
    }
}