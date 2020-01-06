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
        public async Task<Company> AddAsync(Company newCompany)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    if (newCompany == null)
                    {
                        string msg = "Input cannot be null";
                        throw new CompanyNullInputValueException(msg);
                    }

                    await _companyValidator.ValidateAndThrowAsync(
                            newCompany,
                            ruleSet: ValidatorRulesets.Add)
                        .ConfigureAwait(false);

                    Company newOne = new Company
                    {
                        Name = newCompany.Name,
                        Url = newCompany.Url,
                        Description = newCompany.Description,
                        IsActive = newCompany.IsActive
                    };

                    await _companyValidator.ValidateAndThrowAsync(
                            newOne,
                            ruleSet: ValidatorRulesets.Add)
                        .ConfigureAwait(false);

                    await ctx.Companies.AddAsync(newOne).ConfigureAwait(false);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);

                    return newOne;
                }
                catch (Exception e)
                {
                    throw new CompanyAddOperationException(e.Message, e);
                }
            }
        }
    }
}