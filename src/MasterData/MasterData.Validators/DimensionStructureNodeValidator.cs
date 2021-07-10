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
            RuleSet(SourceFormatValidatorRulesets.CreateDimensionStructureNode, () =>
            {
                RuleFor(r => r.Id).Equal(0);
                RuleFor(r => r.IsActive)
                   .GreaterThanOrEqualTo(0)
                   .LessThanOrEqualTo(1);
            });
        }
    }
}
