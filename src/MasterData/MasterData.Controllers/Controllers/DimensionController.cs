// <copyright file="DimensionController.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;
    using DigitalLibrary.Utils.Guards;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route(MasterDataApi.Dimensions.V1.DimensionRouteBase)]
    public class DimensionController : ControllerBase
    {
        private readonly IMasterDataBusinessLogic _masterDataBusinessLogic;

        public DimensionController(
            IMasterDataBusinessLogic masterDataBusinessLogic)
        {
            Check.IsNotNull(masterDataBusinessLogic);

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

        [HttpDelete]
        [Route(MasterDataApi.Dimensions.V1.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteDimensionAsync(Dimension dimension)
        {
            try
            {
                await _masterDataBusinessLogic.DeleteDimensionAsync(dimension)
                   .ConfigureAwait(false);
                return Ok();
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

        [HttpPost]
        [Route(MasterDataApi.Dimensions.V1.GetDimensionById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Dimension>> GetDimensionById(long dimensionId)
        {
            try
            {
                Dimension result = await _masterDataBusinessLogic.GetDimensionByIdAsync(dimensionId)
                   .ConfigureAwait(false);
                return result;
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

        [HttpPut]
        [Route(MasterDataApi.Dimensions.V1.Modify)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Dimension>> ModifyDimensionAsync(Dimension dimension)
        {
            try
            {
                Dimension result = await _masterDataBusinessLogic.UpdateDimensionAsync(
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