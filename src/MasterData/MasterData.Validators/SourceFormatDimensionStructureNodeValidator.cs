namespace DigitalLibrary.MasterData.Validators
{
    using DigitalLibrary.MasterData.DomainModel;

    using FluentValidation;

    public class SourceFormatDimensionStructureNodeValidator
        : AbstractValidator<SourceFormatDimensionStructureNode>
    {
        public SourceFormatDimensionStructureNodeValidator()
        {
            RuleSet(SourceFormatDimensionStructureNodeValidatorRulesets.Add, () => { RuleFor(o => o.Id).Equal(0); });
        }
    }
}