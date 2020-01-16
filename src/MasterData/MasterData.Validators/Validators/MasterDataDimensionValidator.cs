using System.Diagnostics.CodeAnalysis;
using DigitalLibrary.MasterData.DomainModel.DomainModel;
using FluentValidation;

namespace DigitalLibrary.MasterData.Validators.Validators
{
    [ExcludeFromCodeCoverage]
    public class MasterDataDimensionValidator : AbstractValidator<Dimension>
    {
        public MasterDataDimensionValidator()
        {
            RuleSet(ValidatorRulesets.AddNewDimension, () =>
            {
                When(p => p.Name == null || p.Description == null, () =>
                {
                    RuleFor(p => p.Name).NotNull();
                    RuleFor(p => p.Description).NotNull();
                });

                When(p => p.Name != null && p.Description != null, () =>
                {
                    RuleFor(p => p.Id).Equal(0);
                    RuleFor(p => p.Name).NotEmpty().NotNull().NotEqual(" ");
                    RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.Description).NotEmpty().NotNull().NotEqual(" ");
                    RuleFor(p => p.Description.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                });
            });

            RuleSet(ValidatorRulesets.ModifyDimension, () =>
            {
                When(p => p.Name == null || p.Description == null, () =>
                {
                    RuleFor(p => p.Name).NotNull();
                    RuleFor(p => p.Description).NotNull();
                });

                When(p => p.Name != null && p.Description != null, () =>
                {
                    RuleFor(p => p.Name).NotEmpty().NotNull().NotEqual(" ");
                    RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.Description).NotEmpty().NotNull().NotEqual(" ");
                    RuleFor(p => p.Description.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                });
            });
        }
    }
}