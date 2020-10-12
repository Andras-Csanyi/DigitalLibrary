namespace DigitalLibrary.Utils.MasterDataTestHelper
{
    using System;

    using DigitalLibrary.Utils.MasterDataTestHelper.Tools;
    using DigitalLibrary.Utils.MasterDataTestHelper.Tools.DimensionStructureLinkedListHelper;

    public interface IMasterDataTestHelper
    {
        IDimensionStructureFactory DimensionStructureFactory { get; }

        IDimensionStructureLinkedListHelper DimensionStructureLinkedListHelper { get; }

        ISourceFormatFactory SourceFormatFactory { get; }
    }

    public class MasterDataTestHelper : IMasterDataTestHelper
    {
        public MasterDataTestHelper(
            ISourceFormatFactory sourceFormatFactory,
            IDimensionStructureFactory dimensionStructureFactory,
            IDimensionStructureLinkedListHelper dimensionStructureLinkedListHelper)
        {
            SourceFormatFactory = sourceFormatFactory ?? throw new ArgumentNullException(
                $"{nameof(sourceFormatFactory)}");
            DimensionStructureFactory = dimensionStructureFactory ?? throw new ArgumentNullException(
                $"{nameof(dimensionStructureFactory)}");
            DimensionStructureLinkedListHelper = dimensionStructureLinkedListHelper
                                              ?? throw new ArgumentNullException(
                                                     $"{nameof(dimensionStructureLinkedListHelper)}");
        }

        public IDimensionStructureFactory DimensionStructureFactory { get; }

        public IDimensionStructureLinkedListHelper DimensionStructureLinkedListHelper { get; }


        public ISourceFormatFactory SourceFormatFactory { get; }
    }
}