using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalLibrary.MasterData.BusinessLogic.Interfaces.Interfaces;
using DigitalLibrary.MasterData.DomainModel.DomainModel;
using DigitalLibrary.MasterData.Web.Api.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary.MasterData.Controllers.Controllers
{
    [ApiController]
    [Route(MasterDataApi.DimensionStructure.V1.DimensionStructureBase)]
    public class TopDimensionStructureController : ControllerBase
    {
        private readonly IMasterDataBusinessLogic _masterDataBusinessLogic;

        public TopDimensionStructureController(
            IMasterDataBusinessLogic masterDataBusinessLogic)
        {
            _masterDataBusinessLogic = masterDataBusinessLogic ?? throw new ArgumentNullException();
        }

        [HttpGet]
        [Route(MasterDataApi.DimensionStructure.V1.GetTopDimensionStructures)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<DimensionStructure>>> GetTopDimensionStructures()
        {
            try
            {
                List<DimensionStructure> result = await _masterDataBusinessLogic.GetTopDimensionStructuresAsync()
                    .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(MasterDataApi.DimensionStructure.V1.AddTopDimensionStructure)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DimensionStructure>> AddTopDimensionStructure(
            DimensionStructure dimensionStructure)
        {
            try
            {
                DimensionStructure result = await _masterDataBusinessLogic.AddTopDimensionStructureAsync(
                    dimensionStructure).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // [HttpPut]
        // [Route(MasterDataApi.DimensionStructure.V1.Update)]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<ActionResult<DimensionStructure>> Update(DimensionStructure dimensionStructure)
        // {
        //     try
        //     {
        //         DimensionStructure result = await _masterDataBusinessLogic
        //             .UpdateDimensionStructureAsync(dimensionStructure)
        //             .ConfigureAwait(false);
        //         return Ok(result);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e);
        //     }
        // }

        [HttpPut]
        [Route(MasterDataApi.DimensionStructure.V1.UpdateTopDimensionStructure)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DimensionStructure>> UpdateTopDimensionStructureAsync(
            DimensionStructure dimensionStructure)
        {
            try
            {
                DimensionStructure result = await _masterDataBusinessLogic
                    .UpdateTopDimensionStructureAsync(dimensionStructure)
                    .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route(MasterDataApi.DimensionStructure.V1.DeleteTopDimensionStructure)]
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
    }
}