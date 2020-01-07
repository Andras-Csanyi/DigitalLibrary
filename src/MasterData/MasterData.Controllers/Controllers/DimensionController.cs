namespace DigitalLibrary.IaC.MasterData.Controllers.Controllers
{
    using System;
    using System.Threading.Tasks;

    using BusinessLogic.Interfaces.Interfaces;

    using DomainModel.DomainModel;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using Web.Api.Api;

    [ApiController]
    [Route(MasterDataApi.Dimensions.V1.DimensionRouteBase)]
    public class DimensionController : ControllerBase
    {
        private readonly IMasterDataBusinessLogic _masterDataBusinessLogic;

        public DimensionController(
            IMasterDataBusinessLogic masterDataBusinessLogic)
        {
            if (masterDataBusinessLogic == null)
            {
                throw new ArgumentNullException();
            }
        }

        [HttpPost]
        [Route(MasterDataApi.Dimensions.V1.AddNew)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Dimension>> AddDimensionAsync(Dimension dimension)
        {
            try
            {
                Dimension result = await _masterDataBusinessLogic.AddDimensionAsync(
                        dimension)
                    .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(MasterDataApi.Dimensions.V1.GetDimensionById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Dimension>> GetDimensionByIdAsync(long dimensionId)
        {
            try
            {
                Dimension result = await _masterDataBusinessLogic.GetDimensionByIdAsync(dimensionId)
                    .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route(MasterDataApi.Dimensions.V1.Modify)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Dimension>> ModifyDimensionAsync(long dimensionId, Dimension dimension)
        {
            try
            {
                Dimension result = await _masterDataBusinessLogic.ModifyDimensionAsync(
                        dimensionId,
                        dimension)
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