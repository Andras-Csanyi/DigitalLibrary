namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Exceptions.Exceptions.Title
{
    using System;
    using System.Runtime.Serialization;

    public class TitleInputValidationException : Exception
    {
        public TitleInputValidationException()
        {
        }

        protected TitleInputValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TitleInputValidationException(string message) : base(message)
        {
        }

        public TitleInputValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}