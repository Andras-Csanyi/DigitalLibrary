namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Title.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class TitleApiWebClientModifyAsyncOperationException : Exception
    {
        public TitleApiWebClientModifyAsyncOperationException()
        {
        }

        protected TitleApiWebClientModifyAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public TitleApiWebClientModifyAsyncOperationException(string message) : base(message)
        {
        }

        public TitleApiWebClientModifyAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}