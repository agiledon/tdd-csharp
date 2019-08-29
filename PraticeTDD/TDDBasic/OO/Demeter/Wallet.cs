namespace Zhangyi.PracticeTDD.TDDBasic.OO.Demeter
{
    public class Wallet
    {
        private double totalMoney;

        public Wallet(double totalMoney)
        {
            this.totalMoney = totalMoney;
        }

        public double TotalMoney => this.totalMoney;

        public void AddMoney(double deposit)
        {
            totalMoney += deposit;
        }

        public void SubtractMoney(double debit)
        {
            totalMoney -= debit;
        }
    }
}