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
    ///     Web Api Controller for <see cref="DimensionStructureNode"/>.
    /// </summary>
    [ApiController]
    [Route(MasterDataApi.DimensionStructureNode.BasePath)]
    public class DimensionStructureNodeController : ControllerBase
    {
        private readonly IMasterDataBusinessLogic _masterDataBusinessLogic;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DimensionStructureNodeController"/> class.
        /// </summary>
        /// <param name="masterDataBusinessLogic">
        ///     Instance of <see cref="IMasterDataBusinessLogic"/>.
        /// </param>
        public DimensionStructureNodeController(IMasterDataBusinessLogic masterDataBusinessLogic)
        {
            Check.IsNotNull(masterDataBusinessLogic);
            _masterDataBusinessLogic = masterDataBusinessLogic;
        }

        [HttpPost]
        [Route(MasterDataApi.DimensionStructureNode.V1.Add)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DimensionStructureNode>> AddAsync(
            DimensionStructureNode dimensionStructureNode,
            CancellationToken cancellationToken = default)
        {
            try
            {
                DimensionStructureNode result = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureNodeBusinessLogic
                   .AddAsync(dimensionStructureNode, cancellationToken)
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