using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions
{
    public class GenericObjectPropertiesProviderException : Exception
    {
        public GenericObjectPropertiesProviderException()
        {
        }

        protected GenericObjectPropertiesProviderException(SerializationInfo? info, StreamingContext context) : base(
            info, context)
        {
        }

        public GenericObjectPropertiesProviderException(string? message) : base(message)
        {
        }

        public GenericObjectPropertiesProviderException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}