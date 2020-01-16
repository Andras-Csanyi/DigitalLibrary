using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions
{
    public class DiLibGridHttpClientNotInstantiatedException : Exception
    {
        public DiLibGridHttpClientNotInstantiatedException()
        {
        }

        protected DiLibGridHttpClientNotInstantiatedException(SerializationInfo? info, StreamingContext context) : base(
            info, context)
        {
        }

        public DiLibGridHttpClientNotInstantiatedException(string? message) : base(message)
        {
        }

        public DiLibGridHttpClientNotInstantiatedException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}