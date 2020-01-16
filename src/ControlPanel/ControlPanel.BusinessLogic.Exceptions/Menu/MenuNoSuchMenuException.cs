using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu
{
    public class MenuNoSuchMenuException : Exception
    {
        public MenuNoSuchMenuException()
        {
        }

        protected MenuNoSuchMenuException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public MenuNoSuchMenuException(string message) : base(message)
        {
        }

        public MenuNoSuchMenuException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}