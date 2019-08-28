using System;
using System.Collections.Generic;
using System.Text;

namespace Zhangyi.PracticeTDD.TDDBasic.Tools
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
