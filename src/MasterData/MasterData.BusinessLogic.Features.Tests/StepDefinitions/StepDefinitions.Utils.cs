// <copyright file="SourceFormatFeature.Background.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        private TType GetValueFromScenarioContext<TType>(string key, ScenarioContext context)
            where TType : class
        {
            return context[key] as TType;
        }

        private Task<DimensionStructureNode> FindDimensionStructureNodeInTree(
            SourceFormat result,
            DimensionStructureNode dimensionStructureNode)
        {
            DimensionStructureNode found;
            foreach (DimensionStructureNode node in result.DimensionStructureNodes)
            {
                found = TraverseForDimensionStructureNodeInTree(node.ChildNodes);
            }
        }
    }
}