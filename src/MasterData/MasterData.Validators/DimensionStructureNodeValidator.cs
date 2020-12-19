namespace DigitalLibrary.MasterData.Validators
{
    using DigitalLibrary.MasterData.DomainModel;

    using FluentValidation;

    public class DimensionStructureNodeValidator : AbstractValidator<DimensionStructureNode>
    {
        public DimensionStructureNodeValidator()
        {
            RuleSet(DimensionStructureNodeValidatorRulesets.Add, () => { RuleFor(r => r.Id).Equal(0); });
        }
    }
}