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
    [Route(TeamManagerWebApi.PeopleApi.PeopleBase)]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleBusinessLogic PeopleBusinessLogic;

        public PeopleController(IPeopleBusinessLogic peopleBusinessLogic)
        {
            PeopleBusinessLogic = peopleBusinessLogic;
        }

        [HttpPost]
        [Route(TeamManagerWebApi.PeopleApi.Add)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<People>> AddAsync(People people)
        {
            try
            {
                if (people == null)
                {
                    throw new ArgumentNullException($"{nameof(PeopleController)}.{nameof(AddAsync)}");
                }

                People result = await PeopleBusinessLogic.AddAsync(people).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route(TeamManagerWebApi.PeopleApi.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> DeleteAsync(People people)
        {
            try
            {
                if (people == null)
                {
                    throw new ArgumentNullException($"{nameof(PeopleController)}.{nameof(DeleteAsync)}");
                }

                await PeopleBusinessLogic.DeleteAsync(people).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(TeamManagerWebApi.PeopleApi.Find)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> FindAsync(People people)
        {
            try
            {
                if (people == null)
                {
                    throw new ArgumentNullException($"{nameof(PeopleController)}.{nameof(FindAsync)}");
                }

                People result = await PeopleBusinessLogic.FindAsync(people).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(TeamManagerWebApi.PeopleApi.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                List<People> result = await PeopleBusinessLogic.GetAllAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(TeamManagerWebApi.PeopleApi.GetAllActive)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> GetAllActiveAsync()
        {
            try
            {
                List<People> result = await PeopleBusinessLogic.GetAllActiveAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route(TeamManagerWebApi.PeopleApi.Modify)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> ModifyAsync(People people)
        {
            try
            {
                if (people == null)
                {
                    throw new ArgumentNullException($"{nameof(PeopleController)}.{nameof(ModifyAsync)}");
                }

                People result = await PeopleBusinessLogic.ModifyAsync(people).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}