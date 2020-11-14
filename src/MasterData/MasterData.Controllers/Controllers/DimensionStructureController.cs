// <copyright file="DimensionStructureController.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route(MasterDataApi.DimensionStructure.RouteBase)]
    public class DimensionStructureController : ControllerBase
    {
        private readonly IMasterDataBusinessLogic _masterDataBusinessLogic;

        public DimensionStructureController(
            IMasterDataBusinessLogic masterDataBusinessLogic)
        {
            Check.IsNotNull(masterDataBusinessLogic);
            _masterDataBusinessLogic = masterDataBusinessLogic;
        }

        [HttpPost]
        [Route(MasterDataApi.DimensionStructure.V1.Add)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DimensionStructure>> AddDimensionStructure(
            DimensionStructure dimensionStructure)
        {
            try
            {
                DimensionStructure result = await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
                   .AddAsync(dimensionStructure)
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
                await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
                   .InactivateAsync(dimensionStructure).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(MasterDataApi.DimensionStructure.V1.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DimensionStructure>> GetDimensionStructureByIdAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default)
        {
            try
            {
                DimensionStructure result = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .GetByIdAsync(dimensionStructure, cancellationToken)
                   .ConfigureAwait(false);
                return Ok(result);
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
                List<DimensionStructure> result = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic.GetDimensionStructuresAsync()
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(MasterDataApi.DimensionStructure.V1.GetDimensionStructuresByIds)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<DimensionStructure>>> GetDimensionStructuresByIdsAsync(
            DimensionStructureQueryObject dimensionStructureQueryObject)
        {
            try
            {
                List<DimensionStructure> result = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic.GetDimensionStructuresByIdsAsync(
                        dimensionStructureQueryObject)
                   .ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route(MasterDataApi.DimensionStructure.V1.Update)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DimensionStructure>> UpdateAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default)
        {
            try
            {
                DimensionStructure result = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic.UpdateAsync(dimensionStructure, cancellationToken)
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