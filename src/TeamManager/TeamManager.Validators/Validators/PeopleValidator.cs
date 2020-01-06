namespace DigitalLibrary.IaC.TeamManager.Validators.Validators
{
    using DomainModel.Entities;

    using FluentValidation;

    public class PeopleValidator : AbstractValidator<People>
    {
        public PeopleValidator()
        {
            RuleSet(ValidatorRulesets.Add, () =>
            {
                When(p => p.LastName != null, () => { RuleFor(p => p.LastName).NotEmpty().NotEqual(" "); });
                RuleFor(p => p.LastName).NotNull();

                When(p => p.FirstName != null, () => { RuleFor(p => p.FirstName).NotEmpty().NotEqual(" "); });
                RuleFor(p => p.FirstName).NotNull();

                When(p => p.MiddleName != null, () => { RuleFor(p => p.MiddleName).NotEmpty().NotEqual(" "); });
                RuleFor(p => p.MiddleName).NotNull();

                RuleFor(p => p.Id).Equal(0);
                RuleFor(p => p.CompanyId).NotEqual(0);
                RuleFor(p => p.TitleId).NotEqual(0);
                RuleFor(p => p.PositionId).NotEqual(0);

                RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            });

            RuleSet(ValidatorRulesets.Find, () => { RuleFor(p => p.Id).NotEqual(0); });

            RuleSet(ValidatorRulesets.Delete, () => { RuleFor(p => p.Id).NotEqual(0); });

            RuleSet(ValidatorRulesets.Modify, () =>
            {
                When(p => p.LastName != null, () => { RuleFor(p => p.LastName).NotEmpty().NotEqual(string.Empty); });
                RuleFor(p => p.LastName).NotNull();

                When(p => p.FirstName != null, () => { RuleFor(p => p.FirstName).NotEmpty().NotEqual(string.Empty); });
                RuleFor(p => p.FirstName).NotNull();

                RuleFor(p => p.Id).NotEqual(0);
                RuleFor(p => p.CompanyId).NotEqual(0);
                RuleFor(p => p.TitleId).NotEqual(0);
                RuleFor(p => p.PositionId).NotEqual(0);
            });
        }
    }
}