namespace Zhangyi.PracticeTDD.TDDBasic.Tools.Moq
{
    public class Employee
    {
        private string name;
        public string Name => this.name;

        public Employee(string name)
        {
            this.name = name;
        }
    }
}
