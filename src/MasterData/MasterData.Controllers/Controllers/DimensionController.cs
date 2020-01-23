namespace DigitalLibrary.MasterData.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BusinessLogic.Interfaces;

    using DomainModel;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using Web.Api;

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

            _masterDataBusinessLogic = masterDataBusinessLogic;
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
        public async Task<ActionResult<Dimension>> ModifyDimensionAsync(Dimension dimension)
        {
            try
            {
                Dimension result = await _masterDataBusinessLogic.ModifyDimensionAsync(
                        dimension)
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(MasterDataApi.Dimensions.V1.GetAllActive)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Dimension>>> GetActiveDimensions()
        {
            try
            {
                List<Dimension> result = await _masterDataBusinessLogic.GetDimensionsAsync()
                   .ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(MasterDataApi.Dimensions.V1.GetDimensionsWithoutStructure)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Dimension>>> GetDimensionsWithoutStructure()
        {
            try
            {
                List<Dimension> result = await _masterDataBusinessLogic.GetDimensionsWithoutStructureAsync()
                   .ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}