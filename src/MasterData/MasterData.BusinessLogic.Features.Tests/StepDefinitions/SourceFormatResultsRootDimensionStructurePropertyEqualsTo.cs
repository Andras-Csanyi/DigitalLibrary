namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
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
        [Then(@"SourceFormat result's RootDimensionStructure property equals to")]
        public void SourceFormatResultsRootDimensionStructurePropertyEqualsTo(Table table)
        {
            SourceFormatResultsRootDimensionStructurePropertyEqualsToEntity instance =
                table.CreateInstance<SourceFormatResultsRootDimensionStructurePropertyEqualsToEntity>();

            DomainModel.SourceFormat result = _scenarioContext[instance.Key] as SourceFormat;
            DomainModel.DimensionStructure comparedTo = _scenarioContext[instance.EqualsTo] as DimensionStructure;

            switch (instance.PropertyName)
            {
                case DimensionStructurePropertiesStruct.Name:
                    result.SourceFormatDimensionStructureNode.DimensionStructureNode.DimensionStructure.Name
                       .Should()
                       .Be(comparedTo.Name);
                    break;

                case DimensionStructurePropertiesStruct.Desc:
                    result.SourceFormatDimensionStructureNode.DimensionStructureNode.DimensionStructure.Desc
                       .Should()
                       .Be(comparedTo.Desc);
                    break;

                case DimensionStructurePropertiesStruct.IsActive:
                    result.SourceFormatDimensionStructureNode.DimensionStructureNode.DimensionStructure.IsActive
                       .Should()
                       .Be(comparedTo.IsActive);
                    break;

                default:
                    throw new Exception(
                        nameof(SourceFormatResultsRootDimensionStructurePropertyEqualsTo));
            }
        }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    internal class SourceFormatResultsRootDimensionStructurePropertyEqualsToEntity
    {
        public string EqualsTo { get; set; }

        public string Key { get; set; }

        public string PropertyName { get; set; }
    }
}