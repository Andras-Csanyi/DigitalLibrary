using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.MasterData.WebApi.Client.Client
{
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