namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicGetSourceFormatsAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetSourceFormatsAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicGetSourceFormatsAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicGetSourceFormatsAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicGetSourceFormatsAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}