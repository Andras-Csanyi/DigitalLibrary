// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicGetSourceFormatByIdAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetSourceFormatByIdAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicGetSourceFormatByIdAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicGetSourceFormatByIdAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicGetSourceFormatByIdAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}