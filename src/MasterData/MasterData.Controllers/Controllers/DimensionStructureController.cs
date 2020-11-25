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
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Web.Api;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Controller for managing <see cref="DimensionStructure" /> objects.
    /// </summary>
    [ApiController]
    [Route(MasterDataApi.DimensionStructure.RouteBase)]
    public class DimensionStructureController : ControllerBase
    {
        private readonly IMasterDataBusinessLogic _masterDataBusinessLogic;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DimensionStructureController" /> class.
        /// </summary>
        /// <param name="masterDataBusinessLogic">
        ///     <see cref="IMasterDataBusinessLogic" /> instance, which contains the business logic.
        /// </param>
        public DimensionStructureController(
            IMasterDataBusinessLogic masterDataBusinessLogic)
        {
            Check.IsNotNull(masterDataBusinessLogic);
            _masterDataBusinessLogic = masterDataBusinessLogic;
        }

        /// <summary>
        ///     Controller method for adding new <see cref="DimensionStructure" /> objects.
        /// </summary>
        /// <param name="dimensionStructure">
        ///     <see cref="DimensionStructure" /> payload objects.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>A <see cref="Task{TResult}" /> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        [Route(MasterDataApi.DimensionStructure.V1.Add)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DimensionStructure>> AddAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default)
        {
            try
            {
                DimensionStructure result = await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
                   .AddAsync(dimensionStructure, cancellationToken)
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        ///     Controller method for deleting <see cref="DimensionStructure" />.
        /// </summary>
        /// <param name="dimensionStructure">
        ///     A <see cref="DimensionStructure" /> object which contains data about which <see cref="DimensionStructure" />
        ///     needs to be deleted.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>A <see cref="Task{TResult}" /> representing the result of the asynchronous operation.</returns>
        [HttpDelete]
        [Route(MasterDataApi.DimensionStructure.V1.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await _masterDataBusinessLogic.MasterDataDimensionStructureBusinessLogic
                   .DeleteAsync(dimensionStructure, cancellationToken).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        ///     Controller method for requesting <see cref="DimensionStructure" /> object by Id.
        /// </summary>
        /// <param name="dimensionStructure">
        ///     <see cref="DimensionStructure" /> payload object.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>A <see cref="Task{TResult}" /> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        [Route(MasterDataApi.DimensionStructure.V1.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DimensionStructure>> GetByIdAsync(
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

        /// <summary>
        ///     Controller method for updating a <see cref="DimensionStructure" />.
        /// </summary>
        /// <param name="dimensionStructure">
        ///     A <see cref="DimensionStructure" /> payload object.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>A <see cref="Task{TResult}" /> representing the result of the asynchronous operation.</returns>
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

        /// <summary>
        ///     Controller method for getting list of all <see cref="DimensionStructure" />s.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>A <see cref="Task{TResult}" /> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        [Route(MasterDataApi.DimensionStructure.V1.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<DimensionStructure>>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                List<DimensionStructure> result = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .GetAllAsync(cancellationToken)
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        ///     Controller method for getting all active <see cref="DimensionStructure" />s.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>A <see cref="Task{TResult}" /> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        [Route(MasterDataApi.DimensionStructure.V1.GetActives)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<DimensionStructure>>> GetActivesAsync(CancellationToken cancellationToken)
        {
            try
            {
                List<DimensionStructure> result = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .GetActivesAsync(cancellationToken)
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        ///     Controller method for getting all inactive <see cref="DimensionStructure" />s.
        /// </summary>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>A <see cref="Task{TResult}" /> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        [Route(MasterDataApi.DimensionStructure.V1.GetInActives)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<DimensionStructure>>> GetInActivesAsync(CancellationToken cancellationToken)
        {
            try
            {
                List<DimensionStructure> result = await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .GetInactivesAsync(cancellationToken)
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        ///     Controller method for inactivating <see cref="DimensionStructure" />s.
        /// </summary>
        /// <param name="dimensionStructure">
        ///     Payload <see cref="DimensionStructure" /> object from 3rd party where
        ///     ID marks which <see cref="DimensionStructure" /> going to be inactivated.
        /// </param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>A <see cref="Task{TResult}" /> representing the result of the asynchronous operation.</returns>
        [HttpPut]
        [Route(MasterDataApi.DimensionStructure.V1.Inactivate)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DimensionStructure>> InactivateAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken)
        {
            try
            {
                await _masterDataBusinessLogic
                   .MasterDataDimensionStructureBusinessLogic
                   .InactivateAsync(dimensionStructure, cancellationToken)
                   .ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}