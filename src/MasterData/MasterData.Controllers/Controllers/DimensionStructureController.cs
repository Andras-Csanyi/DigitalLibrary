namespace DigitalLibrary.MasterData.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BusinessLogic.Interfaces;

    using DomainModel.DomainModel;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using Web.Api.Api;

    [ApiController]
    [Route(MasterDataApi.DimensionStructure.V1.DimensionStructureBase)]
    public class DimensionStructureController : ControllerBase
    {
        private readonly IMasterDataBusinessLogic _masterDataBusinessLogic;

        public DimensionStructureController(
            IMasterDataBusinessLogic masterDataBusinessLogic)
        {
            _masterDataBusinessLogic = masterDataBusinessLogic ?? throw new ArgumentNullException();
        }

        [HttpPost]
        [Route(MasterDataApi.DimensionStructure.V1.AddDimensionStructure)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DimensionStructure>> AddDimensionStructure(
            DimensionStructure dimensionStructure)
        {
            try
            {
                DimensionStructure result = await _masterDataBusinessLogic.AddDimensionStructureAsync(
                    dimensionStructure).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route(MasterDataApi.DimensionStructure.V1.UpdateDimensionStructure)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DimensionStructure>> Update(DimensionStructure dimensionStructure)
        {
            try
            {
                DimensionStructure result = await _masterDataBusinessLogic
                   .UpdateDimensionStructureAsync(dimensionStructure)
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route(MasterDataApi.DimensionStructure.V1.DeleteDimensionStructure)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(DimensionStructure dimensionStructure)
        {
            try
            {
                await _masterDataBusinessLogic.DeleteDimensionStructureAsync(dimensionStructure).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(MasterDataApi.DimensionStructure.V1.GetDimensionStructures)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<DimensionStructure>>> GetDimensionStructures()
        {
            try
            {
                List<DimensionStructure> result = await _masterDataBusinessLogic.GetDimensionStructuresAsync()
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