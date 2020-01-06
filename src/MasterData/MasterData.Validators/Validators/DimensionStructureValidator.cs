namespace DigitalLibrary.IaC.MasterData.Validators.Validators
{
    using System.Diagnostics.CodeAnalysis;

    using DomainModel.DomainModel;

    using FluentValidation;

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
                    RuleFor(p => p.ParentDimensionStructureId).Null();
                });
            });

            RuleSet(ValidatorRulesets.AddNewTopDimensionStructure, () =>
            {
                When(w => w.Name == null || w.Desc == null, () =>
                {
                    RuleFor(e => e.Name).NotNull();
                    RuleFor(e => e.Desc).NotNull();
                });

                When(w => w.Name != null && w.Desc != null, () =>
                {
                    RuleFor(p => p.Id).Equal(0);
                    // RuleFor(p => p.ParentDimensionStructureId).Equal(0);
                    RuleFor(p => p.Name).NotEmpty().NotEqual(" ");
                    RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.Desc).NotEmpty().NotEqual(" ");
                    RuleFor(p => p.Desc.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                });
            });

            RuleSet(ValidatorRulesets.UpdateTopDimensionStructure, () =>
            {
                When(w => w.Name == null || w.Desc == null, () =>
                {
                    RuleFor(e => e.Name).NotNull();
                    RuleFor(e => e.Desc).NotNull();
                });
                When(w => w.Name != null && w.Desc != null, () =>
                {
                    RuleFor(p => p.Id).GreaterThan(0);
                    // RuleFor(p => p.ParentDimensionStructureId).Equal(0);
                    RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.Name).NotNull().NotEmpty().NotEqual(" ");
                    RuleFor(p => p.Desc.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.Desc).NotEmpty().NotEqual(" ");
                    RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                });
            });
        }
    }
}