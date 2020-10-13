namespace DigitalLibrary.Utils.MasterDataTestHelper
{
    using System;

    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    /// <inheritdoc />
    public class MasterDataTestHelper : IMasterDataTestHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasterDataTestHelper"/> class.
        /// </summary>
        /// <param name="sourceFormatFactory">SourceFormatFactory.</param>
        /// <param name="dimensionStructureFactory">DimensionStructureFactory.</param>
        public MasterDataTestHelper(
            ISourceFormatFactory sourceFormatFactory,
            IDimensionStructureFactory dimensionStructureFactory)
        {
            SourceFormatFactory = sourceFormatFactory ?? throw new ArgumentNullException(
                $"{nameof(sourceFormatFactory)}");
            DimensionStructureFactory = dimensionStructureFactory ?? throw new ArgumentNullException(
                $"{nameof(dimensionStructureFactory)}");
        }

        /// <inheritdoc/>
        public IDimensionStructureFactory DimensionStructureFactory { get; }

        /// <inheritdoc/>
        public ISourceFormatFactory SourceFormatFactory { get; }
    }
}