namespace DigitalLibrary.IaC.TeamManager.Validators.Validators
{
    using DomainModel.Entities;

    using FluentValidation;

    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleSet(ValidatorRulesets.Add, () =>
            {
                When(p => p.Name == null, () => { RuleFor(p => p.Name).NotNull(); });
                When(p => p.Description == null, () => { RuleFor(p => p.Description).NotNull(); });
                When(p => p.Url == null, () => { RuleFor(p => p.Url).NotNull(); });

                RuleFor(p => p.Id).Equal(0);
                RuleFor(p => p.Name).NotEmpty().NotEqual(" ");
                RuleFor(p => p.Description).NotEmpty().NotEqual(" ");
                RuleFor(p => p.Url).NotEmpty().NotEqual(" ");
            });

            RuleSet(ValidatorRulesets.Delete, () => { RuleFor(p => p.Id).GreaterThan(0); });

            RuleSet(ValidatorRulesets.Modify, () =>
            {
                When(p => p.Name == null, () => { RuleFor(p => p.Name).NotNull(); });
                When(p => p.Description == null, () => { RuleFor(p => p.Description).NotNull(); });
                When(p => p.Url == null, () => { RuleFor(p => p.Url).NotNull(); });

                RuleFor(p => p.Id).NotEqual(0);
                RuleFor(p => p.Name).NotEmpty().NotEqual(" ");
                RuleFor(p => p.Description).NotEmpty().NotEqual(" ");
                RuleFor(p => p.Url).NotEmpty().NotEqual(" ");
            });

            RuleSet(ValidatorRulesets.Find, () => { RuleFor(p => p.Id).GreaterThan(0); });
        }
    }
}