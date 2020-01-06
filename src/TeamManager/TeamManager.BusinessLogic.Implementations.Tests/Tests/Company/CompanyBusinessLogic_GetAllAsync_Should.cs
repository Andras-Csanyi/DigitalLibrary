namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Tests.Tests.Company
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using FluentAssertions;

    using Xunit;

    [Collection(nameof(AssemblyName.GetAssemblyName))]
    public class CompanyBusinessLogic_GetAllAsync_Should : TestBase
    {
        [Trait("Category", "Unit")]
        public async Task Find()
        {
            // Arrange
            Company first = new Company { Name = "asd", Url = "asd", Description = "asd", IsActive = 1 };
            Company second = new Company { Name = "asd2", Url = "asd2", Description = "asd2", IsActive = 1 };

            Company firstResult = await CompanyBusinessLogic.AddAsync(first).ConfigureAwait(false);
            Company secondResult = await CompanyBusinessLogic.AddAsync(second).ConfigureAwait(false);

            // Act
            List<Company> result = await CompanyBusinessLogic.GetAllAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be(2);
        }
    }
}