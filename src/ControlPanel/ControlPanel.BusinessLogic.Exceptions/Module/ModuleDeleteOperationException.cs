namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Exceptions.Module
{
    using System;
    using System.Runtime.Serialization;

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