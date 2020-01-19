namespace DigitalLibrary.ControlPanel.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Mime;
    using System.Threading.Tasks;

    using BusinessLogic.Interfaces.Interfaces;

    using DomainModel.Entities;

    using Exceptions;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using WebApi.Api.Api;

    [ApiController]
    [Route(ControlPanelWebApi.Module.Base)]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleBusinessLogic ModuleBusinessLogic;

        public ModuleController(IModuleBusinessLogic moduleBusinessLogic)
        {
            ModuleBusinessLogic = moduleBusinessLogic;
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
                List<Module> result = await ModuleBusinessLogic.GetAllAsync().ConfigureAwait(false);
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
                List<Module> result = await ModuleBusinessLogic.GetAllActiveAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
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

                Module result = await ModuleBusinessLogic.AddAsync(module).ConfigureAwait(false);
                return Ok(result);
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

                Module result = await ModuleBusinessLogic.FindAsync(module).ConfigureAwait(false);
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

                await ModuleBusinessLogic.DeleteAsync(module).ConfigureAwait(false);
                return Ok();
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

                Module result = await ModuleBusinessLogic.ModifyAsync(module).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}