namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.SourceFormat
{
    using System;
    using System.Runtime.Serialization;

    public class SourceFormatStepDefException : Exception
    {
        public SourceFormatStepDefException()
        {
        }

        protected SourceFormatStepDefException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public SourceFormatStepDefException(string? message) : base(message)
        {
        }

        public SourceFormatStepDefException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}