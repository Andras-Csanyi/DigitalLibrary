namespace DigitalLibrary.MasterData.Validators
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentValidation;

    /// <summary>
    /// Validator rules for <see cref="SourceFormatDimensionStructureNode"/> object.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SourceFormatDimensionStructureNodeValidator
        : AbstractValidator<SourceFormatDimensionStructureNode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceFormatDimensionStructureNodeValidator"/> class.
        /// </summary>
        public SourceFormatDimensionStructureNodeValidator()
        {
            RuleSet(SourceFormatDimensionStructureNodeValidatorRulesets.Add, () =>
            {
                RuleFor(o => o.Id).Equal(0);
                RuleFor(o => o.SourceFormatId).NotEqual(0);
                RuleFor(o => o.DimensionStructureNodeId).NotEqual(0);
            });
            RuleSet(SourceFormatDimensionStructureNodeValidatorRulesets.Update, () =>
            {
                RuleFor(o => o.Id).NotEqual(0);
                RuleFor(o => o.SourceFormatId).NotEqual(0);
                RuleFor(o => o.DimensionStructureNodeId).NotEqual(0);
            });
            RuleSet(SourceFormatDimensionStructureNodeValidatorRulesets.Delete,
                () => { RuleFor(o => o.Id).NotNull().NotEqual(0); });
        }
    }
}