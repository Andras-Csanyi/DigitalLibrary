namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicDeleteDimensionAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicDeleteDimensionAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicDeleteDimensionAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicDeleteDimensionAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicDeleteDimensionAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}