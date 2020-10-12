namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;

    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;

    public class MasterDataBusinessLogic : IMasterDataBusinessLogic
    {
        public MasterDataBusinessLogic(
            IMasterDataDimensionBusinessLogic masterDataDimensionBusinessLogic,
            IMasterDataDimensionStructureBusinessLogic
                masterDataDimensionStructureBusinessLogic,
            IMasterDataDimensionValueBusinessLogic masterDataDimensionValueBusinessLogic,
            IMasterDataSourceFormatBusinessLogic masterDataSourceFormatBusinessLogic)
        {
            MasterDataDimensionBusinessLogic = masterDataDimensionBusinessLogic ??
                                               throw new ArgumentNullException(
                                                   nameof(masterDataDimensionBusinessLogic));
            MasterDataDimensionStructureBusinessLogic = masterDataDimensionStructureBusinessLogic ??
                                                        throw new ArgumentNullException(
                                                            nameof(masterDataDimensionStructureBusinessLogic));
            MasterDataDimensionValueBusinessLogic = masterDataDimensionValueBusinessLogic ??
                                                    throw new ArgumentNullException(
                                                        nameof(masterDataDimensionValueBusinessLogic));
            MasterDataSourceFormatBusinessLogic = masterDataSourceFormatBusinessLogic ??
                                                  throw new ArgumentNullException(
                                                      nameof(masterDataSourceFormatBusinessLogic));
        }

        public IMasterDataDimensionBusinessLogic MasterDataDimensionBusinessLogic { get; set; }

        public IMasterDataDimensionStructureBusinessLogic MasterDataDimensionStructureBusinessLogic { get; set; }

        public IMasterDataDimensionValueBusinessLogic MasterDataDimensionValueBusinessLogic { get; set; }

        public IMasterDataSourceFormatBusinessLogic MasterDataSourceFormatBusinessLogic { get; set; }
    }
}