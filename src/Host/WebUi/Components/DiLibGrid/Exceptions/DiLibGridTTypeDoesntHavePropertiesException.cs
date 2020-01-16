using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions
{
    public class DiLibGridTTypeDoesntHavePropertiesException : Exception
    {
        public DiLibGridTTypeDoesntHavePropertiesException()
        {
        }

        protected DiLibGridTTypeDoesntHavePropertiesException(SerializationInfo? info, StreamingContext context) : base(
            info, context)
        {
        }

        public DiLibGridTTypeDoesntHavePropertiesException(string? message) : base(message)
        {
        }

        public DiLibGridTTypeDoesntHavePropertiesException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}