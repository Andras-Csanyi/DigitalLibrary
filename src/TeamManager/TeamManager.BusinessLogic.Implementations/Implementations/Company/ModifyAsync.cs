namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Company
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Company;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    using Validators.Validators;

    public partial class CompanyBusinessLogic
    {
        public async Task<Company> ModifyAsync(Company modifiedCompany)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        if (modifiedCompany == null)
                        {
                            string msg = $"Null input: {nameof(CompanyBusinessLogic)}.{nameof(ModifyAsync)}";
                            throw new CompanyNullInputValueException();
                        }

                        await _companyValidator
                            .ValidateAndThrowAsync(modifiedCompany, ruleSet: ValidatorRulesets.Modify)
                            .ConfigureAwait(false);

                        Company companyToBeModified = await ctx.Companies.FindAsync(modifiedCompany.Id)
                            .ConfigureAwait(false);

                        if (companyToBeModified == null)
                        {
                            string msg = $"Company does not exist with id: {modifiedCompany.Id}";
                            throw new CompanyDoesNotExistException(msg);
                        }

                        companyToBeModified.Url = modifiedCompany.Url;
                        companyToBeModified.Description = modifiedCompany.Description;
                        companyToBeModified.Name = modifiedCompany.Name;
                        companyToBeModified.IsActive = modifiedCompany.IsActive;

                        ctx.Entry(companyToBeModified).State = EntityState.Modified;
                        await ctx.SaveChangesAsync().ConfigureAwait(true);

                        transaction.Commit();

                        return companyToBeModified;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();

                        throw new CompanyModifyOperationException(e.Message, e);
                    }
                }
            }
        }
    }
}