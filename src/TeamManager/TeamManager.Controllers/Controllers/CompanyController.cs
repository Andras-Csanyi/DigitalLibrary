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
    [Route(TeamManagerWebApi.CompanyApi.CompanyBase)]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyBusinessLogic _companyBusinessLogic;

        public CompanyController(ICompanyBusinessLogic companyBusinessLogic)
        {
            _companyBusinessLogic = companyBusinessLogic ?? throw new ArgumentNullException(nameof(CompanyController));
        }

        [HttpPost]
        [Route(TeamManagerWebApi.CompanyApi.Add)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<Company>> AddAsync(Company company)
        {
            try
            {
                if (company == null)
                {
                    throw new ArgumentNullException($"{nameof(CompanyController)}.{nameof(AddAsync)}");
                }

                Company result = await _companyBusinessLogic.AddAsync(company).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route(TeamManagerWebApi.CompanyApi.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync(Company company)
        {
            try
            {
                if (company == null)
                {
                    throw new ArgumentNullException($"{nameof(CompanyController)}.{nameof(DeleteAsync)}");
                }

                await _companyBusinessLogic.DeleteAsync(company).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route(TeamManagerWebApi.CompanyApi.Find)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Company>> FindAsync(Company company)
        {
            try
            {
                if (company == null)
                {
                    throw new ArgumentNullException($"{nameof(CompanyController)}.{nameof(FindAsync)}");
                }

                Company result = await _companyBusinessLogic.FindAsync(company).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(TeamManagerWebApi.CompanyApi.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<List<Company>>> GetAllAsync()
        {
            try
            {
                List<Company> result = await _companyBusinessLogic.GetAllAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route(TeamManagerWebApi.CompanyApi.GetAllActive)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Company>>> GetAllActiveAsync()
        {
            try
            {
                List<Company> result = await _companyBusinessLogic.GetAllActiveAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route(TeamManagerWebApi.CompanyApi.Modify)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Company>>> ModifyAsync(Company company)
        {
            try
            {
                if (company == null)
                {
                    throw new ArgumentNullException($"{nameof(CompanyController)}.{nameof(ModifyAsync)}");
                }

                Company result = await _companyBusinessLogic.ModifyAsync(company).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}