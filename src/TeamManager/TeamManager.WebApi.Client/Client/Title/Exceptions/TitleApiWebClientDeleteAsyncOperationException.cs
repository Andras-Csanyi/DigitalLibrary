namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Title.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class TitleApiWebClientDeleteAsyncOperationException : Exception
    {
        public TitleApiWebClientDeleteAsyncOperationException()
        {
        }

        protected TitleApiWebClientDeleteAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public TitleApiWebClientDeleteAsyncOperationException(string message) : base(message)
        {
        }

        public TitleApiWebClientDeleteAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}