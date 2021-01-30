// <copyright file="ModuleController.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Mime;
    using System.Threading.Tasks;

    using DigitalLibrary.ControlPanel.BusinessLogic.Interfaces.Interfaces;
    using DigitalLibrary.ControlPanel.Controllers.Exceptions;
    using DigitalLibrary.ControlPanel.DomainModel.Entities;
    using DigitalLibrary.ControlPanel.WebApi.Api;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route(ControlPanelWebApi.Module.Base)]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleBusinessLogic _moduleBusinessLogic;

        public ModuleController(IModuleBusinessLogic moduleBusinessLogic)
        {
            _moduleBusinessLogic = moduleBusinessLogic;
        }

        [HttpPost]
        [Route(ControlPanelWebApi.Module.Add)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Module>> AddAsync(Module module)
        {
            try
            {
                if (module == null)
                {
                    string msg = $"Null Argument: {nameof(ModuleController)}.{nameof(AddAsync)}";
                    throw new ModuleControllerArgumentNullException(msg);
                }

                Module result = await _moduleBusinessLogic.AddAsync(module).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route(ControlPanelWebApi.Module.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> DeleteAsync(Module module)
        {
            try
            {
                if (module == null)
                {
                    string msg = $"Null argument: {nameof(ModuleController)}{nameof(DeleteAsync)}";
                    throw new ModuleControllerArgumentNullException(msg);
                }

                await _moduleBusinessLogic.DeleteAsync(module).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(ControlPanelWebApi.Module.Find)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Module>> FindAsync(Module module)
        {
            try
            {
                if (module == null)
                {
                    string msg = $"Null argument: {nameof(ModuleController)}.{nameof(FindAsync)}";
                    throw new ModuleControllerArgumentNullException(msg);
                }

                Module result = await _moduleBusinessLogic.FindAsync(module).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(ControlPanelWebApi.Module.GetAllActive)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<Module>>> GetAllActiveAsync()
        {
            try
            {
                List<Module> result = await _moduleBusinessLogic.GetAllActiveAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(ControlPanelWebApi.Module.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<Module>>> GetAllAsync()
        {
            try
            {
                List<Module> result = await _moduleBusinessLogic.GetAllAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route(ControlPanelWebApi.Module.Modify)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Module>> ModifyAsync(Module module)
        {
            try
            {
                if (module == null)
                {
                    string msg = $"Null argument: {nameof(ModuleController)}.{nameof(ModifyAsync)}";
                    throw new ModuleControllerArgumentNullException(msg);
                }

                Module result = await _moduleBusinessLogic.ModifyAsync(module).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}