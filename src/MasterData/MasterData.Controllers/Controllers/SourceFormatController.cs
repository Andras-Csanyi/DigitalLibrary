// <copyright file="SourceFormatController.cs" company="Andras Csanyi">
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

    /// <summary>
    ///     Contains only the <see cref="SourceFormat"/> related methods.
    /// </summary>
    [ApiController]
    [Route(MasterDataApi.SourceFormat.BasePath)]
    public class SourceFormatController : ControllerBase
    {
        private readonly IMasterDataBusinessLogic _masterDataBusinessLogic;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SourceFormatController"/> class.
        /// </summary>
        /// <param name="masterDataBusinessLogic">
        ///     <see cref="IMasterDataBusinessLogic"/> instance.
        /// </param>
        public SourceFormatController(
            IMasterDataBusinessLogic masterDataBusinessLogic)
        {
            Check.IsNotNull(masterDataBusinessLogic);
            _masterDataBusinessLogic = masterDataBusinessLogic;
        }

        /// <summary>
        ///     Adding new <see cref="SourceFormat"/> controller method.
        /// </summary>
        /// <param name="sourceFormat">
        ///     The <see cref="SourceFormat"/> object going to be stored.
        /// </param>
        /// <returns>
        ///     A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.
        ///     It contains either the added <see cref="SourceFormat"/> or <see cref="HttpResponse"/> with error message.
        /// </returns>
        [HttpPost]
        [Route(MasterDataApi.SourceFormat.V1.Add)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SourceFormat>> AddAsync(
            SourceFormat sourceFormat)
        {
            try
            {
                SourceFormat result = await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .AddAsync(sourceFormat)
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        ///     Inactivates the given <see cref="SourceFormat"/>.
        /// </summary>
        /// <param name="sourceFormat"> The <see cref="SourceFormat"/> going to be inactivated. </param>
        /// <param name="cancellationToken"> <see cref="CancellationToken"/>. </param>
        /// <returns> A <see cref="Task{TResult}"/> representing the result of the asynchronous operation. </returns>
        [HttpPost]
        [Route(MasterDataApi.SourceFormat.V1.Inactivate)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> InactivateAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .InactivateAsync(sourceFormat, cancellationToken)
                   .ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(MasterDataApi.SourceFormat.V1.GetByIdWithFullDimensionStructureTree)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SourceFormat>> GetByIdWithFullDimensionStructureTree(
            SourceFormat querySourceFormat)
        {
            try
            {
                SourceFormat result = await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .GetSourceFormatByIdWithRootDimensionStructureNodeAsync(querySourceFormat)
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(MasterDataApi.SourceFormat.V1.CreateDimensionStructureNode)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DimensionStructureNode>> CreateDimensionStructureNodeAsync(
            DimensionStructureNode dimensionStructureNode)
        {
            try
            {
                DimensionStructureNode result = await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .CreateDimensionStructureNodeAsync(dimensionStructureNode)
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        ///     Returns a <see cref="SourceFormat"/> object identified by the provided object ID value.
        /// </summary>
        /// <param name="sourceFormat">
        ///     Its ID value identifies the <see cref="SourceFormat"/> requested.
        /// </param>
        /// <returns>
        ///     Returns a <see cref="Task{TResult}"/> representing result of asynchronous operation.
        /// </returns>
        [HttpPost]
        [Route(MasterDataApi.SourceFormat.V1.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SourceFormat>> GetByIdAsync(SourceFormat sourceFormat)
        {
            try
            {
                SourceFormat result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
                   .GetByIdAsync(sourceFormat)
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        ///     Adds the specified <see cref="DimensionStructureNode"/> to the specified <see cref="SourceFormat"/>
        ///     entity as root <see cref="DimensionStructureNode"/>.
        /// </summary>
        /// <param name="addRootDimensionStructureNodeViewModel">
        ///     The view model contains both the
        ///     <see cref="SourceFormat"/> id and <see cref="DimensionStructureNode"/> id.
        /// </param>
        /// <returns>
        ///     A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.
        /// </returns>
        [HttpPost]
        [Route(MasterDataApi.SourceFormat.V1.AddRootDimensionStructureNode)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddRootDimensionStructureNodeAsync(
            AddRootDimensionStructureNodeViewModel addRootDimensionStructureNodeViewModel)
        {
            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .AddRootDimensionStructureNodeAsync(
                        addRootDimensionStructureNodeViewModel.SourceFormatId,
                        addRootDimensionStructureNodeViewModel.DimensionStructureNodeId)
                   .ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        ///     Deletes <see cref="SourceFormat"/> from the system.
        /// </summary>
        /// <param name="sourceFormat"> The <see cref="SourceFormat"/> going to be deleted. </param>
        /// <returns>
        ///     A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.
        /// </returns>
        [HttpDelete]
        [Route(MasterDataApi.SourceFormat.V1.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAsync(SourceFormat sourceFormat)
        {
            try
            {
                await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .DeleteAsync(sourceFormat)
                   .ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        ///     Returns all available <see cref="SourceFormat"/> in the system.
        /// </summary>
        /// <returns> A <see cref="Task{TResult}"/> representing the result of the asynchronous operation. </returns>
        [HttpGet]
        [Route(MasterDataApi.SourceFormat.V1.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<SourceFormat>>> GetAllAsync()
        {
            try
            {
                List<SourceFormat> result = await _masterDataBusinessLogic.MasterDataSourceFormatBusinessLogic
                   .GetSourceFormatsAsync()
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        ///     Updates the given <see cref="SourceFormat"/> entity in the system.
        /// </summary>
        /// <param name="sourceFormat">
        ///     Instance of <see cref="SourceFormat"/> with the new data.
        /// </param>
        /// <returns> A <see cref="Task{TResult}"/> representing the result of the asynchronous operation. </returns>
        [HttpPut]
        [Route(MasterDataApi.SourceFormat.V1.Update)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SourceFormat>> UpdateAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
        {
            try
            {
                SourceFormat result = await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .UpdateAsync(sourceFormat, cancellationToken)
                   .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        ///     Returns all active <see cref="SourceFormat"/> items in the system.
        /// </summary>
        /// <param name="cancellationToken"> <see cref="CancellationToken"/>. </param>
        /// <returns> A <see cref="Task{TResult}"/> representing the result of the asynchronous operation. </returns>
        [HttpGet]
        [Route(MasterDataApi.SourceFormat.V1.GetActives)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<SourceFormat>>> GetActivesAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                List<SourceFormat> result = await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
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
        ///     Returns all inactive <see cref="SourceFormat"/> items in the system.
        /// </summary>
        /// <param name="cancellationToken"> <see cref="CancellationToken"/>. </param>
        /// <returns> A <see cref="Task{TResult}"/> representing the result of the asynchronous operation. </returns>
        [HttpGet]
        [Route(MasterDataApi.SourceFormat.V1.GetInActives)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<SourceFormat>>> GetInActivesAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                List<SourceFormat> result = await _masterDataBusinessLogic
                   .MasterDataSourceFormatBusinessLogic
                   .GetInActivesAsync(cancellationToken)
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
