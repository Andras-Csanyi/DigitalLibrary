using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions
{
    public class DiLibGridColumnProviderNoPropertiesOfTTypeException : Exception
    {
        public DiLibGridColumnProviderNoPropertiesOfTTypeException()
        {
        }

        protected DiLibGridColumnProviderNoPropertiesOfTTypeException(SerializationInfo? info, StreamingContext context)
            : base(info, context)
        {
        }

        public DiLibGridColumnProviderNoPropertiesOfTTypeException(string? message) : base(message)
        {
        }

        public DiLibGridColumnProviderNoPropertiesOfTTypeException(string? message, Exception? innerException) : base(
            message, innerException)
        {
        }
    }
}