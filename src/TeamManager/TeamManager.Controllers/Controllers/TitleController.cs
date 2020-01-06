namespace DigitalLibrary.IaC.TeamManager.Controllers.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Mime;
    using System.Threading.Tasks;

    using BusinessLogic.Interfaces.Interfaces;

    using DomainModel.Entities;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using WebApi.Api.Api;

    [ApiController]
    [Route(TeamManagerWebApi.TitleApi.TitleBase)]
    public class TitleController : ControllerBase
    {
        private readonly ITitleBusinessLogic _titleBusinessLogic;

        public TitleController(ITitleBusinessLogic titleBusinessLogic)
        {
            _titleBusinessLogic = titleBusinessLogic ?? throw new ArgumentNullException(nameof(titleBusinessLogic));
        }

        [HttpPost]
        [Route(TeamManagerWebApi.TitleApi.Add)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Title>> AddAsync(Title title)
        {
            try
            {
                if (title == null)
                {
                    throw new ArgumentNullException($"{nameof(TitleController)}.{nameof(AddAsync)}");
                }

                Title result = await _titleBusinessLogic.AddAsync(title).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route(TeamManagerWebApi.TitleApi.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> DeleteAsync(Title title)
        {
            try
            {
                if (title == null)
                {
                    throw new ArgumentNullException($"{nameof(TitleController)}.{nameof(DeleteAsync)}");
                }

                await _titleBusinessLogic.DeleteAsync(title).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(TeamManagerWebApi.TitleApi.Find)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Title>> FindAsync(Title title)
        {
            try
            {
                if (title == null)
                {
                    throw new ArgumentNullException($"{nameof(TitleController)}.{nameof(FindAsync)}");
                }

                Title result = await _titleBusinessLogic.FindAsync(title).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(TeamManagerWebApi.TitleApi.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<Title>>> GetAllAsync()
        {
            try
            {
                List<Title> result = await _titleBusinessLogic.GetAllAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(TeamManagerWebApi.TitleApi.GetAllActive)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<Title>>> GetAllActiveAsync()
        {
            try
            {
                List<Title> result = await _titleBusinessLogic.GetAllActivesAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route(TeamManagerWebApi.TitleApi.Modify)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Title>> ModifyAsync(Title title)
        {
            try
            {
                if (title == null)
                {
                    throw new ArgumentNullException($"{nameof(TitleController)}.{nameof(ModifyAsync)}");
                }

                Title result = await _titleBusinessLogic.ModifyAsync(title).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}