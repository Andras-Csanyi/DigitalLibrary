namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Exceptions.Menu
{
    using System;
    using System.Runtime.Serialization;

    public class MenuNullInputException : Exception
    {
        public MenuNullInputException()
        {
        }

        protected MenuNullInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public MenuNullInputException(string message) : base(message)
        {
        }

        public MenuNullInputException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}