namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionValue
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Tests covering <see cref="DimensionValue"/> related operations.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public partial class DimensionValueFeature : MasterDataBusinessLogicFeature
    {
        public DimensionValueFeature()
            : base(nameof(DimensionValueFeature))
        {
        }
    }
}