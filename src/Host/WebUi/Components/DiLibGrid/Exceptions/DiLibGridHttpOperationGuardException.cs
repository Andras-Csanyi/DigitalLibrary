using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.Ui.WebUi.Components.DiLibGrid.Exceptions
{
    public class DiLibGridHttpOperationGuardException : Exception
    {
        public DiLibGridHttpOperationGuardException()
        {
        }

        protected DiLibGridHttpOperationGuardException(SerializationInfo? info, StreamingContext context) : base(info,
            context)
        {
        }

        public DiLibGridHttpOperationGuardException(string? message) : base(message)
        {
        }

        public DiLibGridHttpOperationGuardException(string? message, Exception? innerException) : base(message,
            innerException)
        {
        }
    }
}