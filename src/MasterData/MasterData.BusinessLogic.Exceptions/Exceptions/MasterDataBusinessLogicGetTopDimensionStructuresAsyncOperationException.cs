using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions
{
    public class MasterDataBusinessLogicGetTopDimensionStructuresAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetTopDimensionStructuresAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicGetTopDimensionStructuresAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicGetTopDimensionStructuresAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicGetTopDimensionStructuresAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}