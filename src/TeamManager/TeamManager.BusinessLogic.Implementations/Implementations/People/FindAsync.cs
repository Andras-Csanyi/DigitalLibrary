namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.People
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.People;

    using FluentValidation;

    using Validators.Validators;

    public partial class PeopleBusinessLogic
    {
        public async Task<People> FindAsync(People people)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    await _peopleValidator.ValidateAndThrowAsync(people, ruleSet: ValidatorRulesets.Find)
                        .ConfigureAwait(false);

                    return await ctx.Peoples.FindAsync(people.Id).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new PeopleFindOperationException(e.Message, e);
                }
            }
        }
    }
}