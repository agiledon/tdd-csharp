using System.Collections;
using System.Collections.Generic;
using Xunit;
using Zhangyi.PracticeTDD.TDDBasic.Tools.XUnit;

namespace Zhangyi.PracticeTDD.TDDBasic.Test.Tools.XUnit
{
    public class PersonUsingClassDataTest
    {
        [Theory]
        [ClassData(typeof(PersonData))]
        public void Should_has_mobile(Person person, bool hasMobile)
        {
            Assert.Equal(hasMobile, person.HasMobile());
        }

        class PersonData : IEnumerable<object[]>
        {
            private readonly List<object[]> personData = new List<object[]>
            {
                new object[] {new Person("zhangyi", null), false},
                new object[] {new Person("bruce zhang", "15088888888"), true},
                new object[] {new Person("James Zhang", ""), false}
            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return personData.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}