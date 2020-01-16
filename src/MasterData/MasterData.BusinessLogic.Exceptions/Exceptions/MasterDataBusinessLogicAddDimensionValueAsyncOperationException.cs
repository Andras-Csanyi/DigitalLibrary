using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicAddDimensionValueAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicAddDimensionValueAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicAddDimensionValueAsyncOperationException(SerializationInfo? info,
                                                                                  StreamingContext context) : base(info,
            context)
        {
        }

        public MasterDataBusinessLogicAddDimensionValueAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicAddDimensionValueAsyncOperationException(string? message,
                                                                               Exception? innerException) : base(
            message, innerException)
        {
        }
    }
}