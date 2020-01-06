namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Exceptions.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicDeleteDimensionStructureAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicDeleteDimensionStructureAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicDeleteDimensionStructureAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicDeleteDimensionStructureAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicDeleteDimensionStructureAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}