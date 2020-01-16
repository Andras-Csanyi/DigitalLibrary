using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.Controllers.Exceptions
{
    public class MenuControllerNullInputException : Exception
    {
        public MenuControllerNullInputException()
        {
        }

        protected MenuControllerNullInputException(SerializationInfo? info, StreamingContext context) : base(info,
            context)
        {
        }

        public MenuControllerNullInputException(string? message) : base(message)
        {
        }

        public MenuControllerNullInputException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}