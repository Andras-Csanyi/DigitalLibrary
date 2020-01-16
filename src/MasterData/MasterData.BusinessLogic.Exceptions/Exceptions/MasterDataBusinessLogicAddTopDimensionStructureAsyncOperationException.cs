using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicAddTopDimensionStructureAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicAddTopDimensionStructureAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicAddTopDimensionStructureAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicAddTopDimensionStructureAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicAddTopDimensionStructureAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}