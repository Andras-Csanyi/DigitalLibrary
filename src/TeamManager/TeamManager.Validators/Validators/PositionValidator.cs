namespace DigitalLibrary.IaC.TeamManager.Validators.Validators
{
    using DomainModel.Entities;

    using FluentValidation;

    public class PositionValidator : AbstractValidator<Position>
    {
        public PositionValidator()
        {
            RuleSet(ValidatorRulesets.Add, () =>
            {
                When(p => p.Name != null, () => { RuleFor(p => p.Name).NotEmpty().NotEqual(string.Empty); });
                RuleFor(p => p.Name).NotNull();
                RuleFor(p => p.Id).Equal(0);
                RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            });

            RuleSet(ValidatorRulesets.Find, () => { });

            RuleSet(ValidatorRulesets.Delete, () => { RuleFor(p => p.Id).NotEqual(0); });

            RuleSet(ValidatorRulesets.Modify, () => { });
        }
    }
}