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
        public async Task<Company> FindAsync(Company company)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    await _companyValidator.ValidateAndThrowAsync(
                            company,
                            ruleSet: ValidatorRulesets.Find)
                        .ConfigureAwait(false);

                    return await ctx.Companies.FindAsync(company.Id).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new CompanyFindOperationException(e.Message, e);
                }
            }
        }
    }
}