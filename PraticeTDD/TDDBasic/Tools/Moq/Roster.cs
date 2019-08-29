using System.Collections.Generic;
using System.Linq;

namespace Zhangyi.PracticeTDD.TDDBasic.Tools.Moq
{
    public class Roster
    {
        private readonly ITextFileReader reader;

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
