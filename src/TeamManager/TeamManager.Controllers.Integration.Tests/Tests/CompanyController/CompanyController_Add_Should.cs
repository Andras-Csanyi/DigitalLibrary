namespace TeamManager.Controllers.Integration.Tests.Tests.CompanyController
{
    using System.Threading.Tasks;

    using DigitalLibrary.IaC.TeamManager.DomainModel.Entities;

    using FluentAssertions;

    using Microsoft.AspNetCore.Mvc;

    public class CompanyController_Add_Should : TestBase
    {
        public async Task Add_AnItem()
        {
            // Arrange
            Company newCompany = new Company
            {
                Name = "asdasd",
                Description = "asdasd",
                Url = "asdasd",
                IsActive = 1
            };

            // Act
            ActionResult<Company> result = await _companyController.AddAsync(newCompany).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
        }
    }
}