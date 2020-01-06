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
    using Microsoft.Extensions.Logging;

    using WebApi.Api.Api;

    [ApiController]
    [Route(TeamManagerWebApi.PositionApi.PositionBase)]
    public class PositionController : ControllerBase
    {
        private readonly ILogger _logger;

        private readonly IPositionBusinessLogic _positionBusinessLogic;

        public PositionController(
            IPositionBusinessLogic positionBusinessLogic,
            ILogger<PositionController> logger)
        {
            _positionBusinessLogic = positionBusinessLogic
                                     ?? throw new ArgumentNullException(nameof(positionBusinessLogic));
            _logger = logger;
        }

        [HttpPost]
        [Route(TeamManagerWebApi.PositionApi.Add)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Position>> AddAsync(Position position)
        {
            try
            {
                if (position == null)
                {
                    throw new ArgumentNullException($"{nameof(PositionController)}.{nameof(AddAsync)}");
                }

                Position result = await _positionBusinessLogic.AddAsync(position).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route(TeamManagerWebApi.PositionApi.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> DeleteAsync(Position position)
        {
            try
            {
                if (position == null)
                {
                    throw new ArgumentNullException($"{nameof(PositionController)}.{nameof(DeleteAsync)}");
                }

                await _positionBusinessLogic.DeleteAsync(position).ConfigureAwait(false);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(TeamManagerWebApi.PositionApi.Find)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Position>> FindAsync(Position position)
        {
            try
            {
                if (position == null)
                {
                    throw new ArgumentNullException($"{nameof(PositionController)}.{nameof(FindAsync)}");
                }

                Position result = await _positionBusinessLogic.FindAsync(position).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(TeamManagerWebApi.PositionApi.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<Position>>> GetAllAsync()
        {
            try
            {
                List<Position> result = await _positionBusinessLogic.GetAllAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(TeamManagerWebApi.PositionApi.GetAllActive)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<Position>>> GetAllActiveAsync()
        {
            try
            {
                List<Position> result = await _positionBusinessLogic.GetAllActiveAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route(TeamManagerWebApi.PositionApi.Modify)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Position>> ModifyAsync(Position position)
        {
            try
            {
                if (position == null)
                {
                    throw new ArgumentNullException($"{nameof(PositionController)}.{nameof(ModifyAsync)}");
                }

                Position result = await _positionBusinessLogic.ModifyAsync(position).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}