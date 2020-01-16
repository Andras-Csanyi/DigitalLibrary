using DigitalLibrary.ControlPanel.DomainModel.Entities;
using FluentValidation;

namespace DigitalLibrary.ControlPanel.Validators.Validators
{
    public class ModuleValidator : AbstractValidator<Module>
    {
        public ModuleValidator()
        {
            RuleSet(ValidatorRulesets.AddNew, () =>
            {
                When(p => p.Name == null, () => { RuleFor(p => p.Name).NotNull(); });
                RuleFor(p => p.Name).NotEmpty().NotEqual(" ");

                When(p => p.ModuleRoute == null, () => { RuleFor(p => p.ModuleRoute).NotNull(); });
                RuleFor(p => p.ModuleRoute).NotEmpty().NotEqual(" ");

                When(p => p.Description == null, () => { RuleFor(p => p.Description).NotNull(); });
                RuleFor(p => p.Description).NotEmpty().NotEqual(" ");

                RuleFor(p => p.Id).Equal(0);
                RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            });

            RuleSet(ValidatorRulesets.Delete, () => { RuleFor(p => p.Id).NotEqual(0); });

            RuleSet(ValidatorRulesets.Modify, () =>
            {
                When(p => p.Name == null, () => { RuleFor(p => p.Name).NotNull(); });
                RuleFor(p => p.Name).NotEmpty().NotEqual(" ");

                When(p => p.ModuleRoute == null, () => { RuleFor(p => p.ModuleRoute).NotNull(); });
                RuleFor(p => p.ModuleRoute).NotEmpty().NotEqual(" ");

                When(p => p.Description == null, () => { RuleFor(p => p.Description).NotNull(); });
                RuleFor(p => p.Description).NotEmpty().NotEqual(" ");

                RuleFor(p => p.Id).NotEqual(0);
                RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            });
        }
    }
}