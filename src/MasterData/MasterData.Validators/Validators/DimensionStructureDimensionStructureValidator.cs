namespace DigitalLibrary.MasterData.Validators
{
    using DomainModel;

    using FluentValidation;

    public class DimensionStructureDimensionStructureValidator : AbstractValidator<DimensionStructureDimensionStructure>
    {
        public DimensionStructureDimensionStructureValidator()
        {
            RuleSet(DimensionStructureDimensionStructureValidatorRulesets.Add, () =>
            {
                RuleFor(p => p.Id).Equal(0);
                RuleFor(p => p.DimensionStructureId).GreaterThan(0);
            });
        }
    }
}