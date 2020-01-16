using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions
{
    public class DiLibGridArgumentNullException : Exception
    {
        public DiLibGridArgumentNullException()
        {
        }

        protected DiLibGridArgumentNullException(SerializationInfo? info, StreamingContext context) : base(info,
            context)
        {
        }

        public DiLibGridArgumentNullException(string? message) : base(message)
        {
        }

        public DiLibGridArgumentNullException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}