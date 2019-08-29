using System.Collections.Generic;
using Xunit;
using Zhangyi.PracticeTDD.TDDBasic.Tools;
using Moq;

namespace Zhangyi.PracticeTDD.TDDBasic.Test
{
    public class RosterTest
    {
        private IList<string> mockLines;

        public RosterTest()
        {
            mockLines = new List<string> { "zhangyi", "bruce"};
        }

        [Fact]
        public void Should_parse_to_employee_list_from_roster_file()
        {
            var mockReader = new Mock<ITextFileReader>();

            string fileName = "roster.txt";
            mockReader.Setup(r => r.Read(fileName)).Returns(mockLines);
            var roster = new Roster(mockReader.Object);

            var employees = roster.FetchRoster(fileName);

            Assert.Equal(2, employees.Count);
            Assert.Contains("zhangyi", employees[0].Name);
        }
    }
}
