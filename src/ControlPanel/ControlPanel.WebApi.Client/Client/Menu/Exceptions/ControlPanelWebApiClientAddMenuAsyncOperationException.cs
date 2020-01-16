using System;
using System.Runtime.Serialization;

namespace DigitalLibrary.ControlPanel.WebApi.Client.Client.Menu.Exceptions
{
    public class ControlPanelWebApiClientAddMenuAsyncOperationException : Exception
    {
        public ControlPanelWebApiClientAddMenuAsyncOperationException()
        {
        }

        protected ControlPanelWebApiClientAddMenuAsyncOperationException(SerializationInfo info,
                                                                         StreamingContext context) : base(info, context)
        {
        }

        public ControlPanelWebApiClientAddMenuAsyncOperationException(string message) : base(message)
        {
        }

        public ControlPanelWebApiClientAddMenuAsyncOperationException(string message, Exception innerException) : base(
            message, innerException)
        {
        }
    }
}