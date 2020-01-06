namespace Blazor.Components.DiLibGrid.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class DiLibGridGetallAsyncOperationException : Exception
    {
        public DiLibGridGetallAsyncOperationException()
        {
        }

        protected DiLibGridGetallAsyncOperationException(SerializationInfo? info, StreamingContext context) : base(info,
            context)
        {
        }

        public DiLibGridGetallAsyncOperationException(string? message) : base(message)
        {
        }

        public DiLibGridGetallAsyncOperationException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}