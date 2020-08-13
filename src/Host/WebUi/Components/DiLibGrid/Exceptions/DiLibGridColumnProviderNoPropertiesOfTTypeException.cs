// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions
{
    using System;
    using System.Runtime.Serialization;

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