namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Title
{
    using System;
    using System.Runtime.Serialization;

    public class TitleAddNewOperationException : Exception
    {
        public TitleAddNewOperationException()
        {
        }

        protected TitleAddNewOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TitleAddNewOperationException(string message) : base(message)
        {
        }

        public TitleAddNewOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}