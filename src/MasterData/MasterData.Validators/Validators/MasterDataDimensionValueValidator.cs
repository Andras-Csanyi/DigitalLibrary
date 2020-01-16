using System.Diagnostics.CodeAnalysis;
using DigitalLibrary.MasterData.DomainModel.DomainModel;
using FluentValidation;

namespace DigitalLibrary.MasterData.Validators.Validators
{
    [ExcludeFromCodeCoverage]
    public class MasterDataDimensionValueValidator : AbstractValidator<DimensionValue>
    {
        public MasterDataDimensionValueValidator()
        {
            RuleSet(ValidatorRulesets.AddNewDimensionValue, () => { RuleFor(v => v.Id).Equals(0); });

            RuleSet(ValidatorRulesets.ModifyDimensionValue, () => { RuleFor(v => v.Id).NotEqual(0); });
        }
    }
}