using System.Collections.Generic;
using Moq;
using Xunit;
using Zhangyi.PracticeTDD.TDDBasic.Tools;
using Zhangyi.PracticeTDD.TDDBasic.Tools.Moq;

namespace Zhangyi.PracticeTDD.TDDBasic.Test
{
    public class RosterTest
    {
        public RosterTest()
        {
            mockLines = new List<string> {"zhangyi", "bruce"};
        }

        private readonly IList<string> mockLines;

        [Fact]
        public void Should_parse_to_employee_list_from_roster_file()
        {
            var mockReader = new Mock<ITextFileReader>();

            var fileName = "roster.txt";
            mockReader.Setup(r => r.Read(fileName)).Returns(mockLines);
            var roster = new Roster(mockReader.Object);

            var employees = roster.FetchRoster(fileName);

            Assert.Equal(2, employees.Count);
            Assert.Contains("zhangyi", employees[0].Name);
        }
    }
}