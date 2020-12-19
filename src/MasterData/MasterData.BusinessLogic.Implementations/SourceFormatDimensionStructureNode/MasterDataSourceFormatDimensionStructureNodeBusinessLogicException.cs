namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormatDimensionStructureNode
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataSourceFormatDimensionStructureNodeBusinessLogicException : Exception
    {
        public MasterDataSourceFormatDimensionStructureNodeBusinessLogicException()
        {
        }

        protected MasterDataSourceFormatDimensionStructureNodeBusinessLogicException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataSourceFormatDimensionStructureNodeBusinessLogicException(string? message) : base(message)
        {
        }

        public MasterDataSourceFormatDimensionStructureNodeBusinessLogicException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}