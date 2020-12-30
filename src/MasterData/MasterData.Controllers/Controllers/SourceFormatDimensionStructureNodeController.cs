namespace DigitalLibrary.MasterData.Controllers
{
    using System;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Web Api Controller for <see cref="SourceFormatDimensionStructureNode"/>.
    /// </summary>
    [ApiController]
    [Route(MasterDataApi.SourceFormatDimensionStructureNode.BasePath)]
    public class SourceFormatDimensionStructureNodeController : ControllerBase
    {
        private readonly IMasterDataBusinessLogic _masterDataBusinessLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceFormatDimensionStructureNodeController"/> class.
        /// </summary>
        /// <param name="masterDataBusinessLogic">
        /// Instance of Master Data Business Logic.
        /// </param>
        public SourceFormatDimensionStructureNodeController(
            IMasterDataBusinessLogic masterDataBusinessLogic)
        {
            Check.IsNotNull(masterDataBusinessLogic);
            _masterDataBusinessLogic = masterDataBusinessLogic;
        }

        [HttpPost]
        [Route(MasterDataApi.SourceFormatDimensionStructureNode.V1.Add)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SourceFormatDimensionStructureNode>> AddAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default)
        {
            try
            {
                SourceFormatDimensionStructureNode node = await _masterDataBusinessLogic
                   .MasterDataSourceFormatDimensionStructureNodeBusinessLogic
                   .AddAsync(
                        sourceFormatDimensionStructureNode,
                        cancellationToken)
                   .ConfigureAwait(false);
                return Ok(node);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(MasterDataApi.SourceFormatDimensionStructureNode.V1.Update)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SourceFormatDimensionStructureNode>> UpdateAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default)
        {
            try
            {
                SourceFormatDimensionStructureNode node = await _masterDataBusinessLogic
                   .MasterDataSourceFormatDimensionStructureNodeBusinessLogic
                   .UpdateAsync(
                        sourceFormatDimensionStructureNode,
                        cancellationToken)
                   .ConfigureAwait(false);
                return Ok(node);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}