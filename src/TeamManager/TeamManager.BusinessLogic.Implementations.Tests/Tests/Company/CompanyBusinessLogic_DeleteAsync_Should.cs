namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Tests.Tests.Company
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Company;

    using FluentAssertions;

    using FluentValidation;

    using Xunit;

    [Collection(nameof(AssemblyName.GetAssemblyName))]
    public partial class CompanyBusinessLogic_DeleteAsync_Should : TestBase
    {
        public static IEnumerable<object[]> ThrowCompanyDeleteOperationExceptionWhenInputIsInvalid = new List<object[]>
        {
            new object[] { 0, "asd", "asd", "asd", 1 },
        };

        [Trait("Category", "Unit")]
        public async Task Throw_CompanyDeleteOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () => { await CompanyBusinessLogic.DeleteAsync(null); };

            // Assert
            action.Should().ThrowExactly<CompanyDeleteOperationException>()
                .WithInnerException<CompanyNullInputValueException>();
        }

        [Trait("Category", "Unit")]
        [MemberData(nameof(ThrowCompanyDeleteOperationExceptionWhenInputIsInvalid))]
        public async Task Throw_CompanyDeleteOperationException_WhenInputIsInvalid(
            long id,
            string name,
            string desc,
            string url,
            int isActive)
        {
            // Arrange
            Company company = new Company
            {
                Id = id,
                Name = name,
                Description = desc,
                Url = url,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () => { await CompanyBusinessLogic.DeleteAsync(company).ConfigureAwait(false); };

            // Assert
            action.Should().ThrowExactly<CompanyDeleteOperationException>()
                .WithInnerExceptionExactly<ValidationException>();
        }

        [Trait("Category", "Unit")]
        public async Task Delete_TheItem()
        {
            // Arrange
            Company company = new Company
            {
                Name = "name",
                Url = "url",
                Description = "desc",
                IsActive = 1
            };
            Company result = await CompanyBusinessLogic.AddAsync(company).ConfigureAwait(false);

            Company delete = new Company { Id = result.Id };

            // Act
            await CompanyBusinessLogic.DeleteAsync(delete).ConfigureAwait(false);
            List<Company> afterDelete = await CompanyBusinessLogic.GetAllAsync().ConfigureAwait(false);

            // Assert
            afterDelete.Count.Should().Be(0);
        }
    }
}