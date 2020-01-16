using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicGetDimensionValueAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetDimensionValueAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicGetDimensionValueAsyncOperationException(SerializationInfo? info,
                                                                                  StreamingContext context) : base(info,
            context)
        {
        }

        public MasterDataBusinessLogicGetDimensionValueAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicGetDimensionValueAsyncOperationException(string? message,
                                                                               Exception? innerException) : base(
            message, innerException)
        {
        }
    }
}