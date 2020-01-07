namespace DiLibHttpClient.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class DiLibHttpClientPutException : Exception
    {
        public DiLibHttpClientPutException()
        {
        }

        protected DiLibHttpClientPutException(SerializationInfo? info, StreamingContext context) : base(info, context)
        {
        }

        public DiLibHttpClientPutException(string? message) : base(message)
        {
        }

        public DiLibHttpClientPutException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}