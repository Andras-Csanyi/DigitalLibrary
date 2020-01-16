using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module
{
    public class ModuleNullInputException : Exception
    {
        public ModuleNullInputException()
        {
        }

        protected ModuleNullInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ModuleNullInputException(string message) : base(message)
        {
        }

        public ModuleNullInputException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}