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
    public class CompanyBusinessLogic_ModifyAsync_Should : TestBase
    {
        public static IEnumerable<object[]> ThrowCompanyModifyOperationException = new List<object[]>
        {
            new object[] { 0, "asd", "asd", "asd", 1 },

            new object[] { 1, null, "asd", "asd", 1 },
            new object[] { 1, string.Empty, "asd", "asd", 1 },
            new object[] { 1, " ", "asd", "asd", 1 },

            new object[] { 1, "asd", null, "asd", 1 },
            new object[] { 1, "asd", string.Empty, "asd", 1 },
            new object[] { 1, "asd", " ", "asd", 1 },

            new object[] { 1, "asd", "asd", null, 1 },
            new object[] { 1, "asd", "asd", string.Empty, 1 },
            new object[] { 1, "asd", "asd", " ", 1 },

            new object[] { 1, "asd", "asd", " ", 2 },
        };

        public static IEnumerable<object[]> ModifyValues = new List<object[]>
        {
            new object[] { "asd", "orig", "orig", 1 },
            new object[] { "orig", "asd", "orig", 0 },
            new object[] { "orig", "orig", "asd", 1 },
            new object[] { "asd", "orig", "asd", 0 },
            new object[] { "asd", "asd", "asd", 0 },
        };

        [Trait("Category", "Unit")]
        public async Task Throw_CompanyModifyOperationException_WhenInputIsNull()
        {
            // Arrange

            // Assert
            Func<Task> action = async () => { await CompanyBusinessLogic.ModifyAsync(null); };

            // Assert
            action.Should().ThrowExactly<CompanyModifyOperationException>()
                .WithInnerException<CompanyNullInputValueException>();
        }

        [Trait("Category", "Unit")]
        [MemberData(nameof(ThrowCompanyModifyOperationException))]
        public async Task Throw_CompanyModifyOperationException_WhenInputIsInvalid(
            int id,
            string name,
            string desc,
            string url,
            int isActive)
        {
            // Arrange
            Company modified = new Company
            {
                Id = id,
                Name = name,
                Description = desc,
                Url = url,
                IsActive = isActive
            };

            // Act
            Func<Task> action = async () => { await CompanyBusinessLogic.ModifyAsync(modified); };

            // Assert
            action.Should().ThrowExactly<CompanyModifyOperationException>()
                .WithInnerException<ValidationException>();
        }

        [Trait("Category", "Unit")]
        [MemberData(nameof(ModifyValues))]
        public async Task Modify_Values(
            string name,
            string desc,
            string url,
            int isActive)
        {
            // Arrange
            Company start = new Company
            {
                Name = "orig",
                Url = "orig",
                Description = "orig",
                IsActive = 1
            };
            Company orig = await CompanyBusinessLogic.AddAsync(start).ConfigureAwait(false);

            Company modified = new Company
            {
                Id = orig.Id,
                Name = name,
                Description = desc,
                Url = url,
                IsActive = isActive
            };

            // Act
            Company result = await CompanyBusinessLogic.ModifyAsync(modified);

            // Assert
            result.Id.Should().Be(orig.Id);
            result.Name.Should().Be(name);
            result.Description.Should().Be(desc);
            result.Url.Should().Be(url);
            result.IsActive.Should().Be(isActive);
        }
    }
}