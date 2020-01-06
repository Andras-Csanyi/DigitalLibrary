namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Title
{
    using System;
    using System.Runtime.Serialization;

    public class TitleGetAllActiveAsyncOperationException : Exception
    {
        public TitleGetAllActiveAsyncOperationException()
        {
        }

        protected TitleGetAllActiveAsyncOperationException(SerializationInfo info, StreamingContext context) : base(
            info, context)
        {
        }

        public TitleGetAllActiveAsyncOperationException(string message) : base(message)
        {
        }

        public TitleGetAllActiveAsyncOperationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}