namespace DigitalLibrary.MasterData.Validators
{
    using DigitalLibrary.MasterData.DomainModel;

    using FluentValidation;

    /// <summary>
    /// Validator rules for <see cref="SourceFormatDimensionStructureNode"/> object.
    /// </summary>
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
                When(o => o.SourceFormatId >= 0, () =>
                {
                    RuleFor(p => p.SourceFormat).NotNull();
                    RuleFor(p => p.SourceFormat.Id == p.SourceFormatId).Equal(true);
                });
                When(o => o.DimensionStructureNodeId >= 0, () =>
                {
                    RuleFor(p => p.DimensionStructureNode).NotNull();
                    RuleFor(p => p.DimensionStructureNode.Id == p.DimensionStructureNodeId).Equal(true);
                });
            });
            RuleSet(SourceFormatDimensionStructureNodeValidatorRulesets.Update,
                () => { RuleFor(o => o.Id).NotEqual(0); });
            RuleSet(SourceFormatDimensionStructureNodeValidatorRulesets.Delete, () =>
            {
                RuleFor(o => o.Id).NotEqual(0)
                    ;
            });
        }
    }
}