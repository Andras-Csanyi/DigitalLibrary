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
    [Route(TeamManagerWebApi.PeopleEventLogApi.PeopleEventLogBase)]
    public class PeopleEventLogController : ControllerBase
    {
        private readonly IPeopleEventLogBusinessLogic PeopleEventLogBusinessLogic;

        public PeopleEventLogController(IPeopleEventLogBusinessLogic peopleEventLogBusinessLogic)
        {
            PeopleEventLogBusinessLogic = peopleEventLogBusinessLogic ??
                                          throw new ArgumentNullException(nameof(peopleEventLogBusinessLogic));
        }

        [HttpPost]
        [Route(TeamManagerWebApi.PeopleEventLogApi.Add)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<PeopleEventLog>> AddAsync(PeopleEventLog peopleEventLog)
        {
            try
            {
                if (peopleEventLog == null)
                {
                    throw new ArgumentNullException($"{nameof(PeopleEventLogController)}.{nameof(AddAsync)}");
                }

                PeopleEventLog result = await PeopleEventLogBusinessLogic.AddAsync(peopleEventLog)
                    .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route(TeamManagerWebApi.PeopleEventLogApi.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> DeleteAsync(PeopleEventLog peopleEventLog)
        {
            try
            {
                if (peopleEventLog == null)
                {
                    throw new ArgumentNullException($"{nameof(PeopleEventLogController)}.{nameof(DeleteAsync)}");
                }

                await PeopleEventLogBusinessLogic.DeleteAsync(peopleEventLog)
                    .ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(TeamManagerWebApi.PeopleEventLogApi.Find)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<PeopleEventLog>> FindAsync(PeopleEventLog peopleEventLog)
        {
            try
            {
                if (peopleEventLog == null)
                {
                    throw new ArgumentNullException($"{nameof(PeopleEventLogController)}.{nameof(FindAsync)}");
                }

//                await PeopleEventLogBusinessLogic.FindAsync(peopleEventLog)
//                    .ConfigureAwait(false);
//                return Ok();
                throw new NotImplementedException(nameof(FindAsync));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(TeamManagerWebApi.PeopleEventLogApi.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<PeopleEventLog>>> GetAllAsync()
        {
            try
            {
                List<PeopleEventLog> result = await PeopleEventLogBusinessLogic.GetAllAsync()
                    .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(TeamManagerWebApi.PeopleEventLogApi.GetAllActive)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<PeopleEventLog>>> GetAllActiveAsync()
        {
            try
            {
//                List<PeopleEventLog> result = await PeopleEventLogBusinessLogic.GetAllAsync()
//                    .ConfigureAwait(false);
//                return CreatedAtAction(nameof(GetAllAsync), result);
                throw new NotImplementedException(nameof(GetAllActiveAsync));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route(TeamManagerWebApi.PeopleEventLogApi.Modify)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> ModifyAsync(PeopleEventLog peopleEventLog)
        {
            try
            {
                if (peopleEventLog == null)
                {
                    throw new ArgumentNullException($"{nameof(PeopleEventLogController)}.{nameof(ModifyAsync)}");
                }

                PeopleEventLog result = await PeopleEventLogBusinessLogic.AddAsync(peopleEventLog)
                    .ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(TeamManagerWebApi.PeopleEventLogApi.GetByPerson)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<PeopleEventLog>> GetByPersonAsync(PeopleEventLog peopleEventLog)
        {
            try
            {
                if (peopleEventLog == null)
                {
                    throw new ArgumentNullException($"{nameof(PeopleEventLogController)}.{nameof(GetByPersonAsync)}");
                }

                List<PeopleEventLog> result = await PeopleEventLogBusinessLogic.GetAllByPeople(peopleEventLog.PeopleId)
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