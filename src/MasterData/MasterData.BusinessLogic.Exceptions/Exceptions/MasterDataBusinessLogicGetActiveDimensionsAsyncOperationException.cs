namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Exceptions.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicGetActiveDimensionsAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetActiveDimensionsAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicGetActiveDimensionsAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicGetActiveDimensionsAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicGetActiveDimensionsAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}