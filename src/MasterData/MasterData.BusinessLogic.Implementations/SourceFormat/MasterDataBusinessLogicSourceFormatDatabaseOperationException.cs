namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicSourceFormatDatabaseOperationException : Exception
    {
        public MasterDataBusinessLogicSourceFormatDatabaseOperationException()
        {
        }

        protected MasterDataBusinessLogicSourceFormatDatabaseOperationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicSourceFormatDatabaseOperationException(string? message) : base(message)
        {
        }

        public MasterDataBusinessLogicSourceFormatDatabaseOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}