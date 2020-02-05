namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}