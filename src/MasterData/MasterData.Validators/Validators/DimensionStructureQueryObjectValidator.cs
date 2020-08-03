namespace DigitalLibrary.MasterData.Validators
{
    using BusinessLogic.ViewModels;

    using FluentValidation;

    public class DimensionStructureQueryObjectValidator : AbstractValidator<DimensionStructureQueryObject>
    {
        public DimensionStructureQueryObjectValidator()
        {
            RuleSet(DimensionStructureQueryObjectValidatorRulesets.GetDimensionStructureByIdOperation,
                () => { RuleFor(r => r.GetDimensionsStructuredById).NotEqual(0); });
        }
    }
}