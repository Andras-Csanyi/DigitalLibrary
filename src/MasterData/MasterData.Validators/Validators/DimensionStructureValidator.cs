using System.Diagnostics.CodeAnalysis;

using DigitalLibrary.MasterData.DomainModel.DomainModel;

using FluentValidation;

namespace DigitalLibrary.MasterData.Validators.Validators
{
    [ExcludeFromCodeCoverage]
    public class DimensionStructureValidator : AbstractValidator<DimensionStructure>
    {
        public DimensionStructureValidator()
        {
            RuleSet(ValidatorRulesets.AddNewDimensionStructure, () =>
            {
                When(w => w.Name == null || w.Desc == null, () =>
                {
                    RuleFor(e => e.Name).NotNull();
                    RuleFor(e => e.Desc).NotNull();
                });

                When(w => w.Name != null && w.Desc != null, () =>
                {
                    RuleFor(p => p.Id).Equal(0);
                    RuleFor(p => p.Name).NotEmpty().NotEqual(" ");
                    RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.Desc).NotEmpty().NotEqual(" ");
                    RuleFor(p => p.Desc.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                    RuleFor(p => p.ParentDimensionStructureId).NotNull().NotEqual(0);
                });
            });

            RuleSet(ValidatorRulesets.UpdateDimensionStructure, () =>
            {
                When(w => w.Name == null || w.Desc == null, () =>
                {
                    RuleFor(e => e.Name).NotNull();
                    RuleFor(e => e.Desc).NotNull();
                });

                When(w => w.Name != null && w.Desc != null, () =>
                {
                    RuleFor(p => p.Id).NotEqual(0);
                    RuleFor(p => p.Name).NotEmpty().NotEqual(" ");
                    RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.Desc).NotEmpty().NotEqual(" ");
                    RuleFor(p => p.Desc.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                    RuleFor(p => p.ParentDimensionStructureId).NotNull().NotEqual(0);
                });
            });

            RuleSet(ValidatorRulesets.DeleteDimensionStructure, () => { RuleFor(p => p.Id).NotEqual(0); });
        }
    }
}