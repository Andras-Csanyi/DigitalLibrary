namespace DigitalLibrary.MasterData.Validators
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentValidation;

    [ExcludeFromCodeCoverage]
    public class DimensionStructureNodeValidator : AbstractValidator<DimensionStructureNode>
    {
        public DimensionStructureNodeValidator()
        {
            RuleSet(DimensionStructureNodeValidatorRulesets.Add, () => { RuleFor(r => r.Id).Equal(0); });
        }
    }
}
