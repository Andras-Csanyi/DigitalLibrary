namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Title
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Title;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    using Validators.Validators;

    public partial class TitleBusinessLogic
    {
        public async Task<Title> ModifyAsync(Title modifiedTitle)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    if (modifiedTitle == null)
                    {
                        string msg = $"Null input: {nameof(TitleBusinessLogic)}.{nameof(ModifyAsync)}";
                        throw new TitleInputValidationException(msg);
                    }

                    await _titleValidator.ValidateAndThrowAsync(modifiedTitle,
                        ruleSet: ValidatorRulesets.Modify).ConfigureAwait(false);

                    Title title = await ctx.Titles.FindAsync(modifiedTitle.Id).ConfigureAwait(false);

                    if (title == null)
                    {
                        string msg = $"There is no title with id: {modifiedTitle.Id}";
                        throw new TitleDoesNotExistException(msg);
                    }

                    title.Name = modifiedTitle.Name;
                    title.IsActive = modifiedTitle.IsActive;

                    ctx.Entry(title).State = EntityState.Modified;
                    await ctx.SaveChangesAsync().ConfigureAwait(false);

                    return title;
                }
                catch (Exception e)
                {
                    throw new TitleModifyOperationException(e.Message, e);
                }
            }
        }
    }
}