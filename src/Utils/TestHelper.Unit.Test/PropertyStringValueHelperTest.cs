namespace TestHelper.Unit.Test
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.Utils.MasterDataTestHelper.Helpers.ObjectPropertyValueHelper;

    using FluentAssertions;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class PropertyStringValueHelperTest
    {
        private Dictionary<string, string> _rules = new Dictionary<string, string>
        {
            { "empty", string.Empty },
            { "3spaces", "   " },
            { "null", null },
        };

        [Theory]
        [InlineData("asd", "asd")]
        [InlineData("bsd", "bsd")]
        [InlineData("empty", "")]
        [InlineData("3spaces", "   ")]
        [InlineData("null", null)]
        public void Should_FilterInputAndModifyAccordingToRules(string input, string expectedResult)
        {
            string result = ObjectPropertyValueHelper.CreateStringValueForProperty(input, _rules);
            result.Should().Be(expectedResult);
        }
    }
}