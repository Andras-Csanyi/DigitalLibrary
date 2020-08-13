// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.Validators
{
    using System.Diagnostics.CodeAnalysis;

    using DomainModel;

    using FluentValidation;

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