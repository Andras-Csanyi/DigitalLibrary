using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicCountDimensionValuesAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicCountDimensionValuesAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicCountDimensionValuesAsyncOperationException(SerializationInfo? info,
                                                                                     StreamingContext context) : base(
            info, context)
        {
        }

        public MasterDataBusinessLogicCountDimensionValuesAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicCountDimensionValuesAsyncOperationException(string? message,
                                                                                  Exception? innerException) : base(
            message, innerException)
        {
        }
    }
}