namespace DigitalLibrary.IaC.TeamManager.Validators.Validators
{
    using DomainModel.Entities;

    using FluentValidation;

    public class PeopleEventLogValidator : AbstractValidator<PeopleEventLog>
    {
        public PeopleEventLogValidator()
        {
            RuleSet(ValidatorRulesets.Add, () =>
            {
                When(p => p.Details != null, () => { RuleFor(q => q.Details).NotEmpty().NotEqual(string.Empty); });
                RuleFor(p => p.Details).NotNull();
                RuleFor(p => p.Id).Equal(0);
                RuleFor(p => p.EventId).NotEqual(0);
                RuleFor(p => p.PeopleId).NotEqual(0);
                RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            });

            RuleSet(ValidatorRulesets.Delete, () => { RuleFor(p => p.Id).GreaterThan(0); });

            RuleSet(ValidatorRulesets.Modify, () =>
            {
                When(p => p.Details != null, () => { RuleFor(q => q.Details).NotEmpty().NotEqual(string.Empty); });
                RuleFor(q => q.Details).NotNull();
                RuleFor(q => q.Id).GreaterThan(0);
                RuleFor(q => q.EventId).GreaterThan(0);
                RuleFor(q => q.PeopleId).GreaterThan(0);
                RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            });
        }
    }
}