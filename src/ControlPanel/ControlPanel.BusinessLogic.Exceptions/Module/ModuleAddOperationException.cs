using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module
{
    public class ModuleAddOperationException : Exception
    {
        public ModuleAddOperationException()
        {
        }

        protected ModuleAddOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ModuleAddOperationException(string message) : base(message)
        {
        }

        public ModuleAddOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}