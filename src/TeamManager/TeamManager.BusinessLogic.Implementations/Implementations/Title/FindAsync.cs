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
        public async Task<Title> FindAsync(Title title)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    if (title == null)
                    {
                        string msg = $"There is no title with Id: {nameof(title.Id)}";
                        throw new TitleDoesNotExistException(msg);
                    }

                    await _titleValidator.ValidateAndThrowAsync(title,
                        ruleSet: ValidatorRulesets.Find).ConfigureAwait(false);

                    return await ctx.Titles.FindAsync(title.Id).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new TitleFindOperationException(e.Message, e);
                }
            }
        }
    }
}