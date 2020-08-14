// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.Utils.DiLibHttpClient.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class DiLibHttpClientErrorDetailsException : Exception
    {
        public DiLibHttpClientErrorDetailsException()
        {
        }

        protected DiLibHttpClientErrorDetailsException(SerializationInfo? info, StreamingContext context) : base(info,
            context)
        {
        }

        public DiLibHttpClientErrorDetailsException(string? message) : base(message)
        {
        }

        public DiLibHttpClientErrorDetailsException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}