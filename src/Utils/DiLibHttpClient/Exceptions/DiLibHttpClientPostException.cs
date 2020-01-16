using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.Utils.DiLibHttpClient.Exceptions
{
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