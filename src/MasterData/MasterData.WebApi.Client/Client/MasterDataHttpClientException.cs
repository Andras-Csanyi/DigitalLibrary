// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.WebApi.Client
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataHttpClientException : Exception
    {
        public MasterDataHttpClientException()
        {
        }

        protected MasterDataHttpClientException(SerializationInfo? info, StreamingContext context) : base(info, context)
        {
        }

        public MasterDataHttpClientException(string? message) : base(message)
        {
        }

        public MasterDataHttpClientException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}