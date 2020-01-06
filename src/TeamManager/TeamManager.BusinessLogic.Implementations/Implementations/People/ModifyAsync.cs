namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.People
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.People;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    using Validators.Validators;

    public partial class PeopleBusinessLogic
    {
        public async Task<People> ModifyAsync(People people)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        await _peopleValidator.ValidateAndThrowAsync(people,
                                ruleSet: ValidatorRulesets.Modify)
                            .ConfigureAwait(false);

                        People toBeModified = await ctx.Peoples.FindAsync(people.Id).ConfigureAwait(false);

                        if (toBeModified == null)
                        {
                            string msg = $"There is no TeamManager.Integration.Tests entity with id: {people.Id}";
                            throw new PeopleDoesNotExistException(msg);
                        }

                        toBeModified.TitleId = people.TitleId;
                        toBeModified.IsActive = people.IsActive;
                        toBeModified.LastName = people.LastName;
                        toBeModified.CompanyId = people.CompanyId;
                        toBeModified.FirstName = people.FirstName;
                        toBeModified.PositionId = people.PositionId;
                        toBeModified.MiddleName = people.MiddleName;

                        await _peopleValidator.ValidateAndThrowAsync(toBeModified,
                                ruleSet: ValidatorRulesets.Modify)
                            .ConfigureAwait(false);

                        ctx.Entry(toBeModified).State = EntityState.Modified;
                        await ctx.SaveChangesAsync().ConfigureAwait(false);

                        transaction.Commit();

                        return toBeModified;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new PeopleModifyOperationException(e.Message, e);
                    }
                }
            }
        }
    }
}