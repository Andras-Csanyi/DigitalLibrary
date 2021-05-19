namespace DigitalLibrary.Utils.MasterDataTestHelper
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public class MasterDataTestHelper : IMasterDataTestHelper
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MasterDataTestHelper"/> class.
        /// </summary>
        /// <param name="sourceFormatFactory"> SourceFormatFactory. </param>
        /// <param name="dimensionStructureFactory"> DimensionStructureFactory. </param>
        public MasterDataTestHelper(
            ISourceFormatFactory sourceFormatFactory,
            IDimensionStructureFactory dimensionStructureFactory,
            ISourceFormatDimensionStructureNodeFactory sourceFormatDimensionStructureNodeFactory)
        {
            SourceFormatFactory = sourceFormatFactory ?? throw new ArgumentNullException(
                $"{nameof(sourceFormatFactory)}");
            DimensionStructureFactory = dimensionStructureFactory ?? throw new ArgumentNullException(
                $"{nameof(dimensionStructureFactory)}");
            SourceFormatDimensionStructureNodeFactory = sourceFormatDimensionStructureNodeFactory
                                                     ?? throw new ArgumentNullException(
                                                            nameof(sourceFormatDimensionStructureNodeFactory));
        }

        /// <inheritdoc/>
        public IDimensionStructureFactory DimensionStructureFactory { get; }

        /// <inheritdoc/>
        public ISourceFormatFactory SourceFormatFactory { get; }

        /// <inheritdoc/>
        public ISourceFormatDimensionStructureNodeFactory SourceFormatDimensionStructureNodeFactory { get; }
    }
}
