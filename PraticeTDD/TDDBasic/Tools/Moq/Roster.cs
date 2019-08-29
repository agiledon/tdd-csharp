using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhangyi.PracticeTDD.TDDBasic.Tools
{
    public class Roster
    {
        private ITextFileReader reader;

        public Roster(ITextFileReader reader)
        {
            this.reader = reader;
        }

        public IList<Employee> FetchRoster(string fileName)
        {
            var lines = reader.Read(fileName);

            return lines.Where(l => !string.IsNullOrEmpty(l))
                .Select(l => new Employee(l))
                .ToList();
        }
    }
}
