namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.DimensionStructure
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Test cases covering operations on <see cref="DimensionStructure"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "CA1707", Justification = "Reviewed.")]
    [SuppressMessage("ReSharper", "SA1600", Justification = "Reviewed.")]
    public partial class DimensionStructureFeature : MasterDataBusinessLogicFeature
    {
        public DimensionStructureFeature()
            : base(nameof(DimensionStructureFeature))
        {
        }
    }
}