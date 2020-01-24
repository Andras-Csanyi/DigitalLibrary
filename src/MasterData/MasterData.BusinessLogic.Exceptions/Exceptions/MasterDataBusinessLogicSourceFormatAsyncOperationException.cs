namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;


    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicSourceFormatAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicSourceFormatAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicSourceFormatAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicSourceFormatAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicSourceFormatAsyncOperationException(string? message, Exception? innerException) :
            base(message, innerException)
        {
        }
    }
}