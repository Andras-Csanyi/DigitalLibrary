namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;
    using DigitalLibrary.Utils.MasterDataTestHelper;

    using FluentAssertions;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        [Then(@"'(.*)' SourceFormat's '(.*)' value is '(.*)'")]
        public void ThenSourceFormatIsActive(
            string key,
            string property,
            string expectedValue)
        {
            Check.NotNullOrEmptyOrWhitespace(key);
            Check.NotNullOrEmptyOrWhitespace(property);
            Check.NotNullOrEmptyOrWhitespace(expectedValue);

            SourceFormat result = _scenarioContext[key] as SourceFormat;

            switch (property)
            {
                case SourceFormatPropertiesStruct.Name:
                    result.Name.Should().Be(expectedValue);
                    break;

                case SourceFormatPropertiesStruct.Desc:
                    result.Desc.Should().Be(expectedValue);
                    break;

                case SourceFormatPropertiesStruct.IsActive:
                    int exp = Convert.ToInt32(expectedValue);
                    result.IsActive.Should().Be(exp);
                    break;
            }
        }
    }
}