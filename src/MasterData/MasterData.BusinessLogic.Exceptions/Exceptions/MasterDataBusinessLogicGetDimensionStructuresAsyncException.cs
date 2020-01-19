namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicGetDimensionStructuresAsyncException : Exception
    {
        public MasterDataBusinessLogicGetDimensionStructuresAsyncException()
        {
        }

        protected MasterDataBusinessLogicGetDimensionStructuresAsyncException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicGetDimensionStructuresAsyncException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicGetDimensionStructuresAsyncException(string? message, Exception? innerException) :
            base(message, innerException)
        {
        }
    }
}