using System;
using Xunit;
using Moq;
using FluentAssertions;

namespace xUnitTestProject
{
    public class UnitTest1
    {
        private bool A(string str)
        {
            return !string.IsNullOrEmpty(str);
        }
        [Fact]
        public void Test1()
        {
            var testName = "test";

            var result = A(testName);

            result.Should().Be(true);
        }
    }
}
