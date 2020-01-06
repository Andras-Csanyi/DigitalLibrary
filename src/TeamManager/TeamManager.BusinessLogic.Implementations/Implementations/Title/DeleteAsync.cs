namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Title
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Title;

    using FluentValidation;

    using Validators.Validators;

    public partial class TitleBusinessLogic
    {
        public async Task DeleteAsync(Title titleToBeDeleted)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    if (titleToBeDeleted == null)
                    {
                        string msg = $"Null input: {nameof(TitleBusinessLogic)}.{nameof(DeleteAsync)}";
                        throw new TitleInputValidationException(msg);
                    }

                    await _titleValidator.ValidateAndThrowAsync(titleToBeDeleted,
                        ruleSet: ValidatorRulesets.Delete).ConfigureAwait(false);

                    Title title = await ctx.Titles.FindAsync(titleToBeDeleted.Id).ConfigureAwait(false);

                    if (title == null)
                    {
                        string msg = $"There is no title with id: {titleToBeDeleted.Id}";
                        throw new TitleDoesNotExistException(msg);
                    }

                    ctx.Titles.Remove(title);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new TitleDeleteOperationException(e.Message, e);
                }
            }
        }
    }
}