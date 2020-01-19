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

    using WebApi.Api;

    [ApiController]
    [Route(ControlPanelWebApi.Menu.Base)]
    public class MenuController : ControllerBase
    {
        private IMenuBusinessLogic _menuBusinessLogic;

        public MenuController(IMenuBusinessLogic menuBusinessLogic)
        {
            _menuBusinessLogic = menuBusinessLogic;
        }

        [HttpGet]
        [Route(ControlPanelWebApi.Menu.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<Menu>>> GetAllAsync()
        {
            try
            {
                List<Menu> result = await _menuBusinessLogic.GetAllAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(ControlPanelWebApi.Menu.GetAllActive)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<Menu>>> GetAllActiveAsync()
        {
            try
            {
                List<Menu> result = await _menuBusinessLogic.GetAllActiveAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(ControlPanelWebApi.Menu.Add)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Menu>> AddAsync(Menu menu)
        {
            try
            {
                if (menu == null)
                {
                    string msg = $"Null input: {nameof(MenuController)}.{nameof(AddAsync)}";
                    throw new MenuControllerNullInputException(msg);
                }

                Menu menuResult = await _menuBusinessLogic.AddAsync(menu).ConfigureAwait(false);
                return Ok(menuResult);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route(ControlPanelWebApi.Menu.Modify)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Menu>> ModifyAsync(Menu menu)
        {
            try
            {
                if (menu == null)
                {
                    string msg = $"Null input: {nameof(MenuController)}.{nameof(ModifyAsync)}";
                    throw new MenuControllerNullInputException(msg);
                }

                Menu result = await _menuBusinessLogic.ModifyAsync(menu).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route(ControlPanelWebApi.Menu.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> DeleteAsync(Menu menu)
        {
            try
            {
                if (menu == null)
                {
                    string msg = $"Null input: {nameof(MenuController)}.{nameof(DeleteAsync)}";
                    throw new MenuControllerNullInputException(msg);
                }

                await _menuBusinessLogic.DeleteAsync(menu).ConfigureAwait(false);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}