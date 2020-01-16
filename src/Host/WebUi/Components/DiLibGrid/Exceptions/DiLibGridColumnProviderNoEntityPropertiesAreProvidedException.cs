using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions
{
    public class DiLibGridColumnProviderNoEntityPropertiesAreProvidedException : Exception
    {
        public DiLibGridColumnProviderNoEntityPropertiesAreProvidedException()
        {
        }

        protected DiLibGridColumnProviderNoEntityPropertiesAreProvidedException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public DiLibGridColumnProviderNoEntityPropertiesAreProvidedException(string? message) : base(message)
        {
        }

        public DiLibGridColumnProviderNoEntityPropertiesAreProvidedException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}