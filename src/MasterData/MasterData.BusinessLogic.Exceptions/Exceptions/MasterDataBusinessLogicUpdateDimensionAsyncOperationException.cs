namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicUpdateDimensionAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicUpdateDimensionAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicUpdateDimensionAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicUpdateDimensionAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicUpdateDimensionAsyncOperationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}