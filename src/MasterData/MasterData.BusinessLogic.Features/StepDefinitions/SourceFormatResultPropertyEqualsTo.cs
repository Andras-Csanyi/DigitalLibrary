namespace DigitalLibrary.MasterData.BusinessLogic.Features.StepDefinitions
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.MasterDataTestHelper;

    using FluentAssertions;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    public partial class StepDefinitions
    {
        [Then(@"SourceFormat result property equals to")]
        public void SourceFormatResultPropertyEqualsTo(Table table)
        {
            SourceFormatResultPropertyEqualsToEntity instance =
                table.CreateInstance<SourceFormatResultPropertyEqualsToEntity>();

            DomainModel.SourceFormat result = _scenarioContext[instance.Key] as SourceFormat;
            DomainModel.SourceFormat comparedTo = _scenarioContext[instance.EqualsTo] as SourceFormat;

            switch (instance.PropertyName)
            {
                case SourceFormatPropertiesStruct.SourceFormatDimensionStructure:
                    // result.DimensionStructureTreeRoot.Should().NotBe(comparedTo.DimensionStructureTreeRoot);
                    break;

                case SourceFormatPropertiesStruct.Name:
                    result.Name.Should().Be(comparedTo.Name);
                    break;

                case SourceFormatPropertiesStruct.Desc:
                    result.Desc.Should().Be(comparedTo.Desc);
                    break;

                case SourceFormatPropertiesStruct.IsActive:
                    result.IsActive.Should().Be(comparedTo.IsActive);
                    break;

                default:
                    throw new Exception($"There is no {instance.PropertyName} property of SourceFormat.");
            }
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class SourceFormatResultPropertyEqualsToEntity
    {
        public string EqualsTo { get; set; }

        public string Key { get; set; }

        public string PropertyName { get; set; }
    }
}