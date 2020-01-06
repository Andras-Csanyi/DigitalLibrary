namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Title
{
    using System;
    using System.Runtime.Serialization;

    public class TitleGetAllAsyncException : Exception
    {
        public TitleGetAllAsyncException()
        {
        }

        protected TitleGetAllAsyncException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TitleGetAllAsyncException(string message) : base(message)
        {
        }

        public TitleGetAllAsyncException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}