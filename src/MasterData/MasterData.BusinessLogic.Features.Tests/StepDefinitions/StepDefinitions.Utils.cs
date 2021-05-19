// <copyright file="SourceFormatFeature.Background.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
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

        private async Task<DimensionStructureNode> FindDimensionStructureNodeInTree(
            SourceFormat result,
            DimensionStructureNode findDimensionStructureNode)
        {
            return await LookUpForDimensionStructureNodeAsync(
                    result.SourceFormatDimensionStructureNode.DimensionStructureNode,
                    findDimensionStructureNode)
               .ConfigureAwait(false);
        }

        private async Task<DimensionStructureNode> LookUpForDimensionStructureNodeAsync(
            DimensionStructureNode singleNodeFromTree,
            DimensionStructureNode searchedNode)
        {
            if (singleNodeFromTree.Id == searchedNode.Id)
            {
                return singleNodeFromTree;
            }

            if (singleNodeFromTree.ChildNodes.Any())
            {
                foreach (DimensionStructureNode node in singleNodeFromTree.ChildNodes)
                {
                    DimensionStructureNode partialResult;
                    partialResult = await LookUpForDimensionStructureNodeAsync(node, searchedNode)
                       .ConfigureAwait(false);
                    if (partialResult is null)
                    {
                        continue;
                    }

                    return partialResult;
                }
            }

            return null;
        }

        private async Task<LookUpForDimensionStructureNodeAndParentResult>
            FindDimensionStructureNodeWithItsParentInTree(
                SourceFormat result,
                DimensionStructureNode findDimensionStructureNode)
        {
            return await LookUpForDimensionStructureNodeWithItsParentAsync(
                    result.SourceFormatDimensionStructureNode.DimensionStructureNode,
                    findDimensionStructureNode,
                    null)
               .ConfigureAwait(false);
        }


        private async Task<LookUpForDimensionStructureNodeAndParentResult>
            LookUpForDimensionStructureNodeWithItsParentAsync(
                DimensionStructureNode node,
                DimensionStructureNode searchedNode,
                DimensionStructureNode parentNode)
        {
            if (node.Id == searchedNode.Id)
            {
                return new LookUpForDimensionStructureNodeAndParentResult
                {
                    Actual = searchedNode,
                    Parent = parentNode,
                };
            }

            if (node.ChildNodes.Any())
            {
                foreach (DimensionStructureNode singleNode in node.ChildNodes)
                {
                    LookUpForDimensionStructureNodeAndParentResult partialResult;
                    partialResult = await LookUpForDimensionStructureNodeWithItsParentAsync(
                            singleNode,
                            searchedNode,
                            node)
                       .ConfigureAwait(false);
                    if (partialResult is null)
                    {
                        continue;
                    }

                    return partialResult;
                }
            }

            return null;
        }
    }

    [ExcludeFromCodeCoverage]
    internal class LookUpForDimensionStructureNodeAndParentResult
    {
        public DimensionStructureNode Actual { get; set; }

        public DimensionStructureNode Parent { get; set; }
    }
}
