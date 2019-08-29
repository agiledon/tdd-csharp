namespace Zhangyi.PracticeTDD.TDDBasic.Tools.XUnit
{
    public class Person
    {
        private static long identity = 0;

        private long id;
        private string name;
        private string mobile;

        public Person(string name, string mobile)
        {
            id = ++identity;
            this.name = name;
            this.mobile = mobile;
        }

        public long ID => this.id;
        public string Name => this.name;
        public string Mobile => this.mobile;

        public bool HasMobile()
        {
            return !string.IsNullOrWhiteSpace(this.mobile);
        }
    }
}