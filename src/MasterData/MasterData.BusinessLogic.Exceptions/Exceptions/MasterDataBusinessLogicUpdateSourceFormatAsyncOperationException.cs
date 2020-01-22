namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;

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