namespace DigitalLibrary.ControlPanel.Controllers.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MenuControllerNullInputException : Exception
    {
        public MenuControllerNullInputException()
        {
        }

        protected MenuControllerNullInputException(SerializationInfo? info, StreamingContext context)
            : base(info, context)
        {
        }

        public MenuControllerNullInputException(string? message)
            : base(message)
        {
        }

        public MenuControllerNullInputException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}