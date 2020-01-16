using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Client.Menu.Exceptions
{
    public class ControlPanelWebApiClientArgumentNullException : Exception
    {
        public ControlPanelWebApiClientArgumentNullException()
        {
        }

        protected ControlPanelWebApiClientArgumentNullException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }

        public ControlPanelWebApiClientArgumentNullException(string message) : base(message)
        {
        }

        public ControlPanelWebApiClientArgumentNullException(string message, Exception innerException) : base(
            message, innerException)
        {
        }
    }
}