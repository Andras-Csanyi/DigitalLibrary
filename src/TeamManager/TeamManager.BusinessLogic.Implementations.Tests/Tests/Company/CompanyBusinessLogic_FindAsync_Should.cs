namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Tests.Tests.Company
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Company;

    using FluentAssertions;

    using FluentValidation;

    using Xunit;

    [Collection(nameof(AssemblyName.GetAssemblyName))]
    public class CompanyBusinessLogic_FindAsync_Should : TestBase
    {
        [Trait("Category", "Unit")]
        public async Task ThrowException_WhenInputIsInvalid()
        {
            // Arrange

            // Act
            Company company = new Company { Id = 0 };
            Func<Task> action = async () => { await CompanyBusinessLogic.FindAsync(company); };

            // Assert
            action.Should().ThrowExactly<CompanyFindOperationException>()
                .WithInnerException<ValidationException>();
        }

        [Trait("Category", "Unit")]
        public async Task Find()
        {
            // Arrange
            Company first = new Company { Name = "asd", Url = "asd", Description = "asd", IsActive = 1 };
            Company second = new Company { Name = "asd2", Url = "asd2", Description = "asd2", IsActive = 1 };

            Company firstResult = await CompanyBusinessLogic.AddAsync(first).ConfigureAwait(false);
            Company secondResult = await CompanyBusinessLogic.AddAsync(second).ConfigureAwait(false);

            // Act
            Company firstHit = await CompanyBusinessLogic.FindAsync(firstResult).ConfigureAwait(false);

            // Assert
            firstHit.Id.Should().NotBe(0);
            firstHit.Name.Should().Be(firstResult.Name);
            firstHit.Description.Should().Be(firstResult.Description);
            firstHit.Url.Should().Be(firstResult.Url);
            firstHit.IsActive.Should().Be(firstResult.IsActive);
        }
    }
}