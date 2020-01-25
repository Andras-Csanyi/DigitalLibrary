namespace DigitalLibrary.Utils.DiLibHttpClient.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class DiLibHttpClientGetException : Exception
    {
        public DiLibHttpClientGetException()
        {
        }

        protected DiLibHttpClientGetException(SerializationInfo? info, StreamingContext context) : base(info, context)
        {
        }

        public DiLibHttpClientGetException(string? message) : base(message)
        {
        }

        public DiLibHttpClientGetException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}