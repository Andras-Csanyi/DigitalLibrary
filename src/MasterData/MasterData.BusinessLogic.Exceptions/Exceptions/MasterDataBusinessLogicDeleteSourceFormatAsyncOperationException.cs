namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}