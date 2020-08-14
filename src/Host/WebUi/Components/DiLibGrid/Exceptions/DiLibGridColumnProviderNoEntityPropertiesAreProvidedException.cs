// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions
{
    using System;
    using System.Runtime.Serialization;

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