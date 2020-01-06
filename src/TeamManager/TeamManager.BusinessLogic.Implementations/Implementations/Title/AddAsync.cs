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
        public async Task<Title> AddAsync(Title newTitle)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    if (newTitle == null)
                    {
                        string msg = "Input is null";
                        throw new TitleInputValidationException(msg);
                    }

                    await _titleValidator.ValidateAndThrowAsync(newTitle,
                        ruleSet: ValidatorRulesets.Add).ConfigureAwait(false);

                    await ctx.Titles.AddAsync(newTitle).ConfigureAwait(false);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);

                    return newTitle;
                }
                catch (Exception e)
                {
                    throw new TitleAddNewOperationException(e.Message, e);
                }
            }
        }
    }
}