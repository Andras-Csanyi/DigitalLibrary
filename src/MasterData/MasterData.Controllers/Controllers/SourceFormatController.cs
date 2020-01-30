namespace DigitalLibrary.MasterData.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BusinessLogic.Interfaces;

    using DomainModel;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using Utils.Guards;

    using Web.Api;

    [ApiController]
    [Route(MasterDataApi.SourceFormat.SourceFormatBase)]
    public class SourceFormatController : ControllerBase
    {
        private readonly IMasterDataBusinessLogic _masterDataBusinessLogic;

        public SourceFormatController(
            IMasterDataBusinessLogic masterDataBusinessLogic)
        {
            Check.IsNotNull(masterDataBusinessLogic);
            _masterDataBusinessLogic = masterDataBusinessLogic;
        }

        [HttpGet]
        [Route(MasterDataApi.SourceFormat.V1.GetAll)]
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
        [Route(MasterDataApi.SourceFormat.V1.Add)]
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

        [HttpPost]
        [Route(MasterDataApi.SourceFormat.V1.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SourceFormat>> GetSourceFormatByIdAsync(SourceFormat sourceFormat)
        {
            try
            {
                SourceFormat result = await _masterDataBusinessLogic.GetSourceFormatByIdAsync(sourceFormat)
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route(MasterDataApi.SourceFormat.V1.Update)]
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
        [Route(MasterDataApi.SourceFormat.V1.Delete)]
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