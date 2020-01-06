namespace DigitalLibrary.IaC.TeamManager.Validators.Validators
{
    using DomainModel.Entities;

    using FluentValidation;

    public class TitleValidator : AbstractValidator<Title>
    {
        public TitleValidator()
        {
            RuleSet(ValidatorRulesets.Add, () =>
            {
                When(p => p.Name == null, () => { RuleFor(q => q.Name).NotNull(); });
                RuleFor(q => q.Name).NotEmpty().NotEqual(string.Empty);
                RuleFor(q => q.Id).Equal(0);
                RuleFor(q => q.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            });

            RuleSet(ValidatorRulesets.Find, () => { RuleFor(q => q.Id).NotEqual(0); });

            RuleSet(ValidatorRulesets.Delete, () => { RuleFor(q => q.Id).NotEqual(0); });

            RuleSet(ValidatorRulesets.Modify, () => { });
        }
    }
}