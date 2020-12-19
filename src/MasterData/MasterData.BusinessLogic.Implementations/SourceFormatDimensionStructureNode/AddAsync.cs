namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormatDimensionStructureNode
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatDimensionStructureNodeBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<SourceFormatDimensionStructureNode> AddAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    await _masterDataValidators
                       .SourceFormatDimensionStructureNodeValidator
                       .ValidateAndThrowAsync(
                            sourceFormatDimensionStructureNode,
                            ruleSet: SourceFormatDimensionStructureNodeValidatorRulesets.Add)
                       .ConfigureAwait(false);

                    SourceFormatDimensionStructureNode newNode = new SourceFormatDimensionStructureNode();

                    if (sourceFormatDimensionStructureNode.SourceFormat != null
                     && sourceFormatDimensionStructureNode.SourceFormatId != 0)
                    {
                        SourceFormat sourceFormat = await ctx.SourceFormats
                           .FirstOrDefaultAsync(
                                o => o.Id == sourceFormatDimensionStructureNode.SourceFormatId,
                                cancellationToken)
                           .ConfigureAwait(false);

                        if (sourceFormat == null)
                        {
                            string msg = $"No {nameof(SourceFormat)} with id: {sourceFormatDimensionStructureNode.Id}";
                            throw new MasterDataSourceFormatDimensionStructureNodeBusinessLogicException(msg);
                        }

                        newNode.SourceFormat = sourceFormat;
                        newNode.SourceFormatId = sourceFormat.Id;
                    }

                    if (sourceFormatDimensionStructureNode.DimensionStructureNode != null
                     && sourceFormatDimensionStructureNode.DimensionStructureNodeId != 0)
                    {
                        DimensionStructureNode dimensionStructureNode = await ctx.DimensionStructureNodes
                           .FirstOrDefaultAsync(
                                o => o.Id == sourceFormatDimensionStructureNode.DimensionStructureNodeId,
                                cancellationToken)
                           .ConfigureAwait(false);

                        if (dimensionStructureNode == null)
                        {
                            string msg = $"No {nameof(DimensionStructureNode)} with id: " +
                                         $"{sourceFormatDimensionStructureNode.DimensionStructureNodeId}";
                            throw new MasterDataSourceFormatDimensionStructureNodeBusinessLogicException(msg);
                        }

                        newNode.DimensionStructureNode = dimensionStructureNode;
                        newNode.DimensionStructureNodeId = dimensionStructureNode.Id;
                    }

                    await ctx.SourceFormatDimensionStructureNodes.AddAsync(newNode, cancellationToken)
                       .ConfigureAwait(false);
                    await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                    return newNode;
                }
                catch (Exception e)
                {
                    string msg = $"{nameof(MasterDataSourceFormatDimensionStructureNodeBusinessLogic)}." +
                                 $"{nameof(AddAsync)} operation has failed. " +
                                 $"For further info see inner exception!";
                    throw new MasterDataSourceFormatDimensionStructureNodeBusinessLogicException(msg, e);
                }
            }
        }
    }
}