using System.Collections.Generic;
using Xunit;
using Zhangyi.PracticeTDD.TDDBasic.Tools.XUnit;

namespace Zhangyi.PracticeTDD.TDDBasic.Test.Tools.XUnit
{
    public class PersonUsingMemberDataTest
    {
        [Theory]
        [MemberData(nameof(ArrangePerson))]
        public void Should_has_mobile(Person person, bool hasMobile)
        {
            Assert.Equal(hasMobile, person.HasMobile());
        }

        public static IEnumerable<object[]> ArrangePerson()
        {
            yield return new object[] {new Person("zhangyi", null), false};
            yield return new object[] {new Person("bruce zhang", "15088888888"), true};
            yield return new object[] {new Person("James Zhang", ""), false};
        }
    }
}