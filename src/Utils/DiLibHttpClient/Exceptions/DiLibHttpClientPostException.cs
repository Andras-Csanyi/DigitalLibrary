namespace DiLibHttpClient.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class DiLibHttpClientPostException : Exception
    {
        public DiLibHttpClientPostException()
        {
        }

        protected DiLibHttpClientPostException(SerializationInfo? info, StreamingContext context) : base(info, context)
        {
        }

        public DiLibHttpClientPostException(string? message) : base(message)
        {
        }

        public DiLibHttpClientPostException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}