namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Dimension
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Test cases covering <see cref="Dimension"/> related operations.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public partial class DimensionFeature : MasterDataBusinessLogicFeature
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DimensionFeature"/> class.
        /// </summary>
        public DimensionFeature()
            : base(nameof(DimensionFeature))
        {
        }
    }
}