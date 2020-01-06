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
        public async Task<Position> FindAsync(Position position)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    await _positionValidator.ValidateAndThrowAsync(position,
                            ruleSet: ValidatorRulesets.Find)
                        .ConfigureAwait(false);

                    return await ctx.Positions.FindAsync(position.Id).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new PositionFindOperationException(e.Message, e);
                }
            }
        }
    }
}