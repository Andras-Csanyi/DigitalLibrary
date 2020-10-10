namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicDimensionStructureDatabaseOperationException : Exception
    {
        public MasterDataBusinessLogicDimensionStructureDatabaseOperationException()
        {
        }

        protected MasterDataBusinessLogicDimensionStructureDatabaseOperationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicDimensionStructureDatabaseOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicDimensionStructureDatabaseOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}