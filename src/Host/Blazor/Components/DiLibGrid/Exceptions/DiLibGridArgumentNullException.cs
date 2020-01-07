namespace Blazor.Components.DiLibGrid.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class DiLibGridArgumentNullException : Exception
    {
        public DiLibGridArgumentNullException()
        {
        }

        protected DiLibGridArgumentNullException(SerializationInfo? info, StreamingContext context) : base(info,
            context)
        {
        }

        public DiLibGridArgumentNullException(string? message) : base(message)
        {
        }

        public DiLibGridArgumentNullException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}