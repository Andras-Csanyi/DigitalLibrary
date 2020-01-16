using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.Utils.DiLibHttpClient.Exceptions
{
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