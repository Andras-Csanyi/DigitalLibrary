namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Position
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Position;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore.Storage;

    using Validators.Validators;

    public partial class PositionBusinessLogic
    {
        public async Task<Position> ModifyAsync(Position position)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        await _positionValidator.ValidateAndThrowAsync(position,
                                ruleSet: ValidatorRulesets.Modify)
                            .ConfigureAwait(false);

                        Position toBeModified = await ctx.Positions.FindAsync(position.Id);

                        if (toBeModified == null)
                        {
                            string msg = $"There is no Position with id: {position.Id}";
                            throw new PositionDoesNotExistsException(msg);
                        }

                        toBeModified.Name = position.Name;
                        toBeModified.IsActive = position.IsActive;

                        await _positionValidator.ValidateAndThrowAsync(toBeModified,
                                ruleSet: ValidatorRulesets.Modify)
                            .ConfigureAwait(false);

                        transaction.Commit();

                        return toBeModified;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new PositionModifyOperationException(e.Message, e);
                    }
                }
            }
        }
    }
}