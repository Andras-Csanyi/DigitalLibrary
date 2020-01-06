namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Position.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class PositionApiWebClientGetAllActiveAsyncOperationException : Exception
    {
        public PositionApiWebClientGetAllActiveAsyncOperationException()
        {
        }

        protected PositionApiWebClientGetAllActiveAsyncOperationException(SerializationInfo info,
                                                                          StreamingContext context)
            : base(info, context)
        {
        }

        public PositionApiWebClientGetAllActiveAsyncOperationException(string message) : base(message)
        {
        }

        public PositionApiWebClientGetAllActiveAsyncOperationException(string message, Exception innerException) : base(
            message, innerException)
        {
        }
    }
}