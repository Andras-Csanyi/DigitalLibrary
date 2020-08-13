// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicAddDimensionAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicAddDimensionAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicAddDimensionAsyncOperationException(SerializationInfo? info,
                                                                             StreamingContext context) : base(info,
            context)
        {
        }

        public MasterDataBusinessLogicAddDimensionAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicAddDimensionAsyncOperationException(string? message, Exception? innerException) :
            base(message, innerException)
        {
        }
    }
}