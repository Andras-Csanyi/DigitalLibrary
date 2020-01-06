namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.People
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.People;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore.Storage;

    using Validators.Validators;

    public partial class PeopleBusinessLogic
    {
        public async Task<People> AddAsync(People people)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        await _peopleValidator.ValidateAndThrowAsync(
                                people,
                                ruleSet: ValidatorRulesets.Add)
                            .ConfigureAwait(false);

                        await ctx.Peoples.AddAsync(people).ConfigureAwait(false);
                        await ctx.SaveChangesAsync().ConfigureAwait(false);

                        transaction.Commit();

                        return people;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();

                        throw new PeopleAddOperationException(e.Message, e);
                    }
                }
            }
        }
    }
}