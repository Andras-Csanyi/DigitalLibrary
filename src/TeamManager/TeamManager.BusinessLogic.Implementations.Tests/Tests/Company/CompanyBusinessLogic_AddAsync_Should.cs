namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Tests.Tests.Company
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Company;

    using FluentAssertions;

    using Xunit;

    [Collection(nameof(AssemblyName.GetAssemblyName))]
    public class CompanyBusinessLogic_AddAsync_Should : TestBase
    {
        public static IEnumerable<object[]> ThrowCompanyAddOperationExceptionWhenValidationFails =>
            new List<object[]>
            {
                new object[] { null, 0, "url", "desc" },
                new object[] { string.Empty, 0, "url", "desc" },
                new object[] { " ", 0, "url", "desc" },

                new object[] { "name", 1, "url", "desc" },

                new object[] { "name", 0, null, "desc" },
                new object[] { "name", 0, string.Empty, "desc" },
                new object[] { "name", 0, " ", "desc" },

                new object[] { "name", 0, "url", null },
                new object[] { "name", 0, "url", string.Empty },
                new object[] { "name", 0, "url", " " },
            };

        [Trait("Category", "Unit")]
        public async Task Throw_CompanyAddOperationException_WhenInputIsNull()
        {
            // Arrange

            // Act
            Func<Task> action = async () => { await CompanyBusinessLogic.AddAsync(null); };

            // Assert
            action.Should().ThrowExactly<CompanyAddOperationException>();
        }

        [Trait("Category", "Unit")]
        [MemberData(nameof(ThrowCompanyAddOperationExceptionWhenValidationFails))]
        public async Task Throw_CompanyAddOperationException_WhenValidationFails(
            string name,
            int id,
            string url,
            string desc)
        {
            // Arrange
            Company toBeAdd = new Company
            {
                Name = name,
                Id = id,
                Url = url,
                Description = desc
            };

            // Act
            Func<Task> action = async () => { await CompanyBusinessLogic.AddAsync(toBeAdd); };

            // Assert
            action.Should().ThrowExactly<CompanyAddOperationException>();
        }

        [Trait("Category", "Unit")]
        public async Task AddAsyncMethod_AddNewCompany_AndReturnResult()
        {
            // Arrange
            Company newCompany = new Company
            {
                Name = "newco",
                Url = "url",
                Description = "desc",
            };

            // Act
            Company result = await CompanyBusinessLogic.AddAsync(newCompany).ConfigureAwait(false);

            // Assert
            result.Id.Should().NotBe(0);
            result.Name.Should().Be(newCompany.Name);
            result.Url.Should().Be(newCompany.Url);
            result.Description.Should().Be(newCompany.Description);
        }
    }
}