namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Company
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Company;

    using FluentValidation;

    using Validators.Validators;

    public partial class CompanyBusinessLogic
    {
        public async Task DeleteAsync(Company company)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    if (company == null)
                    {
                        string msg = $"Null input: {nameof(CompanyBusinessLogic)}.{nameof(DeleteAsync)}";
                        throw new CompanyNullInputValueException(msg);
                    }

                    await _companyValidator.ValidateAndThrowAsync(
                            company,
                            ruleSet: ValidatorRulesets.Delete)
                        .ConfigureAwait(false);

                    ctx.Companies.Remove(company);
                    await ctx.SaveChangesAsync().ConfigureAwait(true);
                }
                catch (Exception e)
                {
                    throw new CompanyDeleteOperationException(e.Message, e);
                }
            }
        }
    }
}