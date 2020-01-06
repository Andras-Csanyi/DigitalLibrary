namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Position.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PositionApiWebClientDeleteAsyncOperationException : Exception
    {
        public PositionApiWebClientDeleteAsyncOperationException()
        {
        }

        protected PositionApiWebClientDeleteAsyncOperationException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public PositionApiWebClientDeleteAsyncOperationException(string message) : base(message)
        {
        }

        public PositionApiWebClientDeleteAsyncOperationException(string message, Exception innerException) : base(
            message,
            innerException)
        {
        }
    }
}