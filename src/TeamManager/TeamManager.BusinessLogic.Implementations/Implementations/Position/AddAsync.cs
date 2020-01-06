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
        public async Task<Position> AddAsync(Position position)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    await _positionValidator.ValidateAndThrowAsync(position,
                            ruleSet: ValidatorRulesets.Add)
                        .ConfigureAwait(false);

                    await ctx.Positions.AddAsync(position).ConfigureAwait(false);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);

                    return position;
                }
                catch (Exception e)
                {
                    throw new PositionAddOperationException(e.Message, e);
                }
            }
        }
    }
}