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
    [Route(MasterDataApi.DimensionStructure.V1.DimensionStructureBase)]
    public class SourceFormatController : ControllerBase
    {
        private readonly IMasterDataBusinessLogic _masterDataBusinessLogic;

        public SourceFormatController(
            IMasterDataBusinessLogic masterDataBusinessLogic)
        {
            _masterDataBusinessLogic = masterDataBusinessLogic ?? throw new ArgumentNullException();
        }

        [HttpGet]
        [Route(MasterDataApi.DimensionStructure.V1.GetSourceFormats)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<SourceFormat>>> GetSourceFormatsAsync()
        {
            try
            {
                List<SourceFormat> result = await _masterDataBusinessLogic.GetSourceFormatsAsync()
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(MasterDataApi.DimensionStructure.V1.AddSourceFormat)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SourceFormat>> AddSourceFormatAsync(
            SourceFormat sourceFormat)
        {
            try
            {
                SourceFormat result = await _masterDataBusinessLogic.AddSourceFormatAsync(
                    sourceFormat).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route(MasterDataApi.DimensionStructure.V1.UpdateSourceFormat)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SourceFormat>> UpdateSourceFormatAsync(
            SourceFormat sourceFormat)
        {
            try
            {
                SourceFormat result = await _masterDataBusinessLogic
                   .UpdateSourceFormatAsync(sourceFormat)
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route(MasterDataApi.DimensionStructure.V1.DeleteSourceFormatAsync)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteSourceFormatAsync(SourceFormat sourceFormat)
        {
            try
            {
                await _masterDataBusinessLogic.DeleteSourceFormatAsync(sourceFormat).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}