namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Position
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Position;

    using FluentValidation;

    using Validators.Validators;

    public partial class PositionBusinessLogic
    {
        public async Task DeleteAsync(Position position)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    await _positionValidator.ValidateAndThrowAsync(position,
                            ruleSet: ValidatorRulesets.Delete)
                        .ConfigureAwait(false);

                    ctx.Positions.Remove(position);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new PositionDeleteOperationException(e.Message, e);
                }
            }
        }
    }
}