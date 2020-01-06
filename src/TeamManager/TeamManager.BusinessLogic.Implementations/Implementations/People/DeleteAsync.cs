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
        public async Task DeleteAsync(People people)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    await _peopleValidator.ValidateAndThrowAsync(
                        people,
                        ruleSet: ValidatorRulesets.Delete);
                    ctx.Peoples.Remove(people);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new PeopleDeleteOperationException(e.Message, e);
                }
            }
        }
    }
}