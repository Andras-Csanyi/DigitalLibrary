namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
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
