// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicModifyDimensionValueAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicModifyDimensionValueAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicModifyDimensionValueAsyncOperationException(SerializationInfo? info,
                                                                                     StreamingContext context) : base(
            info, context)
        {
        }

        public MasterDataBusinessLogicModifyDimensionValueAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicModifyDimensionValueAsyncOperationException(string? message,
                                                                                  Exception? innerException) : base(
            message, innerException)
        {
        }
    }
}