namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Title
{
    using System;
    using System.Runtime.Serialization;

    public class TitleModifyOperationException : Exception
    {
        public TitleModifyOperationException()
        {
        }

        protected TitleModifyOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TitleModifyOperationException(string message) : base(message)
        {
        }

        public TitleModifyOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}