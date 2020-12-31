namespace DigitalLibrary.MasterData.Controllers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Web Api Controller for <see cref="SourceFormatDimensionStructureNode" />.
    /// </summary>
    [ApiController]
    [Route(MasterDataApi.SourceFormatDimensionStructureNode.BasePath)]
    public class SourceFormatDimensionStructureNodeController : ControllerBase
    {
        private readonly IMasterDataBusinessLogic _masterDataBusinessLogic;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SourceFormatDimensionStructureNodeController" /> class.
        /// </summary>
        /// <param name="masterDataBusinessLogic">
        ///     Instance of Master Data Business Logic.
        /// </param>
        public SourceFormatDimensionStructureNodeController(
            IMasterDataBusinessLogic masterDataBusinessLogic)
        {
            Check.IsNotNull(masterDataBusinessLogic);
            _masterDataBusinessLogic = masterDataBusinessLogic;
        }

        /// <summary>
        ///     Controller method for adding new <see cref="SourceFormatDimensionStructureNode" />.
        /// </summary>
        /// <param name="sourceFormatDimensionStructureNode">
        ///     Describes the new object to be added.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>
        ///     Returns a <see cref="Task{TResult}" /> representing result of async operation, where
        ///     TResult is <see cref="ActionResult" />.
        /// </returns>
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

        /// <summary>
        ///     Controller method for updating a <see cref="SourceFormatDimensionStructureNode" />.
        /// </summary>
        /// <param name="sourceFormatDimensionStructureNode">
        ///     Id value of payload identifies which object should be updated with the properties of
        ///     the payload object.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>
        ///     Returns a <see cref="Task{TResult}" /> representing result of async operation, where
        ///     TResult is <see cref="ActionResult" />.
        /// </returns>
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

        /// <summary>
        ///     Controller method for deleting a <see cref="SourceFormatDimensionStructureNode" />.
        /// </summary>
        /// <param name="sourceFormatDimensionStructureNode">
        ///     Id value of payload identifies which object should be deleted.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>
        ///     Returns a <see cref="Task{TResult}" /> representing result of async operation, where
        ///     TResult is <see cref="ActionResult" />.
        /// </returns>
        [HttpDelete]
        [Route(MasterDataApi.SourceFormatDimensionStructureNode.V1.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SourceFormatDimensionStructureNode>> DeleteAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatDimensionStructureNodeBusinessLogic
                   .DeleteAsync(
                        sourceFormatDimensionStructureNode,
                        cancellationToken)
                   .ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        ///     Controller method for requesting a <see cref="SourceFormatDimensionStructureNode" /> by Id.
        /// </summary>
        /// <param name="sourceFormatDimensionStructureNode">
        ///     Id value of payload identifies which object should be returned.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>
        ///     Returns a <see cref="Task{TResult}" /> representing result of async operation, where
        ///     TResult is <see cref="ActionResult" />.
        /// </returns>
        [HttpPost]
        [Route(MasterDataApi.SourceFormatDimensionStructureNode.V1.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SourceFormatDimensionStructureNode>> GetByIdAsync(
            SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode,
            CancellationToken cancellationToken = default)
        {
            try
            {
                SourceFormatDimensionStructureNode result = await _masterDataBusinessLogic
                   .MasterDataSourceFormatDimensionStructureNodeBusinessLogic
                   .GetByIdAsync(
                        sourceFormatDimensionStructureNode,
                        cancellationToken)
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}