using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module
{
    public class ModuleDeleteOperationException : Exception
    {
        public ModuleDeleteOperationException()
        {
        }

        protected ModuleDeleteOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ModuleDeleteOperationException(string message) : base(message)
        {
        }

        public ModuleDeleteOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}