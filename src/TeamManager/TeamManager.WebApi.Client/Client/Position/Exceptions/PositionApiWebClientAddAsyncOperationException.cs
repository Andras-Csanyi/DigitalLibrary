namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Position.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PositionApiWebClientAddAsyncOperationException : Exception
    {
        public PositionApiWebClientAddAsyncOperationException()
        {
        }

        protected PositionApiWebClientAddAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(
                info, context)
        {
        }

        public PositionApiWebClientAddAsyncOperationException(string message) : base(message)
        {
        }

        public PositionApiWebClientAddAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}