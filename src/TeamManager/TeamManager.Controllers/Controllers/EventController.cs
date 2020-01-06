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
    [Route(TeamManagerWebApi.EventApi.EventBase)]
    public class EventController : ControllerBase
    {
        private readonly IEventBusinessLogic EventBusinessLogic;

        public EventController(
            IEventBusinessLogic eventBusinessLogic)
        {
            EventBusinessLogic = eventBusinessLogic ?? throw new ArgumentNullException(nameof(EventController));
        }

        [HttpPost]
        [Route(TeamManagerWebApi.EventApi.Add)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Event>> AddAsync(Event newEvent)
        {
            try
            {
                if (newEvent == null)
                {
                    throw new ArgumentNullException($"{nameof(EventController)}.{nameof(AddAsync)}");
                }

                Event result = await EventBusinessLogic.AddAsync(newEvent).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route(TeamManagerWebApi.EventApi.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> DeleteAsync(Event deletedEvent)
        {
            try
            {
                if (deletedEvent == null)
                {
                    throw new ArgumentNullException($"{nameof(EventController)}.{nameof(DeleteAsync)}");
                }

                await EventBusinessLogic.DeleteAsync(deletedEvent).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(TeamManagerWebApi.EventApi.Find)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> FindAsync(Event tobeFoundEvent)
        {
            try
            {
                if (tobeFoundEvent == null)
                {
                    throw new ArgumentNullException($"{nameof(EventController)}.{nameof(FindAsync)}");
                }

                // await EventBusinessLogic.FindAsync(tobeFoundEvent).ConfigureAwait(false);
                throw new NotImplementedException(nameof(FindAsync));
                // return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(TeamManagerWebApi.EventApi.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<Event>>> GetAllAsync()
        {
            try
            {
                List<Event> result = await EventBusinessLogic.GetAllAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(TeamManagerWebApi.EventApi.GetAllActive)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<Event>>> GetAllActiveAsync()
        {
            try
            {
                List<Event> result = await EventBusinessLogic.GetAllActiveAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route(TeamManagerWebApi.EventApi.Modify)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<Event>>> ModifyAsync(Event modifiedEvent)
        {
            try
            {
                if (modifiedEvent == null)
                {
                    throw new ArgumentNullException($"{nameof(EventController)}.{nameof(ModifyAsync)}");
                }

                Event result = await EventBusinessLogic.ModifyAsync(modifiedEvent).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}