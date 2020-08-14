// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException(string? message) :
            base(message)
        {
        }

        public MasterDataBusinessLogicUpdateSourceFormatAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}