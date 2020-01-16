using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.Utils.DiLibHttpClient.Exceptions
{
    public class DiLibHttpClientDeleteException : Exception
    {
        public DiLibHttpClientDeleteException()
        {
        }

        protected DiLibHttpClientDeleteException(SerializationInfo? info, StreamingContext context) : base(info,
            context)
        {
        }

        public DiLibHttpClientDeleteException(string? message) : base(message)
        {
        }

        public DiLibHttpClientDeleteException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}