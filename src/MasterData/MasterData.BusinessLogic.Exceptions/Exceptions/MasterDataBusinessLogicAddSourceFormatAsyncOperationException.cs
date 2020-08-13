// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicAddSourceFormatAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicAddSourceFormatAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicAddSourceFormatAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicAddSourceFormatAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicAddSourceFormatAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}