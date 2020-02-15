namespace DigitalLibrary.Ui.WebUi.Services
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class SourceFormatBuilderServiceException : Exception
    {
        public SourceFormatBuilderServiceException()
        {
        }

        protected SourceFormatBuilderServiceException(SerializationInfo? info, StreamingContext context) : base(info,
            context)
        {
        }

        public SourceFormatBuilderServiceException(string? message) : base(message)
        {
        }

        public SourceFormatBuilderServiceException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}