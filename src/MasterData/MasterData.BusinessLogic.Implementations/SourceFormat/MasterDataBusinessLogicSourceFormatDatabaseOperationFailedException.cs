namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicSourceFormatDatabaseOperationFailedException : Exception
    {
        public MasterDataBusinessLogicSourceFormatDatabaseOperationFailedException()
        {
        }

        protected MasterDataBusinessLogicSourceFormatDatabaseOperationFailedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicSourceFormatDatabaseOperationFailedException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicSourceFormatDatabaseOperationFailedException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}