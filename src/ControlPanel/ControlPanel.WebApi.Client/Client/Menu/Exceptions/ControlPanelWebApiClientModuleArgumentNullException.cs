namespace DigitalLibrary.ControlPanel.WebApi.Client.Menu.Exceptions
{
    using System;
    using System.Runtime.Serialization;

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